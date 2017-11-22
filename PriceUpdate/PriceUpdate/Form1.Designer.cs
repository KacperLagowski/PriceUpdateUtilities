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
            this.components = new System.ComponentModel.Container();
            this.notifyIcon = new System.Windows.Forms.NotifyIcon(this.components);
            this.bloombergUpdateControl = new PriceUpdate.BloombergUpdateControl();
            this.SuspendLayout();
            // 
            // notifyIcon
            // 
            this.notifyIcon.BalloonTipText = "Price Update Utility still working...";
            this.notifyIcon.BalloonTipTitle = "Price Update Application";
            this.notifyIcon.Text = "notifyIcon1";
            this.notifyIcon.Visible = true;
            this.notifyIcon.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.notifyIcon_MouseDoubleClick);
            // 
            // bloombergUpdateControl
            // 
            this.bloombergUpdateControl.Location = new System.Drawing.Point(12, 12);
            this.bloombergUpdateControl.Name = "bloombergUpdateControl";
            this.bloombergUpdateControl.ProgressLabelText = null;
            this.bloombergUpdateControl.Size = new System.Drawing.Size(693, 156);
            this.bloombergUpdateControl.TabIndex = 0;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(709, 171);
            this.Controls.Add(this.bloombergUpdateControl);
            this.Name = "Form1";
            this.Text = "Price Update Utility";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.Resize += new System.EventHandler(this.Form1_Resize_1);
            this.ResumeLayout(false);

        }

        #endregion

        private BloombergUpdateControl bloombergUpdateControl;
        private System.Windows.Forms.NotifyIcon notifyIcon;
    }
}

