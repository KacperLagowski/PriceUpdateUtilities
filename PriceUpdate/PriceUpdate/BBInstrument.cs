using Bloomberglp.Blpapi;
using PriceUpdateProgram;
using System;
using System.Collections.Generic;
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
        public int ID { get; set; }
        public int ID_MPM { get; set; }
        public string ID_DataFeed { get; set; }
        public DateTime ID_Date { get; set; }
        public string UserID { get { return System.Security.Principal.WindowsIdentity.GetCurrent().Name; } }
        public string Sys_Note_System { get; set; }
        public string Sys_Note_User { get; set; }
        public int Sys_DataFeed_Type { get; set; }
        //
        public int Sys_End { get; set; }
        //ID_BB_UNIQUE
        public string BloombergID { get; set; }
        //ISIN
        public string ISIN { get; set; }

        //TICKER
        public string Ticker { get; set; }
        //SEDOL
        public string Sedol1 { get; set; }
        //ID_COMMON
        public string Common { get; set; }
        public string Other { get; set; }
        //
        public string Type { get; set; }
        //To check
        public int AssetType { get; set; }
        //EXCH_CODE
        public string Exchange { get; set; }
        //To check
        public string MIC { get; set; }
        //NAME
        public string Name { get; set; }
        public string Name_Midas_Short { get; set; }
        public string Name_Midas_Long { get; set; }
        public decimal Price { get; set; }
        //PX_MID
        public decimal Price_Mid { get; set; }
        //PX_BID
        public decimal Price_Bid { get; set; }
        //PX_ASK
        public decimal Price_Ask { get; set; }
        //PX_LAST
        public decimal Price_Last { get; set; }
        public decimal Price_Net_Asset_Value { get; set; }
        public string Price_Default { get; set; }
        public string Price_Currency_ID { get; set; }
        public decimal Price_Factor { get; set; }
        public decimal Div_Gross { get; set; }
        //DVD_CRNCY
        public string Div_Currency_ID { get; set; }
        public decimal Div_Factor { get; set; }
        public DateTime Div_Ex_Date { get; set; }
        //REL_1M
        public decimal Rel_Perf_1M { get; set; }
        //REL_3M
        public decimal Rel_Perf_3M { get; set; }
        //REL_6M
        public decimal Rel_Perf_6M { get; set; }
        //REL_1YR
        public decimal Rel_Perf_12M { get; set; }
        //REL_MTD
        public decimal Rel_Perf_MTD { get; set; }
        //REL_QTD
        public decimal Rel_Perf_QTD { get; set; }
        //REL_YTD
        public decimal Rel_Perf_YTD { get; set; }
        //IS_EPS
        public decimal Earnings_Per_Share { get; set; }
        //PX_TO_BOOK_RATIO
        public decimal Price_To_Book { get; set; }
        //BS_CORE_CAP_RATIO
        public decimal Tier_1_Ratio { get; set; }
        //CF_FREE_CASH_FLOW
        public decimal Free_Cash_Flow { get; set; }
        //EBITDA
        public decimal EBITDA { get; set; }
        //EBIT
        public decimal EBIT { get; set; }
        //ENTERPRISE_VALUE
        public decimal Enterprise_Value { get; set; }
        //PAR_AMT
        public decimal Par_Amount { get; set; }
        //BS_PAR_VAL
        public decimal Par_Value { get; set; }
        //CPN
        public decimal Coupon { get; set; }
        public DateTime Redemption_Date { get; set; }
        public decimal Accrued_Interest { get; set; }
        public RestrictionFlagEnum Data_Restriction_Flag { get; set; }
        public decimal Data_Equity_Share_out { get; set; }
        public bool BloombergUpdate { get; private set; }
        public string LEI { get; set; }
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
                        LEI = e.GetValueAsString();

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
            //this.LEI = row["Data_LEI"].ToString();
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
            //this.Data_Equity_Share_out = Convert.ToDecimal(row["Data_Equity_Sh_Out"]);
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
            _cmd.Parameters.Add("@Data_LEI", SqlDbType.NVarChar, 20).Value = LEI;
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
    }
}


