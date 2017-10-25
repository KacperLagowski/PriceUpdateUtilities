namespace PriceUpdate
{
    partial class Form1
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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.bloombergUpdateControl1 = new PriceUpdate.BloombergUpdateControl();
            this.SuspendLayout();
            // 
            // bloombergUpdateControl1
            // 
            this.bloombergUpdateControl1.Location = new System.Drawing.Point(324, 100);
            this.bloombergUpdateControl1.Name = "bloombergUpdateControl1";
            this.bloombergUpdateControl1.Size = new System.Drawing.Size(717, 404);
            this.bloombergUpdateControl1.TabIndex = 0;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1419, 770);
            this.Controls.Add(this.bloombergUpdateControl1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private BloombergUpdateControl bloombergUpdateControl1;
    }
}

