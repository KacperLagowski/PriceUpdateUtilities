using Bloomberglp.Blpapi;
using PriceUpdateProgram;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Text;

namespace RefDataExample
{
    public enum RestrictionFlagEnum
    {
        Prohibited = 1, Aggregated = 2, TakeoverPanel = 4
    }
    public class BBInstrument
    {
        #region props
        [Description("Unique database ID"), ReadOnly(true)]
        public int ID { get; set; }

        [Description("ID of this instrument in PM"), ReadOnly(true)]
        public int ID_MPM { get; set; }

        [Description("A unique field that identifies this stock in Bloomberg data search"), ReadOnly(false)]
        public string ID_DataFeed { get; set; }

        [Description("Represents the date when the stock was last manipulated"), ReadOnly(true)]
        public DateTime ID_Date { get; set; }

        [Description("ID number of the user"), ReadOnly(true)]
        public string UserID { get { return System.Security.Principal.WindowsIdentity.GetCurrent().Name; } }

        [Description("System Note"), ReadOnly(true)]
        public string Sys_Note_System { get; set; }

        [Description("User Note"), ReadOnly(true)]
        public string Sys_Note_User { get; set; }

        [Description("Data Feed Type"), ReadOnly(true)]
        public int Sys_DataFeed_Type { get; set; }

        [Description("End"), ReadOnly(true)]
        public int Sys_End { get; set; }

        [Description("ID of the stock in Bloomberg"), ReadOnly(true)]
        public string BloombergID { get; set; }
        [Description("ISIN identifier"), ReadOnly(true)]
        public string ISIN { get; set; }
        [Description("This stock's Ticker"), ReadOnly(true)]
        public string Ticker { get; set; }
        [Description("The Sedol of this security"), ReadOnly(true)]
        public string Sedol1 { get; set; }
        [Description("Common"), ReadOnly(false)]
        public string Common { get; set; }
        [Description("Other"), ReadOnly(false)]
        public string Other { get; set; }
        [Description("The type of the asset"), ReadOnly(false)]
        public string Type { get; set; }
        [Description("The type of the asset"), ReadOnly(false)]
        public int AssetType { get; set; }
        [Description("Exchange"), ReadOnly(false)]
        public string Exchange { get; set; }
        [Description("MIC"), ReadOnly(false)]
        public string MIC { get; set; }
        [Description("The name of the stock"), ReadOnly(false)]
        public string Name { get; set; }
        [Description("Short name in PM"), ReadOnly(false)]
        public string Name_Midas_Short { get; set; }
        [Description("Long name in PM"), ReadOnly(false)]
        public string Name_Midas_Long { get; set; }
        [Description("General Price field"), ReadOnly(false)]
        public decimal Price { get; set; }
        [Description("Part of the price valuation"), ReadOnly(false)]
        public decimal Price_Mid { get; set; }
        [Description("Part of the price valuation"), ReadOnly(false)]
        public decimal Price_Bid { get; set; }
        [Description("Part of the price valuation"), ReadOnly(false)]
        public decimal Price_Ask { get; set; }
        [Description("Part of the price valuation"), ReadOnly(false)]
        public decimal Price_Last { get; set; }
        [Description("Part of the price valuation"), ReadOnly(false)]
        public decimal Price_Net_Asset_Value { get; set; }
        [Description("Part of the price valuation"), ReadOnly(false)]
        public string Price_Default { get; set; }
        [Description("Price currency ID"), ReadOnly(false)]
        public string Price_Currency_ID { get; set; }
        [Description("Price factor"), ReadOnly(false)]
        public decimal Price_Factor { get; set; }
        [Description("Div gross"), ReadOnly(false)]
        public decimal Div_Gross { get; set; }
        [Description("Div currency ID"), ReadOnly(false)]
        public string Div_Currency_ID { get; set; }
        [Description("Div factor"), ReadOnly(false)]
        public decimal Div_Factor { get; set; }
        [Description("Div ex date"), ReadOnly(false)]
        public DateTime Div_Ex_Date { get; set; }
        [Description("Periodical relative performance"), ReadOnly(false)]
        public decimal Rel_Perf_1M { get; set; }
        [Description("Periodical relative performance"), ReadOnly(false)]
        public decimal Rel_Perf_3M { get; set; }
        [Description("Periodical relative performance"), ReadOnly(false)]
        public decimal Rel_Perf_6M { get; set; }
        [Description("Periodical relative performance"), ReadOnly(false)]
        public decimal Rel_Perf_12M { get; set; }
        [Description("Periodical relative performance"), ReadOnly(false)]
        public decimal Rel_Perf_MTD { get; set; }
        [Description("Periodical relative performance"), ReadOnly(false)]
        public decimal Rel_Perf_QTD { get; set; }
        [Description("Periodical relative performance"), ReadOnly(false)]
        public decimal Rel_Perf_YTD { get; set; }
        [Description("EPS"), ReadOnly(false)]
        public decimal Earnings_Per_Share { get; set; }
        [Description("Price to book"), ReadOnly(false)]
        public decimal Price_To_Book { get; set; }
        [Description("Tier 1 ratio"), ReadOnly(false)]
        public decimal Tier_1_Ratio { get; set; }
        [Description("Free cash flow of the security"), ReadOnly(false)]
        public decimal Free_Cash_Flow { get; set; }
        [Description("EBITDA"), ReadOnly(false)]
        public decimal EBITDA { get; set; }
        [Description("EBIT"), ReadOnly(false)]
        public decimal EBIT { get; set; }
        [Description("Enterprise value"), ReadOnly(false)]
        public decimal Enterprise_Value { get; set; }
        [Description("Par Amount"), ReadOnly(false)]
        public decimal Par_Amount { get; set; }
        [Description("Par Value"), ReadOnly(false)]
        public decimal Par_Value { get; set; }
        [Description("Coupon"), ReadOnly(false)]
        public decimal Coupon { get; set; }
        [Description("Redemption date"), ReadOnly(false)]
        public DateTime Redemption_Date { get; set; }
        [Description("Accrued Interest"), ReadOnly(false)]
        public decimal Accrued_Interest { get; set; }
        [Description("Restriction flag"), ReadOnly(false)]
        public RestrictionFlagEnum Data_Restriction_Flag { get; set; }
        [Description("Equity Share Out"), ReadOnly(false)]
        public decimal Data_Equity_Share_out { get; set; }
        public bool BloombergUpdate { get; private set; }
        [Description("Legal Entity Identifier"), ReadOnly(false)]
        public string Data_LEI { get; set; }
        [Description("ISO10962 6 digits code"), ReadOnly(false)]
        public string Data_CFI { get; set; }
        #endregion

        public void OverrideValues(List<Element> BloombergInstruments)
        {
                foreach(Element e in BloombergInstruments)
                switch (e.Name.ToString())
                {
                    case "ID_BB_Unique":
                        BloombergID = e.GetValueAsString();
                        
                        break;
                    case "ID_ISIN":
                        ISIN = e.GetValueAsString();
                        
                        break;
                    case "TICKER":
                        Ticker = e.GetValueAsString();
                        
                        break;
                    case "ID_SEDOL1":
                        Sedol1 = e.GetValueAsString();
                        
                        break;
                    case "ID_COMMON":
                        Common = e.GetValueAsString();

                        break;
                    case "LEGAL_ENTITY_IDENTIFIER":
                        Data_LEI = e.GetValueAsString();

                        break;
                    case "EXCH_CODE":
                        Exchange = e.GetValueAsString();
                        
                        break;
                    case "ID_MIC_PRIM_EXCH":
                        MIC = e.GetValueAsString();
                        
                        break;
                    case "Name":
                        Name = e.GetValueAsString();
                        
                        break;
                    case "PX_MID":
                        Price_Mid = Convert.ToDecimal(e.GetValue());
                        
                        break;
                    case "PX_BID":
                        Price_Bid = Convert.ToDecimal(e.GetValue());
                        
                        break;
                    case "PX_ASK":
                        Price_Ask = Convert.ToDecimal(e.GetValue());
                        
                        break;
                    case "PX_LAST":
                        Price_Last = Convert.ToDecimal(e.GetValue());
                        
                        break;
                    case "DVD_CRNCY":
                        Div_Currency_ID = e.GetValueAsString();
                        
                        break;
                    case "REL_1M":
                        Rel_Perf_1M = Convert.ToDecimal(e.GetValue());
                        
                        break;
                    case "REL_3M":
                        Rel_Perf_3M = Convert.ToDecimal(e.GetValue());
                        
                        break;
                    case "REL_6M":
                        Rel_Perf_6M = Convert.ToDecimal(e.GetValue());
                        
                        break;
                    case "REL_1YR":
                        Rel_Perf_12M = Convert.ToDecimal(e.GetValue());
                        
                        break;
                    case "REL_MTD":
                        Rel_Perf_MTD = Convert.ToDecimal(e.GetValue());
                        
                        break;
                    case "REL_QTD":
                        Rel_Perf_QTD = Convert.ToDecimal(e.GetValue());
                        
                        break;
                    case "REL_YTD":
                        Rel_Perf_YTD = Convert.ToDecimal(e.GetValue());
                        
                        break;
                    case "IS_IPS":
                        Earnings_Per_Share = Convert.ToDecimal(e.GetValue());
                        
                        break;
                    case "PX_TO_BOOK_RATIO":
                        Price_To_Book = Convert.ToDecimal(e.GetValue());
                        
                        break;
                    case "BS_CORE_CAP_RATIO":
                        Tier_1_Ratio = Convert.ToDecimal(e.GetValue());
                        
                        break;
                    case "CF_FREE_CASH_FLOW":
                        Free_Cash_Flow = Convert.ToDecimal(e.GetValue());
                        
                        break;
                    case "EBITDA":
                        EBITDA = Convert.ToDecimal(e.GetValue());
                        
                        break;
                    case "EBIT":
                        EBIT = e.GetValueAsInt32();
                        
                        break;
                    case "ENTERPRISE_VALUE":
                        Enterprise_Value = Convert.ToDecimal(e.GetValue());
                        
                        break;
                    case "PAR_AMT":
                        Par_Amount = Convert.ToDecimal(e.GetValue());
                        
                        break;
                    case "BS_PAR_VAL":
                        Par_Value = Convert.ToDecimal(e.GetValue());
                        
                        break;
                    case "CPN":
                        Coupon = Convert.ToDecimal(e.GetValue());
                        
                        break;
                    case "EQY_SH_OUT":
                        Data_Equity_Share_out = Convert.ToDecimal(e.GetValue());
                        break;
                    case "CFI_CODE":
                        Data_CFI = e.GetValue().ToString();
                        break;
                    default:
                        break;
                }
            BloombergUpdate = true;
        }

        public BBInstrument(DataRow row)
        {
            this.BloombergUpdate = false;

            this.ID = Convert.ToInt32(row["ID"]);
            this.ID_MPM = Convert.ToInt32(row["ID_MPM"]);
            this.ID_DataFeed = row["ID_DataFeed"].ToString();
            this.ID_Date = Convert.ToDateTime(row["ID_Date"]);
            this.Sys_DataFeed_Type = Convert.ToInt32(row["Sys_DataFeed_Type"]);
            this.Sys_Note_User = row["Sys_Note_User"].ToString();
            this.Sys_Note_System = row["Sys_Note_System"].ToString();
            this.Sys_End = Convert.ToInt32(row["Sys_End"]);
            this.BloombergID = row["Data_BloombergID"].ToString();
            this.ISIN = row["Data_ISIN"].ToString();
            this.Ticker = row["Data_Ticker"].ToString();
            this.Sedol1 = row["Data_Sedol1"].ToString();
            this.Common = row["Data_Common"].ToString();
            this.Data_LEI = row["Data_LEI"].ToString();
            this.Data_CFI = row["Data_CFI"].ToString();
            this.Other = row["Data_Other"].ToString();
            this.Type = row["Data_Type"].ToString();
            this.AssetType = Convert.ToInt32(row["Data_AssetType"]);
            this.Exchange = row["Data_Exchange"].ToString();
            this.MIC = row["Data_MIC"].ToString();
            this.Name = row["Data_Name"].ToString();
            this.Name_Midas_Short = row["Data_Name_Midas_Short"].ToString();
            this.Name_Midas_Long = row["Data_Name_Midas_Long"].ToString();
            this.Price = Convert.ToDecimal(row["Data_Price"]);
            this.Price_Mid = Convert.ToDecimal(row["Data_Price_Mid"]);
            this.Price_Bid = Convert.ToDecimal(row["Data_Price_Bid"]);
            this.Price_Ask = Convert.ToDecimal(row["Data_Price_Ask"]);
            this.Price_Last = Convert.ToDecimal(row["Data_Price_Last"]);
            this.Price_Net_Asset_Value = Convert.ToDecimal(row["Data_Price_Net_Asset_Value"]);
            this.Price_Default = row["Data_Price_Default"].ToString();
            this.Price_Currency_ID = row["Data_Price_Currency_ID"].ToString();
            this.Price_Factor = Convert.ToDecimal(row["Data_Price_Factor"]);
            this.Div_Gross = Convert.ToDecimal(row["Data_Div_Gross"]);
            this.Div_Currency_ID = row["Data_Div_Currency_ID"].ToString();
            this.Div_Factor = Convert.ToDecimal(row["Data_Div_Factor"]);
            this.Div_Ex_Date = Convert.ToDateTime(row["Data_Div_Ex_Date"]);
            this.Rel_Perf_1M = Convert.ToDecimal(row["Data_Rel_Perf_1M"]);
            this.Rel_Perf_3M = Convert.ToDecimal(row["Data_Rel_Perf_3M"]);
            this.Rel_Perf_6M = Convert.ToDecimal(row["Data_Rel_Perf_6M"]);
            this.Rel_Perf_12M = Convert.ToDecimal(row["Data_Rel_Perf_12M"]);
            this.Rel_Perf_MTD = Convert.ToDecimal(row["Data_Rel_Perf_MTD"]);
            this.Rel_Perf_QTD = Convert.ToDecimal(row["Data_Rel_Perf_QTD"]);
            this.Rel_Perf_YTD = Convert.ToDecimal(row["Data_Rel_Perf_YTD"]);
            this.Earnings_Per_Share = Convert.ToDecimal(row["Data_Earnings_Per_Share"]);
            this.Price_To_Book = Convert.ToDecimal(row["Data_Price_To_Book"]);
            this.Tier_1_Ratio = Convert.ToDecimal(row["Data_Tier_1_Ratio"]);
            this.Free_Cash_Flow = Convert.ToDecimal(row["Data_Free_Cash_Flow"]);
            this.EBITDA = Convert.ToDecimal(row["Data_EBITDA"]);
            this.EBIT = Convert.ToDecimal(row["Data_EBIT"]);
            this.Enterprise_Value = Convert.ToDecimal(row["Data_Enterprise_Value"]);
            this.Par_Amount = Convert.ToDecimal(row["Data_Par_Amount"]);
            this.Par_Value = Convert.ToDecimal(row["Data_Par_Value"]);
            this.Coupon = Convert.ToDecimal(row["Data_Coupon"]);
            this.Redemption_Date = Convert.ToDateTime(row["Data_Redemption_Date"]);
            this.Accrued_Interest = Convert.ToDecimal(row["Data_Accrued_Interest"]);
            //this.Data_Restriction_Flag = (RestrictionFlagEnum)(Convert.ToInt32(row["Data_Restriction_Flag"]));
            this.Data_Equity_Share_out = Convert.ToDecimal(row["Data_Equity_Sh_Out"]);
        }

        public void Update(SqlConnection conn)
        {
            //conn.Open();
            string _storedProcedure = "sp_PMInstrumentUpdate";
            SqlCommand _cmd = new SqlCommand(_storedProcedure, conn);
            #region DB Parameters

            _cmd.CommandType = CommandType.StoredProcedure;
            _cmd.Parameters.Add("@ID", SqlDbType.BigInt).Value = ID;
            _cmd.Parameters.Add("@ID_MPM", SqlDbType.Int).Value = ID_MPM;
            _cmd.Parameters.Add("@ID_Date", SqlDbType.DateTime).Value = ID_Date;
            _cmd.Parameters.Add("@ID_DataFeed", SqlDbType.NVarChar, 50).Value = ID_DataFeed;
            _cmd.Parameters.Add("@Sys_Note_System", SqlDbType.NVarChar, 255).Value = Sys_Note_System;
            _cmd.Parameters.Add("@Sys_Note_User", SqlDbType.NVarChar, 255).Value = Sys_Note_User;
            _cmd.Parameters.Add("@Sys_UserID", SqlDbType.NVarChar, 50).Value = UserID;
            _cmd.Parameters.Add("@Sys_DataFeed_Type", SqlDbType.Int).Value = Sys_DataFeed_Type;
            _cmd.Parameters.Add("@Sys_End", SqlDbType.Bit).Value = Sys_End;
            _cmd.Parameters.Add("@Data_BloombergID", SqlDbType.NVarChar, 50).Value = BloombergID;
            _cmd.Parameters.Add("@Data_ISIN", SqlDbType.NVarChar, 50).Value = ISIN;
            _cmd.Parameters.Add("@Data_Ticker", SqlDbType.NVarChar, 50).Value = Ticker;
            _cmd.Parameters.Add("@Data_Sedol1", SqlDbType.NVarChar, 50).Value = Sedol1;
            _cmd.Parameters.Add("@Data_Common", SqlDbType.NVarChar, 50).Value = Common;
            _cmd.Parameters.Add("@Data_LEI", SqlDbType.NVarChar, 20).Value = Data_LEI;
            _cmd.Parameters.Add("@Data_CFI", SqlDbType.NVarChar, 6).Value = Data_CFI;
            _cmd.Parameters.Add("@Data_Other", SqlDbType.NVarChar, 50).Value = Other;
            _cmd.Parameters.Add("@Data_Type", SqlDbType.NVarChar, 50).Value = Type;
            _cmd.Parameters.Add("@Data_Exchange", SqlDbType.NVarChar, 50).Value = Exchange;
            _cmd.Parameters.Add("@Data_MIC", SqlDbType.NVarChar, 10).Value = MIC;
            _cmd.Parameters.Add("@Data_Name", SqlDbType.NVarChar, 255).Value = Name;
            _cmd.Parameters.Add("@Data_Name_Midas_Short", SqlDbType.NVarChar, 40).Value = Name_Midas_Short;
            _cmd.Parameters.Add("@Data_Name_Midas_Long", SqlDbType.NVarChar, 80).Value = Name_Midas_Long;
            _cmd.Parameters.Add("@Data_Price", SqlDbType.Decimal).Value = Price;
            _cmd.Parameters.Add("@Data_Price_Mid", SqlDbType.Decimal).Value = Price_Mid;
            _cmd.Parameters.Add("@Data_Price_Bid", SqlDbType.Decimal).Value = Price_Bid;
            _cmd.Parameters.Add("@Data_Price_Ask", SqlDbType.Decimal).Value = Price_Ask;
            _cmd.Parameters.Add("@Data_Price_Last", SqlDbType.Decimal).Value = Price_Last;
            _cmd.Parameters.Add("@Data_Price_Net_Asset_Value", SqlDbType.Decimal).Value = Price_Net_Asset_Value;
            _cmd.Parameters.Add("@Data_Price_Default", SqlDbType.NVarChar, 50).Value = Price_Default;
            _cmd.Parameters.Add("@Data_Price_Currency_ID", SqlDbType.NVarChar, 50).Value = Price_Currency_ID;
            _cmd.Parameters.Add("@Data_Price_Factor", SqlDbType.Decimal).Value = Price_Factor;
            _cmd.Parameters.Add("@Data_Div_Gross", SqlDbType.Decimal).Value = Div_Gross;
            _cmd.Parameters.Add("@Data_Div_Factor", SqlDbType.Decimal).Value = Div_Factor;
            _cmd.Parameters.Add("@Data_Div_Currency_ID", SqlDbType.NVarChar, 50).Value = Div_Currency_ID;
            _cmd.Parameters.Add("@Data_Div_Ex_Date", SqlDbType.DateTime).Value = Div_Ex_Date;
            
            _cmd.Parameters.Add("@Data_Rel_Perf_1M", SqlDbType.Decimal).Value = Rel_Perf_1M;
            _cmd.Parameters.Add("@Data_Rel_Perf_3M", SqlDbType.Decimal).Value = Rel_Perf_3M;
            _cmd.Parameters.Add("@Data_Rel_Perf_6M", SqlDbType.Decimal).Value = Rel_Perf_6M;
            _cmd.Parameters.Add("@Data_Rel_Perf_12M", SqlDbType.Decimal).Value = Rel_Perf_12M;
            _cmd.Parameters.Add("@Data_Rel_Perf_MTD", SqlDbType.Decimal).Value = Rel_Perf_MTD;
            _cmd.Parameters.Add("@Data_Rel_Perf_QTD", SqlDbType.Decimal).Value = Rel_Perf_QTD;
            _cmd.Parameters.Add("@Data_Rel_Perf_YTD", SqlDbType.Decimal).Value = Rel_Perf_YTD;
            
            _cmd.Parameters.Add("@Data_Earnings_Per_Share", SqlDbType.Decimal).Value = Earnings_Per_Share;
            _cmd.Parameters.Add("@Data_Price_To_Book", SqlDbType.Decimal).Value = Price_To_Book;
            _cmd.Parameters.Add("@Data_Tier_1_Ratio", SqlDbType.Decimal).Value = Tier_1_Ratio;
            _cmd.Parameters.Add("@Data_Free_Cash_Flow", SqlDbType.Decimal).Value = Free_Cash_Flow;
            _cmd.Parameters.Add("@Data_EBITDA", SqlDbType.Decimal).Value = EBITDA;
            _cmd.Parameters.Add("@Data_EBIT", SqlDbType.Decimal).Value = EBIT;
            
            _cmd.Parameters.Add("@Data_Enterprise_Value", SqlDbType.Decimal).Value = Enterprise_Value;
            _cmd.Parameters.Add("@Data_Par_Amount", SqlDbType.Decimal).Value = Par_Amount;
            _cmd.Parameters.Add("@Data_Par_Value", SqlDbType.Decimal).Value = Par_Value;
            _cmd.Parameters.Add("@Data_Coupon", SqlDbType.Decimal).Value = Coupon;
            _cmd.Parameters.Add("@Data_Redemption_Date", SqlDbType.DateTime).Value = Redemption_Date;
            _cmd.Parameters.Add("@Data_Accrued_Interest", SqlDbType.Decimal).Value = Accrued_Interest;
            _cmd.Parameters.Add("@Data_Equity_Sh_Out", SqlDbType.Decimal).Value = Data_Equity_Share_out;
            #endregion
            _cmd.ExecuteNonQuery();
        }

        public void GetData_Price()
        {
            switch(this.Price_Default)
            {
                case "Data_Price_Mid":
                    this.Price = Price_Mid;
                    break;
                case "Data_Price_Bid":
                    this.Price = Price_Bid;
                    break;
                case "Data_Price_Ask":
                    this.Price = Price_Ask;
                    break;
                case "Data_Price_Last":
                    this.Price = Price_Last;
                    break;
                case "Data_Price_Net_Asset_Value":
                    this.Price = Price_Net_Asset_Value;
                    break;
                default:
                    if (this.Price_Mid != 0)
                        Price = Price_Mid;
                    else if (this.Price_Bid != 0 && Price_Ask != 0)
                        Price = (Price_Bid + Price_Ask) / 2;
                    else if (this.Price_Bid != 0)
                        Price = Price_Bid;
                    else if (this.Price_Ask != 0)
                        Price = Price_Ask;
                    else if (this.Price_Net_Asset_Value != 0)
                        Price = Price_Net_Asset_Value;
                    else
                        Price = Price_Last;
                    break;
            }
        }
    }
}


