namespace negar
{
    partial class Report
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Report));
            this.button1 = new System.Windows.Forms.Button();
            this.reportListBox = new System.Windows.Forms.ListBox();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.button1.Location = new System.Drawing.Point(0, 416);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(354, 23);
            this.button1.TabIndex = 0;
            this.button1.Text = "بستن";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // reportListBox
            // 
            this.reportListBox.Dock = System.Windows.Forms.DockStyle.Top;
            this.reportListBox.FormattingEnabled = true;
            this.reportListBox.HorizontalScrollbar = true;
            this.reportListBox.Location = new System.Drawing.Point(0, 0);
            this.reportListBox.Name = "reportListBox";
            this.reportListBox.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.reportListBox.SelectionMode = System.Windows.Forms.SelectionMode.None;
            this.reportListBox.Size = new System.Drawing.Size(354, 407);
            this.reportListBox.TabIndex = 1;
            // 
            // Report
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(354, 439);
            this.Controls.Add(this.reportListBox);
            this.Controls.Add(this.button1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Report";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "گزارش";
            this.TopMost = true;
            this.Load += new System.EventHandler(this.Report_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.ListBox reportListBox;
    }
}