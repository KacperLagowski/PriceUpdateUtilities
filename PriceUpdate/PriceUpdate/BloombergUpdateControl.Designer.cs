namespace PriceUpdate
{
    partial class BloombergUpdateControl
    {
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(BloombergUpdateControl));
            this.titleLabel = new System.Windows.Forms.Label();
            this.randomLabel = new System.Windows.Forms.Label();
            this.utilitiesToolStrip = new System.Windows.Forms.ToolStrip();
            this.updateButton = new System.Windows.Forms.ToolStripButton();
            this.intradayButton = new System.Windows.Forms.ToolStripButton();
            this.miniButton = new System.Windows.Forms.ToolStripButton();
            this.progressLabel = new System.Windows.Forms.ToolStripLabel();
            this.infoLabel1 = new System.Windows.Forms.ToolStripLabel();
            this.infoLabel2 = new System.Windows.Forms.ToolStripLabel();
            this.infoLabel3 = new System.Windows.Forms.ToolStripLabel();
            this.utilitiesToolStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // titleLabel
            // 
            this.titleLabel.AutoSize = true;
            this.titleLabel.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.titleLabel.Location = new System.Drawing.Point(3, 0);
            this.titleLabel.Name = "titleLabel";
            this.titleLabel.Size = new System.Drawing.Size(170, 15);
            this.titleLabel.TabIndex = 4;
            this.titleLabel.Text = "Update Prices from Bloomberg";
            // 
            // randomLabel
            // 
            this.randomLabel.AutoSize = true;
            this.randomLabel.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.randomLabel.Location = new System.Drawing.Point(6, 176);
            this.randomLabel.Name = "randomLabel";
            this.randomLabel.Size = new System.Drawing.Size(0, 21);
            this.randomLabel.TabIndex = 7;
            // 
            // utilitiesToolStrip
            // 
            this.utilitiesToolStrip.Dock = System.Windows.Forms.DockStyle.Fill;
            this.utilitiesToolStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.updateButton,
            this.infoLabel1,
            this.intradayButton,
            this.infoLabel2,
            this.miniButton,
            this.infoLabel3,
            this.progressLabel});
            this.utilitiesToolStrip.Location = new System.Drawing.Point(0, 0);
            this.utilitiesToolStrip.Name = "utilitiesToolStrip";
            this.utilitiesToolStrip.Size = new System.Drawing.Size(1000, 70);
            this.utilitiesToolStrip.TabIndex = 16;
            // 
            // updateButton
            // 
            this.updateButton.AutoSize = false;
            this.updateButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.updateButton.Image = ((System.Drawing.Image)(resources.GetObject("updateButton.Image")));
            this.updateButton.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.updateButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.updateButton.Name = "updateButton";
            this.updateButton.Size = new System.Drawing.Size(67, 67);
            this.updateButton.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.updateButton.Click += new System.EventHandler(this.updateButton_Click);
            // 
            // intradayButton
            // 
            this.intradayButton.AutoSize = false;
            this.intradayButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.intradayButton.Image = ((System.Drawing.Image)(resources.GetObject("intradayButton.Image")));
            this.intradayButton.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.intradayButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.intradayButton.Name = "intradayButton";
            this.intradayButton.Size = new System.Drawing.Size(67, 67);
            this.intradayButton.Click += new System.EventHandler(this.intradayButton_Click_1);
            // 
            // miniButton
            // 
            this.miniButton.AutoSize = false;
            this.miniButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.miniButton.Image = ((System.Drawing.Image)(resources.GetObject("miniButton.Image")));
            this.miniButton.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.miniButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.miniButton.Name = "miniButton";
            this.miniButton.Size = new System.Drawing.Size(67, 67);
            this.miniButton.Click += new System.EventHandler(this.miniButton_Click);
            // 
            // progressLabel
            // 
            this.progressLabel.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.progressLabel.Name = "progressLabel";
            this.progressLabel.Size = new System.Drawing.Size(52, 67);
            this.progressLabel.Text = "Progress";
            // 
            // infoLabel1
            // 
            this.infoLabel1.Name = "infoLabel1";
            this.infoLabel1.Size = new System.Drawing.Size(141, 67);
            this.infoLabel1.Text = "Request Full Price Update";
            // 
            // infoLabel2
            // 
            this.infoLabel2.Name = "infoLabel2";
            this.infoLabel2.Size = new System.Drawing.Size(165, 67);
            this.infoLabel2.Text = "Request Intraday Price Update";
            // 
            // infoLabel3
            // 
            this.infoLabel3.Name = "infoLabel3";
            this.infoLabel3.Size = new System.Drawing.Size(146, 67);
            this.infoLabel3.Text = "Request Mini Price Update";
            // 
            // BloombergUpdateControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.utilitiesToolStrip);
            this.Controls.Add(this.randomLabel);
            this.Controls.Add(this.titleLabel);
            this.Name = "BloombergUpdateControl";
            this.Size = new System.Drawing.Size(1000, 70);
            this.utilitiesToolStrip.ResumeLayout(false);
            this.utilitiesToolStrip.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label titleLabel;
        private System.Windows.Forms.Label randomLabel;
        private System.Windows.Forms.ToolStrip utilitiesToolStrip;
        private System.Windows.Forms.ToolStripButton updateButton;
        private System.Windows.Forms.ToolStripButton intradayButton;
        private System.Windows.Forms.ToolStripButton miniButton;
        private System.Windows.Forms.ToolStripLabel progressLabel;
        private System.Windows.Forms.ToolStripLabel infoLabel1;
        private System.Windows.Forms.ToolStripLabel infoLabel2;
        private System.Windows.Forms.ToolStripLabel infoLabel3;
    }
}
