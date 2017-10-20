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
        public static SqlConnection connection;
        private static List<BBInstrument> _requested = new List<BBInstrument>();
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

       
        public void Run()
        {
            try
            {
                createConnection("");
                List<BBInstrument> _completed = new List<BBInstrument>();
                _requested = RequestOutdatedInstrumentList();
                BloombergRequest _bloombergData = new BloombergRequest(_requested);
                _completed = _bloombergData.Results;
                foreach (BBInstrument i in _completed)
                {
                    i.Update(connection);
                }
            }
            catch (Exception e)
            {
                System.Windows.Forms.MessageBox.Show(e.Message);
            }
        }
    }
}
