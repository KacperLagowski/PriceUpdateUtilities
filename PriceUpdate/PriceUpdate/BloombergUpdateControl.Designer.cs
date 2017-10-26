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
            this.circleProgressBar = new CircleProgressBarCs.CircleProgressBar();
            this.updateButton = new System.Windows.Forms.Button();
            this.randomLabel = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // titleLabel
            // 
            this.titleLabel.AutoSize = true;
            this.titleLabel.Font = new System.Drawing.Font("Segoe UI", 18F);
            this.titleLabel.Location = new System.Drawing.Point(3, 0);
            this.titleLabel.Name = "titleLabel";
            this.titleLabel.Size = new System.Drawing.Size(343, 32);
            this.titleLabel.TabIndex = 4;
            this.titleLabel.Text = "Update Prices from Bloomberg";
            // 
            // circleProgressBar
            // 
            this.circleProgressBar.BackColor = System.Drawing.Color.DarkGray;
            this.circleProgressBar.ForeColor = System.Drawing.Color.Red;
            this.circleProgressBar.Location = new System.Drawing.Point(9, 37);
            this.circleProgressBar.Name = "circleProgressBar";
            this.circleProgressBar.Size = new System.Drawing.Size(176, 136);
            this.circleProgressBar.TabIndex = 5;
            this.circleProgressBar.Thickness = 50;
            this.circleProgressBar.Value = 42;
            // 
            // updateButton
            // 
            this.updateButton.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("updateButton.BackgroundImage")));
            this.updateButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.updateButton.Location = new System.Drawing.Point(204, 67);
            this.updateButton.Name = "updateButton";
            this.updateButton.Size = new System.Drawing.Size(93, 85);
            this.updateButton.TabIndex = 6;
            this.updateButton.UseVisualStyleBackColor = true;
            this.updateButton.Click += new System.EventHandler(this.button1_Click);
            // 
            // randomLabel
            // 
            this.randomLabel.AutoSize = true;
            this.randomLabel.Location = new System.Drawing.Point(201, 174);
            this.randomLabel.Name = "randomLabel";
            this.randomLabel.Size = new System.Drawing.Size(35, 13);
            this.randomLabel.TabIndex = 7;
            this.randomLabel.Text = "label1";
            // 
            // BloombergUpdateControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.randomLabel);
            this.Controls.Add(this.updateButton);
            this.Controls.Add(this.circleProgressBar);
            this.Controls.Add(this.titleLabel);
            this.Name = "BloombergUpdateControl";
            this.Size = new System.Drawing.Size(386, 286);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label titleLabel;
        private CircleProgressBarCs.CircleProgressBar circleProgressBar;
        private System.Windows.Forms.Button updateButton;
        private System.Windows.Forms.Label randomLabel;
    }
}
