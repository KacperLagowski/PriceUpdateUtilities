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
            this.updateButton = new System.Windows.Forms.Button();
            this.randomLabel = new System.Windows.Forms.Label();
            this.progressLabel = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // titleLabel
            // 
            this.titleLabel.AutoSize = true;
            this.titleLabel.Font = new System.Drawing.Font("Segoe UI", 14F);
            this.titleLabel.Location = new System.Drawing.Point(102, 8);
            this.titleLabel.Name = "titleLabel";
            this.titleLabel.Size = new System.Drawing.Size(271, 25);
            this.titleLabel.TabIndex = 4;
            this.titleLabel.Text = "Update Prices from Bloomberg";
            // 
            // updateButton
            // 
            this.updateButton.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("updateButton.BackgroundImage")));
            this.updateButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.updateButton.Location = new System.Drawing.Point(3, 3);
            this.updateButton.Name = "updateButton";
            this.updateButton.Size = new System.Drawing.Size(93, 85);
            this.updateButton.TabIndex = 6;
            this.updateButton.UseVisualStyleBackColor = true;
            this.updateButton.Click += new System.EventHandler(this.button1_Click);
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
            // progressLabel
            // 
            this.progressLabel.AutoSize = true;
            this.progressLabel.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.progressLabel.Location = new System.Drawing.Point(102, 56);
            this.progressLabel.Name = "progressLabel";
            this.progressLabel.Size = new System.Drawing.Size(52, 15);
            this.progressLabel.TabIndex = 8;
            this.progressLabel.Text = "Progress";
            // 
            // BloombergUpdateControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.progressLabel);
            this.Controls.Add(this.randomLabel);
            this.Controls.Add(this.updateButton);
            this.Controls.Add(this.titleLabel);
            this.Name = "BloombergUpdateControl";
            this.Size = new System.Drawing.Size(373, 205);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label titleLabel;
        private System.Windows.Forms.Button updateButton;
        private System.Windows.Forms.Label randomLabel;
        private System.Windows.Forms.Label progressLabel;
    }
}
