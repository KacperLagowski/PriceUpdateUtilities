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
using System.IO;

namespace PriceUpdateProgram
{
    public class BloombergHelper
    {
        public static SqlConnection connection;
        public event System.EventHandler ProgressUpdated;
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

                //List<BBInstrument> _notDone = _bloombergData.BloombergInstruments.Where(p => p.BloombergUpdate == false).ToList();
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

                List<BBInstrument> _test = _bloombergData.BloombergInstruments;
            }
            finally
            {
                connection.Close();
            }
        }

        public void RunIntradayPriceUpdate()
        {
            List<ArrivalPrice> items = RequestArrivalPriceList();
            foreach (ArrivalPrice ap in items)
            {
                createConnection();
                DateTime _rangeFrom = ap.PriceDateTime;
                bool _hasPrice = false;
                double _price = 0;
                if(ap.PriceDateTime.ToLongTimeString() != "00:00:00")
                {
                    ap.PriceFlag = IntradayPrice.Intraday;
                    while (_hasPrice != true)
                    {
                        
                        IntradayPriceBloombergRequest _retrieve = new IntradayPriceBloombergRequest(ap.ID_DataFeed, _rangeFrom, _rangeFrom.AddHours(1));
                        _retrieve.RunIntradayPriceUpdate();
                        _price = _retrieve.Price;
                        if (_retrieve.Price != 0)
                            _hasPrice = true;
                    }
                }
                else
                {
                    ap.PriceFlag = IntradayPrice.Opening;
                    IntradayBarExample openingPriceRequest = new IntradayBarExample(ap.ID_DataFeed, ap.PriceDateTime, ap.PriceDateTime.AddMinutes(15));
                    _price = openingPriceRequest.GetOpeningPrice();
                }

                connection.Close();
                ap.Price = _price;
                //ap.Update(connection);
            }
        }

        private void _bloombergData_InstrumentUpdated(object sender, EventArgs e)
        {
            ProgressUpdated(sender, e);
        }
    }
}
