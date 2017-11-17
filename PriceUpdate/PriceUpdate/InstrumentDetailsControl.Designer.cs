namespace PriceUpdate
{
    partial class InstrumentDetailsControl
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(InstrumentDetailsControl));
            this.instrumentDetailsPropertyGrid = new System.Windows.Forms.PropertyGrid();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.senecaLogoPictureBox = new System.Windows.Forms.PictureBox();
            this.saveButton = new System.Windows.Forms.Button();
            this.closeButton = new System.Windows.Forms.Button();
            this.flowLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.senecaLogoPictureBox)).BeginInit();
            this.SuspendLayout();
            // 
            // instrumentDetailsPropertyGrid
            // 
            this.instrumentDetailsPropertyGrid.Location = new System.Drawing.Point(3, 3);
            this.instrumentDetailsPropertyGrid.Name = "instrumentDetailsPropertyGrid";
            this.instrumentDetailsPropertyGrid.Size = new System.Drawing.Size(536, 806);
            this.instrumentDetailsPropertyGrid.TabIndex = 1;
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.Controls.Add(this.instrumentDetailsPropertyGrid);
            this.flowLayoutPanel1.Controls.Add(this.senecaLogoPictureBox);
            this.flowLayoutPanel1.Controls.Add(this.saveButton);
            this.flowLayoutPanel1.Controls.Add(this.closeButton);
            this.flowLayoutPanel1.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.flowLayoutPanel1.Location = new System.Drawing.Point(3, 3);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(994, 809);
            this.flowLayoutPanel1.TabIndex = 2;
            // 
            // senecaLogoPictureBox
            // 
            this.senecaLogoPictureBox.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("senecaLogoPictureBox.BackgroundImage")));
            this.senecaLogoPictureBox.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.senecaLogoPictureBox.Location = new System.Drawing.Point(545, 3);
            this.senecaLogoPictureBox.Name = "senecaLogoPictureBox";
            this.senecaLogoPictureBox.Size = new System.Drawing.Size(450, 450);
            this.senecaLogoPictureBox.TabIndex = 4;
            this.senecaLogoPictureBox.TabStop = false;
            // 
            // saveButton
            // 
            this.saveButton.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.saveButton.Location = new System.Drawing.Point(545, 459);
            this.saveButton.Name = "saveButton";
            this.saveButton.Size = new System.Drawing.Size(126, 61);
            this.saveButton.TabIndex = 6;
            this.saveButton.Text = "Save";
            this.saveButton.UseVisualStyleBackColor = true;
            // 
            // closeButton
            // 
            this.closeButton.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.closeButton.Location = new System.Drawing.Point(545, 526);
            this.closeButton.Name = "closeButton";
            this.closeButton.Size = new System.Drawing.Size(126, 61);
            this.closeButton.TabIndex = 5;
            this.closeButton.Text = "Close";
            this.closeButton.UseVisualStyleBackColor = true;
            // 
            // InstrumentDetailsControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.flowLayoutPanel1);
            this.Name = "InstrumentDetailsControl";
            this.Size = new System.Drawing.Size(1000, 815);
            this.flowLayoutPanel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.senecaLogoPictureBox)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PropertyGrid instrumentDetailsPropertyGrid;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.PictureBox senecaLogoPictureBox;
        private System.Windows.Forms.Button saveButton;
        private System.Windows.Forms.Button closeButton;
    }
}
