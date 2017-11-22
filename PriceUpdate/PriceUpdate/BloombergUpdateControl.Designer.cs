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
            this.intradayButton = new System.Windows.Forms.Button();
            this.miniButton = new System.Windows.Forms.Button();
            this.informLabel1 = new System.Windows.Forms.Label();
            this.informLabel2 = new System.Windows.Forms.Label();
            this.informLabel3 = new System.Windows.Forms.Label();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.button1 = new System.Windows.Forms.Button();
            this.flowLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // titleLabel
            // 
            this.titleLabel.AutoSize = true;
            this.titleLabel.Font = new System.Drawing.Font("Segoe UI", 14F);
            this.titleLabel.Location = new System.Drawing.Point(3, 4);
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
            this.progressLabel.Location = new System.Drawing.Point(39, 91);
            this.progressLabel.Name = "progressLabel";
            this.progressLabel.Size = new System.Drawing.Size(52, 15);
            this.progressLabel.TabIndex = 8;
            this.progressLabel.Text = "Progress";
            // 
            // intradayButton
            // 
            this.intradayButton.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("intradayButton.BackgroundImage")));
            this.intradayButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.intradayButton.Location = new System.Drawing.Point(228, 3);
            this.intradayButton.Name = "intradayButton";
            this.intradayButton.Size = new System.Drawing.Size(67, 65);
            this.intradayButton.TabIndex = 9;
            this.intradayButton.UseVisualStyleBackColor = true;
            this.intradayButton.Click += new System.EventHandler(this.intradayButton_Click);
            // 
            // miniButton
            // 
            this.miniButton.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("miniButton.BackgroundImage")));
            this.miniButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.miniButton.Location = new System.Drawing.Point(451, 3);
            this.miniButton.Name = "miniButton";
            this.miniButton.Size = new System.Drawing.Size(67, 65);
            this.miniButton.TabIndex = 10;
            this.miniButton.UseVisualStyleBackColor = true;
            this.miniButton.Click += new System.EventHandler(this.miniButton_Click);
            // 
            // informLabel1
            // 
            this.informLabel1.AutoSize = true;
            this.informLabel1.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.informLabel1.Location = new System.Drawing.Point(102, 0);
            this.informLabel1.Name = "informLabel1";
            this.informLabel1.Size = new System.Drawing.Size(120, 15);
            this.informLabel1.TabIndex = 11;
            this.informLabel1.Text = "Run Full Price Update";
            // 
            // informLabel2
            // 
            this.informLabel2.AutoSize = true;
            this.informLabel2.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.informLabel2.Location = new System.Drawing.Point(301, 0);
            this.informLabel2.Name = "informLabel2";
            this.informLabel2.Size = new System.Drawing.Size(144, 15);
            this.informLabel2.TabIndex = 12;
            this.informLabel2.Text = "Run Intraday Price Update";
            // 
            // informLabel3
            // 
            this.informLabel3.AutoSize = true;
            this.informLabel3.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.informLabel3.Location = new System.Drawing.Point(524, 0);
            this.informLabel3.Name = "informLabel3";
            this.informLabel3.Size = new System.Drawing.Size(145, 15);
            this.informLabel3.TabIndex = 13;
            this.informLabel3.Text = "Run Minimal Price Update";
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.flowLayoutPanel1.Controls.Add(this.updateButton);
            this.flowLayoutPanel1.Controls.Add(this.informLabel1);
            this.flowLayoutPanel1.Controls.Add(this.intradayButton);
            this.flowLayoutPanel1.Controls.Add(this.informLabel2);
            this.flowLayoutPanel1.Controls.Add(this.miniButton);
            this.flowLayoutPanel1.Controls.Add(this.informLabel3);
            this.flowLayoutPanel1.Controls.Add(this.button1);
            this.flowLayoutPanel1.Controls.Add(this.progressLabel);
            this.flowLayoutPanel1.Location = new System.Drawing.Point(3, 32);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(685, 121);
            this.flowLayoutPanel1.TabIndex = 14;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(3, 94);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(30, 23);
            this.button1.TabIndex = 15;
            this.button1.Text = "T";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click_1);
            // 
            // BloombergUpdateControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.flowLayoutPanel1);
            this.Controls.Add(this.randomLabel);
            this.Controls.Add(this.titleLabel);
            this.Name = "BloombergUpdateControl";
            this.Size = new System.Drawing.Size(693, 156);
            this.flowLayoutPanel1.ResumeLayout(false);
            this.flowLayoutPanel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label titleLabel;
        private System.Windows.Forms.Button updateButton;
        private System.Windows.Forms.Label randomLabel;
        private System.Windows.Forms.Label progressLabel;
        private System.Windows.Forms.Button intradayButton;
        private System.Windows.Forms.Button miniButton;
        private System.Windows.Forms.Label informLabel1;
        private System.Windows.Forms.Label informLabel2;
        private System.Windows.Forms.Label informLabel3;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.Button button1;
    }
}
