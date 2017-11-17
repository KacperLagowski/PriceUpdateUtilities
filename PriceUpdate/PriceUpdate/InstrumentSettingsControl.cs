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
        public InstrumentSettingsControl()
        {
            InitializeComponent();
            List<BBInstrument> testList = new List<BBInstrument>();
            testList = BloombergProcessor.RequestOutdatedInstrumentList();
            instrumentDetailsControl1.DataSource = testList[1];
        }
    }
}
