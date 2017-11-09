using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PriceUpdate
{
    [Flags]
    public enum IntradayPrice
    {
        Intraday = 1, Opening = 2, Closing = 4
    }
    public class ArrivalPrice
    {
        public int ID { get; set; }
        public int DealID { get; set; }
        public int InstrumentID { get; set; }
        public string ID_DataFeed { get; set; }
        public decimal Price { get; set; }
        public DateTime PriceDateTime { get; set; }
        public IntradayPrice PriceFlag { get; set; }


        public ArrivalPrice(DataRow dr)
        {
            this.ID = Convert.ToInt32(dr["ID"]);
            this.DealID = Convert.ToInt32(dr["DealID"]);
            this.ID_DataFeed = dr["ID_DataFeed"].ToString();
            this.PriceDateTime = Convert.ToDateTime(dr["PriceDateTime"]);
            this.Price = createPrice();
        }

        private decimal createPrice()
        {
            this.PriceFlag = IntradayPrice.Opening;
            throw new NotImplementedException();
        }
        public void Update(SqlConnection conn)
        {
            conn.Open();
            string _storedProcedure = "sp_PMInstrument_InsertArrivalPrice";
            try
            {
                SqlCommand _cmd = new SqlCommand(_storedProcedure, conn);
                #region DB Parameters
                _cmd.Parameters.Add("@ID_MPM", SqlDbType.Int).Value = InstrumentID;
                _cmd.Parameters.Add("@ID_Date", SqlDbType.DateTime).Value = PriceDateTime;
                _cmd.Parameters.Add("@Data_Price", SqlDbType.Decimal).Value = Price;
                _cmd.Parameters.Add("@Data_Price", SqlDbType.Int).Value = PriceFlag;
                #endregion
                _cmd.ExecuteNonQuery();
            }
            catch (Exception e)
            {
                System.Windows.Forms.MessageBox.Show(e.Message);
            }
            finally
            {
                conn.Close();
            }
        }
    }
}
