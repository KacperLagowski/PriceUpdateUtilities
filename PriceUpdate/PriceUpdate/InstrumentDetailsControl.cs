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

namespace PriceUpdate
{
    public partial class InstrumentDetailsControl : UserControl
    {
        public BBInstrument DataSource { get; set; }
        public InstrumentDetailsControl()
        {
            InitializeComponent();
            instrumentDetailsPropertyGrid.SelectedObject = DataSource;
        }
    }
}
