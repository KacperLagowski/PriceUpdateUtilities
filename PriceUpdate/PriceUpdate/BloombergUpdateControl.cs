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
using System.Timers;
using tmr = System.Timers;

namespace PriceUpdate
{
    public partial class BloombergUpdateControl : UserControl
    {
        public string ProgressLabelText { get; set; }
        public BloombergUpdateControl()
        {
            InitializeComponent();
            progressLabel.Text = ProgressLabelText;
            BloombergProcessor bp = new BloombergProcessor();
            bp.StartCounting();
        }

        private void Bh_ProgressUpdated(object sender, EventArgs e)
        {
            progressLabel.Text = sender.ToString();
        }

        private void updateButton_Click(object sender, EventArgs e)
        {
            this.updateButton.Enabled = false;
            BloombergProcessor bh = new BloombergProcessor();
            bh.ProgressUpdated += Bh_ProgressUpdated;
            bh.RunFullPriceUpdate();
            this.updateButton.Enabled = true;
        }

        private void intradayButton_Click_1(object sender, EventArgs e)
        {
            this.updateButton.Enabled = false;
            BloombergProcessor bh = new BloombergProcessor();
            bh.RunIntradayPriceUpdate();
            this.updateButton.Enabled = true;
        }

        private void miniButton_Click(object sender, EventArgs e)
        {
            this.updateButton.Enabled = false;
            BloombergProcessor bh = new BloombergProcessor();
            bh.ProgressUpdated += Bh_ProgressUpdated;
            bh.RunMiniPriceUpdate();
            this.updateButton.Enabled = true;
        }
    }
}
