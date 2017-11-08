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
        public int DealID { get; set; }
        public int InstrumentID { get; set; }
        public string ID_DataFeed { get; set; }
        public decimal Price { get; set; }
        public DateTime PriceDateTime { get; set; }
        public IntradayPrice IntradayFlag { get; set; }


        public ArrivalPrice(DataRow dr)
        {
            this.ID = Convert.ToInt32(dr["ID"]);
            this.DealID = Convert.ToInt32(dr["DealID"]);
            this.PriceDateTime = Convert.ToDateTime(dr["PriceDateTime"]);
        }

        public void CreatePrice()
        {
            
        }
    }
}
