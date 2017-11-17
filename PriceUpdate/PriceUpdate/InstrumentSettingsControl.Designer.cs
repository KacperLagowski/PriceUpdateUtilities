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
            this.errorViewOLV = new BrightIdeasSoftware.ObjectListView();
            this.IDColumn = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.InstrumentNameColumn = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.BloombergIDColumn = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.IsinColumn = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.PriceColumn = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.ErrorMessageColumn = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.priceUpdateTabPage = new System.Windows.Forms.TabPage();
            this.bloombergUpdateControl1 = new PriceUpdate.BloombergUpdateControl();
            this.instrumentViewTabPage = new System.Windows.Forms.TabPage();
            this.instrumentDetailsControl1 = new PriceUpdate.InstrumentDetailsControl();
            this.instrumentTabControl.SuspendLayout();
            this.errorViewTabPage.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorViewOLV)).BeginInit();
            this.priceUpdateTabPage.SuspendLayout();
            this.instrumentViewTabPage.SuspendLayout();
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
            this.instrumentTabControl.Size = new System.Drawing.Size(1031, 857);
            this.instrumentTabControl.TabIndex = 0;
            // 
            // errorViewTabPage
            // 
            this.errorViewTabPage.Controls.Add(this.errorViewOLV);
            this.errorViewTabPage.Location = new System.Drawing.Point(4, 22);
            this.errorViewTabPage.Name = "errorViewTabPage";
            this.errorViewTabPage.Padding = new System.Windows.Forms.Padding(3);
            this.errorViewTabPage.Size = new System.Drawing.Size(1023, 831);
            this.errorViewTabPage.TabIndex = 0;
            this.errorViewTabPage.Text = "Error View";
            this.errorViewTabPage.UseVisualStyleBackColor = true;
            // 
            // errorViewOLV
            // 
            this.errorViewOLV.AllColumns.Add(this.IDColumn);
            this.errorViewOLV.AllColumns.Add(this.InstrumentNameColumn);
            this.errorViewOLV.AllColumns.Add(this.BloombergIDColumn);
            this.errorViewOLV.AllColumns.Add(this.IsinColumn);
            this.errorViewOLV.AllColumns.Add(this.PriceColumn);
            this.errorViewOLV.AllColumns.Add(this.ErrorMessageColumn);
            this.errorViewOLV.CellEditUseWholeCell = false;
            this.errorViewOLV.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.IDColumn,
            this.InstrumentNameColumn,
            this.BloombergIDColumn,
            this.IsinColumn,
            this.PriceColumn,
            this.ErrorMessageColumn});
            this.errorViewOLV.Cursor = System.Windows.Forms.Cursors.Default;
            this.errorViewOLV.Location = new System.Drawing.Point(6, 50);
            this.errorViewOLV.Name = "errorViewOLV";
            this.errorViewOLV.Size = new System.Drawing.Size(1014, 775);
            this.errorViewOLV.TabIndex = 0;
            this.errorViewOLV.UseCompatibleStateImageBehavior = false;
            this.errorViewOLV.View = System.Windows.Forms.View.Details;
            // 
            // IDColumn
            // 
            this.IDColumn.Text = "ID";
            this.IDColumn.Width = 62;
            // 
            // InstrumentNameColumn
            // 
            this.InstrumentNameColumn.Text = "Instrument Name";
            this.InstrumentNameColumn.Width = 139;
            // 
            // BloombergIDColumn
            // 
            this.BloombergIDColumn.Text = "BloombergID";
            this.BloombergIDColumn.Width = 125;
            // 
            // IsinColumn
            // 
            this.IsinColumn.Text = "ISIN";
            this.IsinColumn.Width = 130;
            // 
            // PriceColumn
            // 
            this.PriceColumn.Text = "Price";
            this.PriceColumn.Width = 74;
            // 
            // ErrorMessageColumn
            // 
            this.ErrorMessageColumn.Text = "Error Message";
            this.ErrorMessageColumn.Width = 478;
            // 
            // priceUpdateTabPage
            // 
            this.priceUpdateTabPage.Controls.Add(this.bloombergUpdateControl1);
            this.priceUpdateTabPage.Location = new System.Drawing.Point(4, 22);
            this.priceUpdateTabPage.Name = "priceUpdateTabPage";
            this.priceUpdateTabPage.Padding = new System.Windows.Forms.Padding(3);
            this.priceUpdateTabPage.Size = new System.Drawing.Size(1023, 831);
            this.priceUpdateTabPage.TabIndex = 1;
            this.priceUpdateTabPage.Text = "Price Update Tools";
            this.priceUpdateTabPage.UseVisualStyleBackColor = true;
            // 
            // bloombergUpdateControl1
            // 
            this.bloombergUpdateControl1.Location = new System.Drawing.Point(6, 6);
            this.bloombergUpdateControl1.Name = "bloombergUpdateControl1";
            this.bloombergUpdateControl1.Size = new System.Drawing.Size(652, 323);
            this.bloombergUpdateControl1.TabIndex = 0;
            // 
            // instrumentViewTabPage
            // 
            this.instrumentViewTabPage.Controls.Add(this.instrumentDetailsControl1);
            this.instrumentViewTabPage.Location = new System.Drawing.Point(4, 22);
            this.instrumentViewTabPage.Name = "instrumentViewTabPage";
            this.instrumentViewTabPage.Padding = new System.Windows.Forms.Padding(3);
            this.instrumentViewTabPage.Size = new System.Drawing.Size(1023, 831);
            this.instrumentViewTabPage.TabIndex = 2;
            this.instrumentViewTabPage.Text = "InstrumentView";
            this.instrumentViewTabPage.UseVisualStyleBackColor = true;
            // 
            // instrumentDetailsControl1
            // 
            this.instrumentDetailsControl1.Location = new System.Drawing.Point(6, 6);
            this.instrumentDetailsControl1.Name = "instrumentDetailsControl1";
            this.instrumentDetailsControl1.Size = new System.Drawing.Size(1000, 815);
            this.instrumentDetailsControl1.TabIndex = 0;
            this.instrumentDetailsControl1.Load += new System.EventHandler(this.instrumentDetailsControl1_Load);
            // 
            // InstrumentSettingsControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.instrumentTabControl);
            this.Name = "InstrumentSettingsControl";
            this.Size = new System.Drawing.Size(1038, 864);
            this.instrumentTabControl.ResumeLayout(false);
            this.errorViewTabPage.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.errorViewOLV)).EndInit();
            this.priceUpdateTabPage.ResumeLayout(false);
            this.instrumentViewTabPage.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl instrumentTabControl;
        private System.Windows.Forms.TabPage errorViewTabPage;
        private System.Windows.Forms.TabPage priceUpdateTabPage;
        private System.Windows.Forms.TabPage instrumentViewTabPage;
        private BrightIdeasSoftware.ObjectListView errorViewOLV;
        private BloombergUpdateControl bloombergUpdateControl1;
        private InstrumentDetailsControl instrumentDetailsControl1;
        private BrightIdeasSoftware.OLVColumn IDColumn;
        private BrightIdeasSoftware.OLVColumn InstrumentNameColumn;
        private BrightIdeasSoftware.OLVColumn BloombergIDColumn;
        private BrightIdeasSoftware.OLVColumn IsinColumn;
        private BrightIdeasSoftware.OLVColumn PriceColumn;
        private BrightIdeasSoftware.OLVColumn ErrorMessageColumn;
    }
}
