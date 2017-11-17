namespace InstrumentSettingsProject
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(InstrumentSettingsControl));
            this.instrumentTabControl = new System.Windows.Forms.TabControl();
            this.errorViewTabPage = new System.Windows.Forms.TabPage();
            this.instrumentEditTabPage = new System.Windows.Forms.TabPage();
            this.instrumentPropertyGrid = new System.Windows.Forms.PropertyGrid();
            this.objInstrument = new BrightIdeasSoftware.ObjectListView();
            this.IDColumn = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.NameColumn = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.ISINColumn = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.BloombergIDColumn = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.PriceColumn = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.saveButton = new System.Windows.Forms.Button();
            this.closeButton = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.priceUpdateTabPage = new System.Windows.Forms.TabPage();
            this.ErrorColumn = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.instrumentTabControl.SuspendLayout();
            this.errorViewTabPage.SuspendLayout();
            this.instrumentEditTabPage.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.objInstrument)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // instrumentTabControl
            // 
            this.instrumentTabControl.Controls.Add(this.errorViewTabPage);
            this.instrumentTabControl.Controls.Add(this.instrumentEditTabPage);
            this.instrumentTabControl.Controls.Add(this.priceUpdateTabPage);
            this.instrumentTabControl.Location = new System.Drawing.Point(3, 3);
            this.instrumentTabControl.Name = "instrumentTabControl";
            this.instrumentTabControl.SelectedIndex = 0;
            this.instrumentTabControl.Size = new System.Drawing.Size(963, 874);
            this.instrumentTabControl.TabIndex = 1;
            // 
            // errorViewTabPage
            // 
            this.errorViewTabPage.Controls.Add(this.objInstrument);
            this.errorViewTabPage.Location = new System.Drawing.Point(4, 22);
            this.errorViewTabPage.Name = "errorViewTabPage";
            this.errorViewTabPage.Padding = new System.Windows.Forms.Padding(3);
            this.errorViewTabPage.Size = new System.Drawing.Size(955, 848);
            this.errorViewTabPage.TabIndex = 0;
            this.errorViewTabPage.Text = "Error View";
            this.errorViewTabPage.UseVisualStyleBackColor = true;
            // 
            // instrumentEditTabPage
            // 
            this.instrumentEditTabPage.Controls.Add(this.pictureBox1);
            this.instrumentEditTabPage.Controls.Add(this.closeButton);
            this.instrumentEditTabPage.Controls.Add(this.saveButton);
            this.instrumentEditTabPage.Controls.Add(this.instrumentPropertyGrid);
            this.instrumentEditTabPage.Location = new System.Drawing.Point(4, 22);
            this.instrumentEditTabPage.Name = "instrumentEditTabPage";
            this.instrumentEditTabPage.Padding = new System.Windows.Forms.Padding(3);
            this.instrumentEditTabPage.Size = new System.Drawing.Size(955, 848);
            this.instrumentEditTabPage.TabIndex = 1;
            this.instrumentEditTabPage.Text = "Instrument View";
            this.instrumentEditTabPage.UseVisualStyleBackColor = true;
            // 
            // instrumentPropertyGrid
            // 
            this.instrumentPropertyGrid.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.instrumentPropertyGrid.Location = new System.Drawing.Point(6, 6);
            this.instrumentPropertyGrid.Name = "instrumentPropertyGrid";
            this.instrumentPropertyGrid.Size = new System.Drawing.Size(427, 836);
            this.instrumentPropertyGrid.TabIndex = 1;
            // 
            // objInstrument
            // 
            this.objInstrument.AllColumns.Add(this.IDColumn);
            this.objInstrument.AllColumns.Add(this.NameColumn);
            this.objInstrument.AllColumns.Add(this.ISINColumn);
            this.objInstrument.AllColumns.Add(this.BloombergIDColumn);
            this.objInstrument.AllColumns.Add(this.PriceColumn);
            this.objInstrument.AllColumns.Add(this.ErrorColumn);
            this.objInstrument.CellEditUseWholeCell = false;
            this.objInstrument.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.IDColumn,
            this.NameColumn,
            this.ISINColumn,
            this.BloombergIDColumn,
            this.PriceColumn,
            this.ErrorColumn});
            this.objInstrument.Cursor = System.Windows.Forms.Cursors.Default;
            this.objInstrument.Location = new System.Drawing.Point(6, 6);
            this.objInstrument.Name = "objInstrument";
            this.objInstrument.Size = new System.Drawing.Size(943, 836);
            this.objInstrument.TabIndex = 0;
            this.objInstrument.UseCompatibleStateImageBehavior = false;
            this.objInstrument.View = System.Windows.Forms.View.Details;
            // 
            // IDColumn
            // 
            this.IDColumn.Text = "ID";
            // 
            // NameColumn
            // 
            this.NameColumn.Text = "Instrument Name";
            this.NameColumn.Width = 218;
            // 
            // ISINColumn
            // 
            this.ISINColumn.Text = "ISIN";
            this.ISINColumn.Width = 128;
            // 
            // BloombergIDColumn
            // 
            this.BloombergIDColumn.Text = "BloombergID";
            this.BloombergIDColumn.Width = 172;
            // 
            // PriceColumn
            // 
            this.PriceColumn.Text = "Price";
            this.PriceColumn.Width = 83;
            // 
            // saveButton
            // 
            this.saveButton.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.saveButton.Location = new System.Drawing.Point(439, 781);
            this.saveButton.Name = "saveButton";
            this.saveButton.Size = new System.Drawing.Size(110, 61);
            this.saveButton.TabIndex = 2;
            this.saveButton.Text = "Save";
            this.saveButton.UseVisualStyleBackColor = true;
            // 
            // closeButton
            // 
            this.closeButton.Location = new System.Drawing.Point(555, 781);
            this.closeButton.Name = "closeButton";
            this.closeButton.Size = new System.Drawing.Size(110, 61);
            this.closeButton.TabIndex = 3;
            this.closeButton.Text = "Close";
            this.closeButton.UseVisualStyleBackColor = true;
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("pictureBox1.BackgroundImage")));
            this.pictureBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.pictureBox1.Location = new System.Drawing.Point(439, 6);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(500, 500);
            this.pictureBox1.TabIndex = 4;
            this.pictureBox1.TabStop = false;
            // 
            // priceUpdateTabPage
            // 
            this.priceUpdateTabPage.Location = new System.Drawing.Point(4, 22);
            this.priceUpdateTabPage.Name = "priceUpdateTabPage";
            this.priceUpdateTabPage.Padding = new System.Windows.Forms.Padding(3);
            this.priceUpdateTabPage.Size = new System.Drawing.Size(955, 848);
            this.priceUpdateTabPage.TabIndex = 2;
            this.priceUpdateTabPage.Text = "Price Update Tools";
            this.priceUpdateTabPage.UseVisualStyleBackColor = true;
            // 
            // ErrorColumn
            // 
            this.ErrorColumn.Text = "Error Message";
            this.ErrorColumn.Width = 270;
            // 
            // InstrumentSettingsControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.instrumentTabControl);
            this.Name = "InstrumentSettingsControl";
            this.Size = new System.Drawing.Size(969, 880);
            this.instrumentTabControl.ResumeLayout(false);
            this.errorViewTabPage.ResumeLayout(false);
            this.instrumentEditTabPage.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.objInstrument)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        public System.Windows.Forms.TabControl instrumentTabControl;
        private System.Windows.Forms.TabPage errorViewTabPage;
        private BrightIdeasSoftware.ObjectListView objInstrument;
        private BrightIdeasSoftware.OLVColumn IDColumn;
        private BrightIdeasSoftware.OLVColumn NameColumn;
        private BrightIdeasSoftware.OLVColumn ISINColumn;
        private BrightIdeasSoftware.OLVColumn BloombergIDColumn;
        private BrightIdeasSoftware.OLVColumn PriceColumn;
        private System.Windows.Forms.TabPage instrumentEditTabPage;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Button closeButton;
        private System.Windows.Forms.Button saveButton;
        private System.Windows.Forms.PropertyGrid instrumentPropertyGrid;
        private System.Windows.Forms.TabPage priceUpdateTabPage;
        private BrightIdeasSoftware.OLVColumn ErrorColumn;
    }
}
