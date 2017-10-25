using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PriceUpdate
{
    public partial class BloombergUpdateControl : UserControl
    {
        public BloombergUpdateControl()
        {
            InitializeComponent();
            CircleProgressBarCs.CircleProgressBar progressBar = new CircleProgressBarCs.CircleProgressBar();
            progressBar.Location = new Point(500, 500);
        }
    }
}
