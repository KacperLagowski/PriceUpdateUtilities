using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using RefDataExample;
using PriceUpdateProgram;

namespace PriceUpdate
{
    public partial class InstrumentSettingsControl : UserControl
    {
        List<BBInstrument> testList = new List<BBInstrument>();
        
        public InstrumentSettingsControl()
        {
            InitializeComponent();
            
        }

        private void instrumentDetailsControl1_Load(object sender, EventArgs e)
        {
            testList = BloombergProcessor.RequestOutdatedInstrumentList();
            instrumentDetailsControl1.InjectData(testList[2]);
        }
    }
}
