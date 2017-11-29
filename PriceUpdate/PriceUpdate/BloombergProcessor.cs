using Bloomberglp.Blpapi.Examples;
using PriceUpdate;
using RefDataExample;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Configuration;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Bloomberglp.Blpapi;
using System.Windows.Forms;
using System.IO;
using System.Timers;
using System.Diagnostics;

namespace PriceUpdateProgram
{
    struct DFDetails
    {
        public string ItemName;
        public DateTime Value;
    }

    [Flags]
    public enum DFDetailsType
    {
        Full = 1, Lite = 2
    }

    public class BloombergProcessor
    {
        public static SqlConnection connection;
        public event System.EventHandler ProgressUpdated;
        public event System.EventHandler IntradayCompleted;
        System.Windows.Forms.Timer timer = new System.Windows.Forms.Timer();
        public BloombergProcessor()
        {

        }
        public static void createConnection()
        {
            try
            {
                string _filepathDF = Path.Combine(PriceUpdate.Properties.Settings.Default.ConnectionStringPath, ("df_" + Environment.MachineName + ".txt"));
                string _connectionString = File.ReadAllText(_filepathDF);
                connection = new SqlConnection(_connectionString);
            }
            catch(FileNotFoundException e)
            {
                string _filepath = Path.Combine(PriceUpdate.Properties.Settings.Default.ConnectionStringPath, (Environment.MachineName + ".txt"));
                string _connectionString = File.ReadAllText(_filepath);
                connection = new SqlConnection(_connectionString);
            }
            
        }

        //Self explanatory
        public static List<BBInstrument> RequestOutdatedInstrumentList()
        {
            List<BBInstrument> _list = new List<BBInstrument>();
            createConnection();
            string _storedProcedure = "sp_PMInstrument_CreateDate";
            SqlDataAdapter _sda = new SqlDataAdapter(_storedProcedure, connection);
            DataTable _dt = new DataTable();
            try
            {
                connection.Open();
                _sda.Fill(_dt);
            }
            catch (SqlException se)
            {
                System.Windows.Forms.MessageBox.Show(se.Message);
            }
            finally
            {
                connection.Close();
            }

            foreach (DataRow row in _dt.Rows)
            {
                _list.Add(new BBInstrument(row));
            }
            return _list;
        }

        //Self explanatory
        public static List<ArrivalPrice> RequestArrivalPriceList()
        {
            List<ArrivalPrice> _list = new List<ArrivalPrice>();
            createConnection();
            string _storedProcedure = "sp_PMInstrument_MissingArrivalPrice";
            SqlDataAdapter _sda = new SqlDataAdapter(_storedProcedure, connection);
            DataTable _dt = new DataTable();
            try
            {
                connection.Open();
                _sda.Fill(_dt);
            }
            catch (SqlException se)
            {
                System.Windows.Forms.MessageBox.Show(se.Message);
            }
            finally
            {
                connection.Close();
            }

            foreach (DataRow row in _dt.Rows)
            {
                _list.Add(new ArrivalPrice(row));
            }
            return _list;
        }


        //Self explanatory
        public void RunFullPriceUpdate()
        {
            timer.Stop();
            List<string> _fullFields = new List<string> {"ID_BB_Unique", "ID_ISIN", "TICKER", "ID_SEDOL1", "ID_COMMON", "LEGAL_ENTITY_IDENTIFIER", "MARKET_SECTOR_DES", "EXCH_CODE", "ID_MIC_PRIM_EXCH",
                "NAME", "PX_MID", "PX_BID", "PX_ASK", "PX_Last", "CRNCY", "EQY_DVD_SH_12M", "DVD_CRNCY", "FUND_NET_ASSET_VAL", "REL_1M",
                "REL_3M", "REL_6M", "REL_1YR", "REL_MTD", "REL_QTD", "REL_YTD", "IS_EPS", "PX_TO_BOOK_RATIO", "BS_CORE_CAP_RATIO",
                "CF_FREE_CASH_FLOW", "EBITDA", "EBIT", "ENTERPRISE_VALUE", "PAR_AMT", "BS_PAR_VAL", "CPN", "MATURITY", "INT_ACC_PER_BOND", "NXT_CPN_DT", "EQY_SH_OUT", "CFI_CODE"};
            try
            {
                createConnection();
                PriceUpdateBloombergRequest _bloombergData = new PriceUpdateBloombergRequest();
                _bloombergData.InstrumentUpdated += _bloombergData_InstrumentUpdated;
                _bloombergData.RunFullPriceUpdate(RequestOutdatedInstrumentList(), _fullFields);
                updateDFDetails(DFDetailsType.Full);
                connection.Open();

                foreach (BBInstrument i in _bloombergData.BloombergInstruments)
                {
                    i.GetData_Price();
                    i.Update(connection);
                }
            }
            finally
            {
                connection.Close();
            }
        }

        //Self explanatory
        public void RunMiniPriceUpdate()
        {
            timer.Stop();
            List<string> _miniFields = new List<string> { "ID_BB_Unique", "ID_ISIN", "TICKER", "PX_MID", "PX_BID", "PX_ASK", "PX_Last", "REL_1M",
                "REL_3M", "REL_6M", "REL_1YR", "REL_MTD", "REL_QTD", "REL_YTD", "CRNCY", "DVD_CRNCY"};
            try
            {
                createConnection();
                PriceUpdateBloombergRequest _bloombergData = new PriceUpdateBloombergRequest();
                _bloombergData.InstrumentUpdated += _bloombergData_InstrumentUpdated;
                _bloombergData.RunMiniPriceUpdate(RequestOutdatedInstrumentList(), _miniFields);
                updateDFDetails(DFDetailsType.Lite);
                connection.Open();

                foreach (BBInstrument i in _bloombergData.BloombergInstruments)
                {
                    i.GetData_Price();
                    i.Update(connection);
                }
            }
            finally
            {
                connection.Close();
            }
        }

        //Helps the method below to get the data fdor intraday price
        private double requestIntradayData(ArrivalPrice priceDetails)
        {
            DateTime _rangeFrom = priceDetails.PriceDateTime;
            ArrivalPrice ap = priceDetails;
            double _price = 0;

            if (priceDetails.PriceDateTime.TimeOfDay.Ticks != 0)
            {
                priceDetails.PriceFlag = IntradayPrice.Intraday;
                IntradayPriceBloombergRequest _retrieve = new IntradayPriceBloombergRequest();
                _retrieve.RunIntradayPriceUpdate(priceDetails.ID_DataFeed, _rangeFrom, _rangeFrom.AddHours(1));
                _price = _retrieve.Price;
            }
            else
            {
                priceDetails.PriceFlag = IntradayPrice.Opening;
                OpeningPriceBloombergRequest openingPriceRequest = new OpeningPriceBloombergRequest();
                openingPriceRequest.GetOpeningPrice(priceDetails.ID_DataFeed, priceDetails.PriceDateTime.AddDays(-1), priceDetails.PriceDateTime);
                _price = openingPriceRequest.Price;
            }
            return _price;
        }
    

        //Self explanatory
        public void RunIntradayPriceUpdate()
        {
            List<ArrivalPrice> items = RequestArrivalPriceList();
            foreach (ArrivalPrice ap in items.ToList())
            {
                try
                {
                    createConnection();
                    ap.Price = requestIntradayData(ap);
                }
                catch(Exception e)
                {
                    continue;
                }
                finally
                {
                    connection.Close();
                }
            }
            IntradayCompleted("Request completed - Intraday prices updated", new EventArgs());
        }

        //Event to update the process label
        private void _bloombergData_InstrumentUpdated(object sender, EventArgs e)
        {
            ProgressUpdated(sender, e);
        }

        //Method to trigger the timer
        public void StartCounting()
        {
            timer.Tick += new System.EventHandler(TimerEventProcessor);
            timer.Interval = 1000 * 60;
            timer.Start();
        }

        //Event that fires when the timer hits 1 minute, runs a price update if the last is < requested
        private void TimerEventProcessor(Object myObject, EventArgs myEventArgs)
        {
            timer.Stop();

            createConnection();
            string _storedProcedure = "sp_PMDFDetails";
            SqlDataAdapter _sda = new SqlDataAdapter(_storedProcedure, connection);
            DataTable _dt = new DataTable();
            List<DFDetails> details = new List<DFDetails>();
            try
            {
                connection.Open();
                _sda.Fill(_dt);
            }
            catch (SqlException se)
            {

            }
            finally
            {
                connection.Close();
            }

            foreach (DataRow row in _dt.Rows)
            {
                DFDetails dFDetails = new DFDetails();
                dFDetails.ItemName = row["ItemName"].ToString();
                dFDetails.Value = Convert.ToDateTime(row["UpdatedTime"]);
                details.Add(dFDetails);
            }

            DFDetails _fullCompleted = details.Single(p => p.ItemName == "DFCompletedFull");
            DFDetails _fullRequested = details.Single(p => p.ItemName == "DFRequestedFull");
            DFDetails _liteCompleted = details.Single(p => p.ItemName == "DFCompletedLite");
            DFDetails _liteRequested = details.Single(p => p.ItemName == "DFRequestedLite");

            if(_fullCompleted.Value.Day < DateTime.Now.Day)
            {
                RunFullPriceUpdate();
            }
            else if (_liteCompleted.Value < _liteRequested.Value)
            {
                RunMiniPriceUpdate();
            }

            if (_fullCompleted.Value < _fullRequested.Value)
            {
               RunFullPriceUpdate();
            }

            
            
        }

        //Method to update the DF table and completed update time
        public void updateDFDetails(DFDetailsType type)
        {
            string _storedProcedure = "sp_PMDFUpdate";
            string _itemDFUpdateName = String.Empty;
            if (type == DFDetailsType.Full)
                _itemDFUpdateName = "DFCompletedFull";
            else if (type == DFDetailsType.Lite)
                _itemDFUpdateName = "DFCompletedLite";

            connection.Open();
            SqlCommand _cmd = new SqlCommand(_storedProcedure, connection);
            _cmd.Parameters.Add("@DFItemName", SqlDbType.Text).Value = _itemDFUpdateName;
            _cmd.Parameters.Add("@TimeUpdated", SqlDbType.DateTime).Value = DateTime.Now;
            _cmd.ExecuteNonQuery();
        }
    }
}
