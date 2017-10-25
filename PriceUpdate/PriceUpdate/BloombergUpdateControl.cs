using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using PriceUpdateProgram;

namespace PriceUpdate
{
    public partial class BloombergUpdateControl : UserControl
    {
        public BloombergUpdateControl()
        {
            InitializeComponent();
            circleProgressBar.Num.Font = new Font("Arial", 60, FontStyle.Bold, GraphicsUnit.Pixel);
            circleProgressBar.Unit.Font = new Font("Arial", 30, FontStyle.Bold, GraphicsUnit.Pixel);
            circleProgressBar.Value = 1;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            BloombergHelper bh = new BloombergHelper();
            bh.Run();
            circleProgressBar.Value = bh.Percentage;
        }
    }
}
