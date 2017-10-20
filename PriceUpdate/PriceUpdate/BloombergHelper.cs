using Bloomberglp.Blpapi.Examples;
using RefDataExample;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PriceUpdateProgram
{
    public class BloombergHelper
    {
        private static SqlConnection connection;
        private static List<BBInstrument> _requested = new List<BBInstrument>();
        public BloombergHelper()
        {

        }
        private static void createConnection(string connectionString)
        {
            connection = new SqlConnection(connectionString);
        }

        public static List<BBInstrument> RequestOutdatedInstrumentList()
        {
            List<BBInstrument> _list = new List<BBInstrument>();
            createConnection("");
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

        public static void SaveUpdatedInstruments(List<BBInstrument> instruments)
        {
            string _storedProcedure = "";
            foreach (BBInstrument _i in instruments)
            {
                try
                {
                    createConnection("");
                    connection.Open();
                    SqlCommand _cmd = new SqlCommand(_storedProcedure, connection);
                    #region DB Parameters
                    _cmd.Parameters.Add("@ID_MPM", SqlDbType.Int).Value = _i.ID_MPM;
                    _cmd.Parameters.Add("@ID_DataFeed", SqlDbType.NVarChar, 50).Value = _i.ID_DataFeed;
                    _cmd.Parameters.Add("@Sys_Note_System", SqlDbType.NVarChar, 255).Value = _i.Sys_Note_System;
                    _cmd.Parameters.Add("@Sys_Note_User", SqlDbType.NVarChar, 255).Value = _i.Sys_Note_User;
                    _cmd.Parameters.Add("@User_ID", SqlDbType.NVarChar, 50).Value = _i.UserID;
                    _cmd.Parameters.Add("@Sys_DataFeed_Type", SqlDbType.Int).Value = _i.Sys_DataFeed_Type;
                    _cmd.Parameters.Add("@Sys_End", SqlDbType.Bit).Value = _i.Sys_End;
                    _cmd.Parameters.Add("@Data_BloombergID", SqlDbType.NVarChar, 50).Value = _i.BloombergID;
                    _cmd.Parameters.Add("@Data_ISIN", SqlDbType.NVarChar, 50).Value = _i.ISIN;
                    _cmd.Parameters.Add("@Data_Ticker", SqlDbType.NVarChar, 50).Value = _i.Ticker;
                    _cmd.Parameters.Add("@Data_Sedol1", SqlDbType.NVarChar, 50).Value = _i.Sedol1;
                    _cmd.Parameters.Add("@Data_Common", SqlDbType.NVarChar, 50).Value = _i.Common;
                    _cmd.Parameters.Add("@Data_Other", SqlDbType.NVarChar, 50).Value = _i.Other;
                    _cmd.Parameters.Add("@Data_Type", SqlDbType.NVarChar, 50).Value = _i.Type;
                    _cmd.Parameters.Add("@Data_Exchange", SqlDbType.NVarChar, 50).Value = _i.Exchange;
                    _cmd.Parameters.Add("@Data_Name", SqlDbType.NVarChar, 255).Value = _i.Name;
                    _cmd.Parameters.Add("@Data_Name_Midas_Short", SqlDbType.NVarChar, 40).Value = _i.Name_Midas_Short;
                    _cmd.Parameters.Add("@Data_Name_Midas_Long", SqlDbType.NVarChar, 80).Value = _i.Name_Midas_Long;
                    _cmd.Parameters.Add("@Data_Price", SqlDbType.Decimal).Value = _i.Price;
                    _cmd.Parameters.Add("@Data_Price_Mid", SqlDbType.Decimal).Value = _i.Price_Mid;
                    _cmd.Parameters.Add("@Data_Price_Bid", SqlDbType.Decimal).Value = _i.Price_Bid;
                    _cmd.Parameters.Add("@Data_Price_Ask", SqlDbType.Decimal).Value = _i.Price_Ask;
                    _cmd.Parameters.Add("@Data_Price_Last", SqlDbType.Decimal).Value = _i.Price_Last;
                    _cmd.Parameters.Add("@Data_Price_Net_Asset_Value", SqlDbType.Decimal).Value = _i.Price_Net_Asset_Value;
                    _cmd.Parameters.Add("@Data_Price_Default", SqlDbType.Decimal).Value = _i.Price_Default;
                    _cmd.Parameters.Add("@Data_Price_Currency_ID", SqlDbType.NVarChar, 50).Value = _i.Price_Currency_ID;
                    _cmd.Parameters.Add("@Data_Price_Factor", SqlDbType.Decimal).Value = _i.Price_Factor;
                    _cmd.Parameters.Add("@Data_Div_Gross", SqlDbType.Decimal).Value = _i.Div_Gross;
                    _cmd.Parameters.Add("@Data_Div_Factor", SqlDbType.Decimal).Value = _i.Div_Factor;
                    _cmd.Parameters.Add("@Data_Price_Ex_Date", SqlDbType.DateTime).Value = _i.Div_Ex_Date;
                    _cmd.Parameters.Add("@Data_Rel_Perf_1M", SqlDbType.Decimal).Value = _i.Rel_Perf_1M;
                    _cmd.Parameters.Add("@Data_Rel_Perf_3M", SqlDbType.Decimal).Value = _i.Rel_Perf_3M;
                    _cmd.Parameters.Add("@Data_Rel_Perf_6M", SqlDbType.Decimal).Value = _i.Rel_Perf_6M;
                    _cmd.Parameters.Add("@Data_Rel_Perf_12M", SqlDbType.Decimal).Value = _i.Rel_Perf_12M;
                    _cmd.Parameters.Add("@Data_Rel_Perf_MTD", SqlDbType.Decimal).Value = _i.Rel_Perf_MTD;
                    _cmd.Parameters.Add("@Data_Rel_Perf_QTD", SqlDbType.Decimal).Value = _i.Rel_Perf_QTD;
                    _cmd.Parameters.Add("@Data_Rel_Perf_YTD", SqlDbType.Decimal).Value = _i.Rel_Perf_QTD;
                    _cmd.Parameters.Add("@Data_Earnings_Per_Share", SqlDbType.Decimal).Value = _i.Earnings_Per_Share;
                    _cmd.Parameters.Add("@Data_Price_To_Book", SqlDbType.Decimal).Value = _i.Price_To_Book;
                    _cmd.Parameters.Add("@Data_Tier_1_Ratio", SqlDbType.Decimal).Value = _i.Tier_1_Ratio;
                    _cmd.Parameters.Add("@Data_Free_Cash_Flow", SqlDbType.Decimal).Value = _i.Free_Cash_Flow;
                    _cmd.Parameters.Add("@Data_EBITDA", SqlDbType.Decimal).Value = _i.EBITDA;
                    _cmd.Parameters.Add("@Data_EBIT", SqlDbType.Decimal).Value = _i.EBIT;
                    _cmd.Parameters.Add("@Data_Enterprise_Value", SqlDbType.Decimal).Value = _i.Enterprise_Value;
                    _cmd.Parameters.Add("@Data_Par_Amount", SqlDbType.Decimal).Value = _i.Par_Amount;
                    _cmd.Parameters.Add("@Data_Par_Value", SqlDbType.Decimal).Value = _i.Par_Value;
                    _cmd.Parameters.Add("@Data_Coupon", SqlDbType.Decimal).Value = _i.Coupon;
                    _cmd.Parameters.Add("@Data_Redemption_Date", SqlDbType.DateTime).Value = _i.Redemption_Date;
                    _cmd.Parameters.Add("@Data_Accrued_Interest", SqlDbType.Decimal).Value = _i.Accrued_Interest;
                    #endregion
                    _cmd.ExecuteNonQuery();
                    connection.Close();
                }
                catch (Exception e)
                {
                    System.Windows.Forms.MessageBox.Show(e.Message);
                }
            }
        }
        public void Run()
        {
            try
            {
                List<BBInstrument> _completed = new List<BBInstrument>();
                _requested = RequestOutdatedInstrumentList();
                BloombergRequest _bloombergData = new BloombergRequest(_requested);
                foreach(BBInstrument i in _bloombergData.Results)
                {
                    
                }
                SaveUpdatedInstruments(_completed);
            }
            catch (Exception e)
            {
                System.Windows.Forms.MessageBox.Show(e.Message);
            }
        }
    }
}
