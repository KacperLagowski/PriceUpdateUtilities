using System;
using System.Collections.Generic;
using System.Data;
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
        public int ID_MPM { get; set; }
        public string ID_DataFeed { get; set; }
        public string BloombergID { get; set; }
        public decimal Price { get; set; }
        public DateTime PriceDateTime { get; set; }
        public IntradayPrice IntradayFlag { get; set; }


        public ArrivalPrice(DataRow dr)
        {
            this.ID = Convert.ToInt32(dr["ID"]);
            this.ID_MPM = Convert.ToInt32(dr["ID_MPM"]);
            this.ID_DataFeed = dr["ID_DataFeed"].ToString();
            this.BloombergID = dr["Data_BloombergID"].ToString();
            this.PriceDateTime = Convert.ToDateTime(dr["PriceDateTime"]);
            this.IntradayFlag = (IntradayPrice) Convert.ToInt32(dr["IntradayFlag"]);
        }

        public void CreatePrice()
        {
            
        }
    }
}
