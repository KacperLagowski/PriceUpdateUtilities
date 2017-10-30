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
        public event EventHandler ProgressUpdated;
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
                while (_requested.Count > 0)
                {
                    if (_requested.Count > 20)
                    {
                        var temporary = _requested.Take(20).ToList();
                        _inProgress.AddRange(temporary);
                        temporary.Clear();
                        _requested.RemoveAll(item => _inProgress.Contains(item));
                        //do work with _inProgress
                        BloombergRequest _bloombergData = new BloombergRequest(_inProgress);
                        _completed.AddRange(_bloombergData.Results);
                        _inProgress.Clear();
                    }
                    else
                    {
                        BloombergRequest _bloombergData = new BloombergRequest(_requested);
                        _completed.AddRange(_bloombergData.Results);
                        _requested.Clear();
                    }
                }

                //_completed = _bloombergData.Results;
                Percentage = (int)((double)(100 * _completed.Count) / _requested.Count);
                ProgressUpdated(Percentage, new EventArgs());
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
