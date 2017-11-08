using Bloomberglp.Blpapi.Examples;
using PriceUpdate;
using RefDataExample;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace PriceUpdateProgram
{
    [Flags]
    public enum BloombergRequestTypeEnum
    {
        Full = 1, Intraday = 2
    }

    public class BloombergHelper
    {
        public static SqlConnection connection;
        public event EventHandler ProgressUpdated;
        public BloombergHelper()
        {

        }
        public static void createConnection(string connectionString)
        {
            connection = new SqlConnection(connectionString);
        }

        public static List<BBInstrument> RequestOutdatedInstrumentList()
        {
            List<BBInstrument> _list = new List<BBInstrument>();
            createConnection("DATA SOURCE=vmSQL02;Initial Catalog=MidasPM_CCF;Integrated Security=SSPI;Connect Timeout=120;");
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


        public void RunFullPriceUpdate()
        {
            List<string> Fields = new List<string> {"ID_BB_Unique", "ID_ISIN", "TICKER", "ID_SEDOL1", "ID_COMMON", "MARKET_SECTOR_DES", "EXCH_CODE",
                "NAME", "PX_MID", "PX_BID", "PX_ASK", "PX_Last", "CRNCY", "EQY_DVD_SH_12M", "DVD_CRNCY", "FUND_NET_ASSET_VAL", "REL_1M",
                "REL_3M", "REL_6M", "REL_1YR", "REL_MTD", "REL_QTD", "REL_YTD", "IS_EPS", "PX_TO_BOOK_RATIO", "BS_CORE_CAP_RATIO",
                "CF_FREE_CASH_FLOW", "EBITDA", "EBIT", "ENTERPRISE_VALUE", "PAR_AMT", "BS_PAR_VAL", "CPN", "MATURITY", "INT_ACC_PER_BOND", "NXT_CPN_DT", "EQY_SH_OUT"};
            try
            {
                createConnection("DATA SOURCE=vmSQL02;Initial Catalog=MidasPM_CCF;Integrated Security=SSPI;Connect Timeout=120;");
                PriceUpdateBloombergRequest _bloombergData = new PriceUpdateBloombergRequest();
                _bloombergData.InstrumentUpdated += _bloombergData_InstrumentUpdated;
                _bloombergData.RunFullPriceUpdate(RequestOutdatedInstrumentList(), Fields);

                //List<BBInstrument> _notDone = _bloombergData.BloombergInstruments.Where(p => p.BloombergUpdate == false).ToList();
            }
            finally
            {
                connection.Close();
            }
        }

        public void RunIntradayPriceUpdate()
        {
            try
            {
                createConnection("DATA SOURCE=vmSQL02;Initial Catalog=MidasPM_CCF;Integrated Security=SSPI;Connect Timeout=120;");
                IntradayPriceBloombergRequest _bbData = new IntradayPriceBloombergRequest();
                BBInstrument temporaryI = _bbData.RunIntradayPriceUpdate(RequestOutdatedInstrumentList().First(), DateTime.Now);
            }
            finally
            {
                connection.Close();
            }
        }

        private void _bloombergData_InstrumentUpdated(object sender, EventArgs e)
        {
            ProgressUpdated(sender, e);
        }
    }
}
