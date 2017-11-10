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

    public class BloombergHelper
    {
        public static SqlConnection connection;
        public event System.EventHandler ProgressUpdated;
        System.Windows.Forms.Timer timer = new System.Windows.Forms.Timer();
        public BloombergHelper()
        {

        }
        public static void createConnection()
        {
            string _filepath = Path.Combine(PriceUpdate.Properties.Settings.Default.ConnectionStringPath, ("df_" + Environment.MachineName + ".txt"));
            string _connectionString = File.ReadAllText(_filepath);
            connection = new SqlConnection(_connectionString);
        }

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


        public void RunFullPriceUpdate()
        {
            List<string> _fullFields = new List<string> {"ID_BB_Unique", "ID_ISIN", "TICKER", "ID_SEDOL1", "ID_COMMON", "MARKET_SECTOR_DES", "EXCH_CODE",
                "NAME", "PX_MID", "PX_BID", "PX_ASK", "PX_Last", "CRNCY", "EQY_DVD_SH_12M", "DVD_CRNCY", "FUND_NET_ASSET_VAL", "REL_1M",
                "REL_3M", "REL_6M", "REL_1YR", "REL_MTD", "REL_QTD", "REL_YTD", "IS_EPS", "PX_TO_BOOK_RATIO", "BS_CORE_CAP_RATIO",
                "CF_FREE_CASH_FLOW", "EBITDA", "EBIT", "ENTERPRISE_VALUE", "PAR_AMT", "BS_PAR_VAL", "CPN", "MATURITY", "INT_ACC_PER_BOND", "NXT_CPN_DT", "EQY_SH_OUT"};
            try
            {
                createConnection();
                PriceUpdateBloombergRequest _bloombergData = new PriceUpdateBloombergRequest();
                _bloombergData.InstrumentUpdated += _bloombergData_InstrumentUpdated;
                _bloombergData.RunFullPriceUpdate(RequestOutdatedInstrumentList(), _fullFields);


                updateDFDetails(DFDetailsType.Full);
            }
            finally
            {
                connection.Close();
            }
        }

        public void RunMiniPriceUpdate()
        {
            List<string> _miniFields = new List<string> { "ID_BB_Unique", "ID_ISIN", "TICKER", "PX_MID", "PX_BID", "PX_ASK", "PX_Last" };
            try
            {
                createConnection();
                PriceUpdateBloombergRequest _bloombergData = new PriceUpdateBloombergRequest();
                _bloombergData.InstrumentUpdated += _bloombergData_InstrumentUpdated;
                _bloombergData.RunMiniPriceUpdate(RequestOutdatedInstrumentList(), _miniFields);

                updateDFDetails(DFDetailsType.Lite);
            }
            finally
            {
                connection.Close();
            }
        }

        private bool requestIntradayData(ArrivalPrice priceDetails)
        {
            DateTime _rangeFrom = priceDetails.PriceDateTime;
            Stopwatch sw = new Stopwatch();
            bool _hasPrice = false;
            double _price = 0;
            if (priceDetails.PriceDateTime.ToLongTimeString() != "00:00:00")
            {
                priceDetails.PriceFlag = IntradayPrice.Intraday;
                while (_hasPrice != true)
                {

                    IntradayPriceBloombergRequest _retrieve = new IntradayPriceBloombergRequest(priceDetails.ID_DataFeed, _rangeFrom, _rangeFrom.AddHours(1));
                    sw.Start();
                    try
                    _retrieve.RunIntradayPriceUpdate();
                    _price = _retrieve.Price;
                    if (_retrieve.Price != 0)
                        _hasPrice = true;
                }
            }
            else
            {
                priceDetails.PriceFlag = IntradayPrice.Opening;
                IntradayBarExample openingPriceRequest = new IntradayBarExample(priceDetails.ID_DataFeed, priceDetails.PriceDateTime, priceDetails.PriceDateTime.AddMinutes(15));
                _price = openingPriceRequest.GetOpeningPrice();
            }
            priceDetails.Price = _price;
            return _hasPrice;
        }
    

        public void RunIntradayPriceUpdate()
        {
            createConnection();
            List<ArrivalPrice> items = RequestArrivalPriceList();
            
            List<ArrivalPrice> _test = new List<ArrivalPrice>();
            foreach (ArrivalPrice ap in items)
            {
                try
                {
                    
                    while (!requestIntradayData(ap))
                    {
                        if (sw.ElapsedMilliseconds > 2000) throw new TimeoutException();
                    }
                    
                }
                catch(TimeoutException te)
                {
                    continue;
                }
                _test.Add(ap);
            }
            connection.Close();
        }

        private void _bloombergData_InstrumentUpdated(object sender, EventArgs e)
        {
            ProgressUpdated(sender, e);
        }

        public void StartCounting()
        {
            timer.Tick += new System.EventHandler(TimerEventProcessor);
            timer.Interval = 1000 * 60;
            timer.Start();
        }

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
                dFDetails.Value = Convert.ToDateTime(row["TimeUpdated"]);
                details.Add(dFDetails);
            }

            DFDetails _fullCompleted = details.Single(p => p.ItemName == "DFCompletedFull");
            DFDetails _fullRequested = details.Single(p => p.ItemName == "DFRequestedFull");
            DFDetails _liteCompleted = details.Single(p => p.ItemName == "DFCompletedLite");
            DFDetails _liteRequested = details.Single(p => p.ItemName == "DFRequestedLite");

            if (_fullCompleted.Value < _fullRequested.Value)
            {
                RunFullPriceUpdate();
            }

            if(_liteCompleted.Value < _liteRequested.Value)
            {
                RunMiniPriceUpdate();
            }
            
        }

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
            _cmd.Parameters.Add("@ItemName", SqlDbType.Text).Value = _itemDFUpdateName;
            _cmd.Parameters.Add("@TimeUpdated", SqlDbType.DateTime).Value = DateTime.Now;
            _cmd.ExecuteNonQuery();
        }
    }
}
