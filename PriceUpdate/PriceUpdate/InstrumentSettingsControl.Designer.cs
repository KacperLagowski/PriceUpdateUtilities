namespace PriceUpdate
{
    partial class InstrumentSettingsControl
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
            this.instrumentTabControl = new System.Windows.Forms.TabControl();
            this.errorViewTabPage = new System.Windows.Forms.TabPage();
            this.priceUpdateTabPage = new System.Windows.Forms.TabPage();
            this.instrumentViewTabPage = new System.Windows.Forms.TabPage();
            this.errorViewOLV = new BrightIdeasSoftware.ObjectListView();
            this.bloombergUpdateControl1 = new PriceUpdate.BloombergUpdateControl();
            this.instrumentTabControl.SuspendLayout();
            this.errorViewTabPage.SuspendLayout();
            this.priceUpdateTabPage.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorViewOLV)).BeginInit();
            this.SuspendLayout();
            // 
            // instrumentTabControl
            // 
            this.instrumentTabControl.Controls.Add(this.errorViewTabPage);
            this.instrumentTabControl.Controls.Add(this.priceUpdateTabPage);
            this.instrumentTabControl.Controls.Add(this.instrumentViewTabPage);
            this.instrumentTabControl.Location = new System.Drawing.Point(4, 4);
            this.instrumentTabControl.Name = "instrumentTabControl";
            this.instrumentTabControl.SelectedIndex = 0;
            this.instrumentTabControl.Size = new System.Drawing.Size(1012, 845);
            this.instrumentTabControl.TabIndex = 0;
            // 
            // errorViewTabPage
            // 
            this.errorViewTabPage.Controls.Add(this.errorViewOLV);
            this.errorViewTabPage.Location = new System.Drawing.Point(4, 22);
            this.errorViewTabPage.Name = "errorViewTabPage";
            this.errorViewTabPage.Padding = new System.Windows.Forms.Padding(3);
            this.errorViewTabPage.Size = new System.Drawing.Size(1004, 819);
            this.errorViewTabPage.TabIndex = 0;
            this.errorViewTabPage.Text = "Error View";
            this.errorViewTabPage.UseVisualStyleBackColor = true;
            // 
            // priceUpdateTabPage
            // 
            this.priceUpdateTabPage.Controls.Add(this.bloombergUpdateControl1);
            this.priceUpdateTabPage.Location = new System.Drawing.Point(4, 22);
            this.priceUpdateTabPage.Name = "priceUpdateTabPage";
            this.priceUpdateTabPage.Padding = new System.Windows.Forms.Padding(3);
            this.priceUpdateTabPage.Size = new System.Drawing.Size(1004, 819);
            this.priceUpdateTabPage.TabIndex = 1;
            this.priceUpdateTabPage.Text = "Price Update Tools";
            this.priceUpdateTabPage.UseVisualStyleBackColor = true;
            // 
            // instrumentViewTabPage
            // 
            this.instrumentViewTabPage.Location = new System.Drawing.Point(4, 22);
            this.instrumentViewTabPage.Name = "instrumentViewTabPage";
            this.instrumentViewTabPage.Padding = new System.Windows.Forms.Padding(3);
            this.instrumentViewTabPage.Size = new System.Drawing.Size(1004, 819);
            this.instrumentViewTabPage.TabIndex = 2;
            this.instrumentViewTabPage.Text = "InstrumentView";
            this.instrumentViewTabPage.UseVisualStyleBackColor = true;
            // 
            // errorViewOLV
            // 
            this.errorViewOLV.CellEditUseWholeCell = false;
            this.errorViewOLV.Location = new System.Drawing.Point(6, 38);
            this.errorViewOLV.Name = "errorViewOLV";
            this.errorViewOLV.Size = new System.Drawing.Size(992, 775);
            this.errorViewOLV.TabIndex = 0;
            this.errorViewOLV.UseCompatibleStateImageBehavior = false;
            this.errorViewOLV.View = System.Windows.Forms.View.Details;
            // 
            // bloombergUpdateControl1
            // 
            this.bloombergUpdateControl1.Location = new System.Drawing.Point(6, 6);
            this.bloombergUpdateControl1.Name = "bloombergUpdateControl1";
            this.bloombergUpdateControl1.Size = new System.Drawing.Size(652, 323);
            this.bloombergUpdateControl1.TabIndex = 0;
            // 
            // InstrumentSettingsControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.instrumentTabControl);
            this.Name = "InstrumentSettingsControl";
            this.Size = new System.Drawing.Size(1019, 852);
            this.instrumentTabControl.ResumeLayout(false);
            this.errorViewTabPage.ResumeLayout(false);
            this.priceUpdateTabPage.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.errorViewOLV)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl instrumentTabControl;
        private System.Windows.Forms.TabPage errorViewTabPage;
        private System.Windows.Forms.TabPage priceUpdateTabPage;
        private System.Windows.Forms.TabPage instrumentViewTabPage;
        private BrightIdeasSoftware.ObjectListView errorViewOLV;
        private BloombergUpdateControl bloombergUpdateControl1;
    }
}
