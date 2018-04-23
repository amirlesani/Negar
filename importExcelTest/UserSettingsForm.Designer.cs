namespace negar
{
    partial class UserSettingsForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(UserSettingsForm));
            this.changeColorButton = new System.Windows.Forms.Button();
            this.colorPalletePictureBox = new System.Windows.Forms.PictureBox();
            this.DGVcolorDialog = new System.Windows.Forms.ColorDialog();
            this.rowsNumericUpDown = new System.Windows.Forms.NumericUpDown();
            this.changeRowsButton = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.fontDialog1 = new System.Windows.Forms.FontDialog();
            ((System.ComponentModel.ISupportInitialize)(this.colorPalletePictureBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rowsNumericUpDown)).BeginInit();
            this.SuspendLayout();
            // 
            // changeColorButton
            // 
            this.changeColorButton.Location = new System.Drawing.Point(88, 23);
            this.changeColorButton.Name = "changeColorButton";
            this.changeColorButton.Size = new System.Drawing.Size(97, 25);
            this.changeColorButton.TabIndex = 0;
            this.changeColorButton.Text = "تغییر رنگ جداول";
            this.changeColorButton.UseVisualStyleBackColor = true;
            this.changeColorButton.Click += new System.EventHandler(this.changeColorButton_Click);
            // 
            // colorPalletePictureBox
            // 
            this.colorPalletePictureBox.Location = new System.Drawing.Point(191, 23);
            this.colorPalletePictureBox.Name = "colorPalletePictureBox";
            this.colorPalletePictureBox.Size = new System.Drawing.Size(38, 25);
            this.colorPalletePictureBox.TabIndex = 1;
            this.colorPalletePictureBox.TabStop = false;
            this.colorPalletePictureBox.Click += new System.EventHandler(this.colorPalletePictureBox_Click);
            // 
            // rowsNumericUpDown
            // 
            this.rowsNumericUpDown.Location = new System.Drawing.Point(191, 54);
            this.rowsNumericUpDown.Name = "rowsNumericUpDown";
            this.rowsNumericUpDown.Size = new System.Drawing.Size(38, 20);
            this.rowsNumericUpDown.TabIndex = 2;
            this.rowsNumericUpDown.ValueChanged += new System.EventHandler(this.rowsNumericUpDown_ValueChanged);
            // 
            // changeRowsButton
            // 
            this.changeRowsButton.Location = new System.Drawing.Point(88, 54);
            this.changeRowsButton.Name = "changeRowsButton";
            this.changeRowsButton.Size = new System.Drawing.Size(97, 23);
            this.changeRowsButton.TabIndex = 1;
            this.changeRowsButton.Text = "تغییر تعداد سطر ها";
            this.changeRowsButton.UseVisualStyleBackColor = true;
            this.changeRowsButton.Click += new System.EventHandler(this.changeRowsButton_Click);
            // 
            // label1
            // 
            this.label1.Image = global::negar.Properties.Resources.settings_icon__1_;
            this.label1.Location = new System.Drawing.Point(-39, -24);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(149, 150);
            this.label1.TabIndex = 3;
            this.label1.Text = "label1";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // UserSettingsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(246, 118);
            this.Controls.Add(this.changeRowsButton);
            this.Controls.Add(this.rowsNumericUpDown);
            this.Controls.Add(this.colorPalletePictureBox);
            this.Controls.Add(this.changeColorButton);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "UserSettingsForm";
            this.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "تنظیمات";
            this.TopMost = true;
            this.Load += new System.EventHandler(this.UserSettingsForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.colorPalletePictureBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rowsNumericUpDown)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button changeColorButton;
        private System.Windows.Forms.PictureBox colorPalletePictureBox;
        private System.Windows.Forms.ColorDialog DGVcolorDialog;
        private System.Windows.Forms.NumericUpDown rowsNumericUpDown;
        private System.Windows.Forms.Button changeRowsButton;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.FontDialog fontDialog1;
    }
}