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
    public class BloombergHelper
    {
        public static SqlConnection connection;
        public int Percentage { get; set; }
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

       
        public void Run()
        {
            Percentage = 0;
            List<BBInstrument> _requested = new List<BBInstrument>();
            List<BBInstrument> _inProgress = new List<BBInstrument>();
            List<BBInstrument> _completed = new List<BBInstrument>();
            try
            {
                createConnection("DATA SOURCE=vmSQL02;Initial Catalog=MidasPM_CCF;Integrated Security=SSPI;Connect Timeout=120;");
                _requested = RequestOutdatedInstrumentList();
                
                for (int i = 0; i < _requested.Count; i++)
                {
                    _inProgress.Add(_requested[i]);
                    //BloombergRequest _bloombergData = new BloombergRequest(_inProgress[0]);
                    //_completed.Add(_bloombergData.Result);
                    //Percentage = (int)((double)(100 * _completed.Count) / _requested.Count);
                    // _inProgress.RemoveAt(0);
                }
            }
            catch (Exception e)
            {
                System.Windows.Forms.MessageBox.Show(e.Message);
            }
            finally
            {
                connection.Close();
            }
        }
    }
}
