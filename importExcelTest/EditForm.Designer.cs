namespace negar
{
    partial class EditForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(EditForm));
            this.AccountTypeComboBox = new System.Windows.Forms.ComboBox();
            this.editButton = new System.Windows.Forms.Button();
            this.placeComboBox = new System.Windows.Forms.ComboBox();
            this.label10 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.DepositDetailtextBox = new System.Windows.Forms.TextBox();
            this.BudgetCodetextBox = new System.Windows.Forms.TextBox();
            this.DepositTextBox = new System.Windows.Forms.TextBox();
            this.DepositOwnerDetailTextBox = new System.Windows.Forms.TextBox();
            this.billDetailCodetextBox = new System.Windows.Forms.TextBox();
            this.refundTextBox = new System.Windows.Forms.TextBox();
            this.dateMaskedTextBox = new System.Windows.Forms.MaskedTextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.inputErrorProvider = new System.Windows.Forms.ErrorProvider(this.components);
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.inputErrorProvider)).BeginInit();
            this.SuspendLayout();
            // 
            // AccountTypeComboBox
            // 
            this.AccountTypeComboBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)));
            this.AccountTypeComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.AccountTypeComboBox.FormattingEnabled = true;
            this.AccountTypeComboBox.Items.AddRange(new object[] {
            "هزینه ایی",
            "تملکی"});
            this.AccountTypeComboBox.Location = new System.Drawing.Point(86, 45);
            this.AccountTypeComboBox.Name = "AccountTypeComboBox";
            this.AccountTypeComboBox.Size = new System.Drawing.Size(100, 21);
            this.AccountTypeComboBox.TabIndex = 2;
            this.AccountTypeComboBox.KeyUp += new System.Windows.Forms.KeyEventHandler(this.AccountTypeComboBox_KeyUp);
            // 
            // editButton
            // 
            this.editButton.Image = global::negar.Properties.Resources.if_081_Pen_183209__1_;
            this.editButton.ImageAlign = System.Drawing.ContentAlignment.TopLeft;
            this.editButton.Location = new System.Drawing.Point(11, 175);
            this.editButton.Name = "editButton";
            this.editButton.Size = new System.Drawing.Size(69, 23);
            this.editButton.TabIndex = 9;
            this.editButton.Text = "ویرایش";
            this.editButton.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.editButton.UseVisualStyleBackColor = true;
            this.editButton.Click += new System.EventHandler(this.editButton_Click);
            // 
            // placeComboBox
            // 
            this.placeComboBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)));
            this.placeComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.placeComboBox.FormattingEnabled = true;
            this.placeComboBox.Location = new System.Drawing.Point(-26, 218);
            this.placeComboBox.Name = "placeComboBox";
            this.placeComboBox.Size = new System.Drawing.Size(100, 21);
            this.placeComboBox.TabIndex = 7;
            this.placeComboBox.KeyUp += new System.Windows.Forms.KeyEventHandler(this.placeComboBox_KeyUp);
            // 
            // label10
            // 
            this.label10.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)));
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Arial Narrow", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.ForeColor = System.Drawing.SystemColors.Desktop;
            this.label10.Location = new System.Drawing.Point(192, 19);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(67, 15);
            this.label10.TabIndex = 62;
            this.label10.Text = "صاحب سپرده";
            // 
            // label8
            // 
            this.label8.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)));
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(190, 72);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(52, 13);
            this.label8.TabIndex = 60;
            this.label8.Text = " کد بودجه";
            // 
            // label7
            // 
            this.label7.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)));
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(190, 98);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(40, 13);
            this.label7.TabIndex = 59;
            this.label7.Text = "واریزی";
            // 
            // label6
            // 
            this.label6.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)));
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(190, 45);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(55, 13);
            this.label6.TabIndex = 58;
            this.label6.Text = "نوع حساب";
            // 
            // label5
            // 
            this.label5.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)));
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(192, 124);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(41, 13);
            this.label5.TabIndex = 57;
            this.label5.Text = "استرداد";
            // 
            // label3
            // 
            this.label3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)));
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(190, 150);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(51, 13);
            this.label3.TabIndex = 55;
            this.label3.Text = "کد سپرده";
            // 
            // DepositDetailtextBox
            // 
            this.DepositDetailtextBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)));
            this.DepositDetailtextBox.Location = new System.Drawing.Point(86, 150);
            this.DepositDetailtextBox.Name = "DepositDetailtextBox";
            this.DepositDetailtextBox.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.DepositDetailtextBox.Size = new System.Drawing.Size(100, 20);
            this.DepositDetailtextBox.TabIndex = 8;
            this.DepositDetailtextBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.DepositDetailtextBox_KeyPress);
            this.DepositDetailtextBox.KeyUp += new System.Windows.Forms.KeyEventHandler(this.DepositDetailtextBox_KeyUp);
            // 
            // BudgetCodetextBox
            // 
            this.BudgetCodetextBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)));
            this.BudgetCodetextBox.Location = new System.Drawing.Point(86, 72);
            this.BudgetCodetextBox.Name = "BudgetCodetextBox";
            this.BudgetCodetextBox.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.BudgetCodetextBox.Size = new System.Drawing.Size(100, 20);
            this.BudgetCodetextBox.TabIndex = 4;
            this.BudgetCodetextBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.BudgetCodetextBox_KeyPress);
            this.BudgetCodetextBox.KeyUp += new System.Windows.Forms.KeyEventHandler(this.BudgetCodetextBox_KeyUp);
            // 
            // DepositTextBox
            // 
            this.DepositTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)));
            this.DepositTextBox.Location = new System.Drawing.Point(86, 98);
            this.DepositTextBox.Name = "DepositTextBox";
            this.DepositTextBox.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.DepositTextBox.Size = new System.Drawing.Size(100, 20);
            this.DepositTextBox.TabIndex = 5;
            this.DepositTextBox.Tag = "";
            this.DepositTextBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.DepositTextBox_KeyPress);
            this.DepositTextBox.KeyUp += new System.Windows.Forms.KeyEventHandler(this.DepositTextBox_KeyUp);
            // 
            // DepositOwnerDetailTextBox
            // 
            this.DepositOwnerDetailTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)));
            this.DepositOwnerDetailTextBox.Location = new System.Drawing.Point(86, 19);
            this.DepositOwnerDetailTextBox.Name = "DepositOwnerDetailTextBox";
            this.DepositOwnerDetailTextBox.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.DepositOwnerDetailTextBox.Size = new System.Drawing.Size(100, 20);
            this.DepositOwnerDetailTextBox.TabIndex = 0;
            this.DepositOwnerDetailTextBox.KeyUp += new System.Windows.Forms.KeyEventHandler(this.DepositOwnerDetailTextBox_KeyUp);
            // 
            // billDetailCodetextBox
            // 
            this.billDetailCodetextBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)));
            this.billDetailCodetextBox.Location = new System.Drawing.Point(-26, 192);
            this.billDetailCodetextBox.Name = "billDetailCodetextBox";
            this.billDetailCodetextBox.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.billDetailCodetextBox.Size = new System.Drawing.Size(100, 20);
            this.billDetailCodetextBox.TabIndex = 3;
            this.billDetailCodetextBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.billDetailCodetextBox_KeyPress);
            this.billDetailCodetextBox.KeyUp += new System.Windows.Forms.KeyEventHandler(this.billDetailCodetextBox_KeyUp);
            // 
            // refundTextBox
            // 
            this.refundTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)));
            this.refundTextBox.Location = new System.Drawing.Point(86, 124);
            this.refundTextBox.Name = "refundTextBox";
            this.refundTextBox.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.refundTextBox.Size = new System.Drawing.Size(100, 20);
            this.refundTextBox.TabIndex = 6;
            this.refundTextBox.Tag = "refund";
            this.refundTextBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.refundTextBox_KeyPress);
            this.refundTextBox.KeyUp += new System.Windows.Forms.KeyEventHandler(this.refundTextBox_KeyUp);
            // 
            // dateMaskedTextBox
            // 
            this.dateMaskedTextBox.Location = new System.Drawing.Point(6, 238);
            this.dateMaskedTextBox.Mask = "00/00/00";
            this.dateMaskedTextBox.Name = "dateMaskedTextBox";
            this.dateMaskedTextBox.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.dateMaskedTextBox.Size = new System.Drawing.Size(100, 20);
            this.dateMaskedTextBox.TabIndex = 1;
            this.dateMaskedTextBox.TextMaskFormat = System.Windows.Forms.MaskFormat.ExcludePromptAndLiterals;
            this.dateMaskedTextBox.KeyUp += new System.Windows.Forms.KeyEventHandler(this.dateMaskedTextBox_KeyUp);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.DepositOwnerDetailTextBox);
            this.groupBox1.Controls.Add(this.dateMaskedTextBox);
            this.groupBox1.Controls.Add(this.editButton);
            this.groupBox1.Controls.Add(this.refundTextBox);
            this.groupBox1.Controls.Add(this.AccountTypeComboBox);
            this.groupBox1.Controls.Add(this.billDetailCodetextBox);
            this.groupBox1.Controls.Add(this.DepositTextBox);
            this.groupBox1.Controls.Add(this.BudgetCodetextBox);
            this.groupBox1.Controls.Add(this.placeComboBox);
            this.groupBox1.Controls.Add(this.DepositDetailtextBox);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label10);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.label8);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox1.Location = new System.Drawing.Point(0, 0);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.groupBox1.Size = new System.Drawing.Size(266, 203);
            this.groupBox1.TabIndex = 63;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "ویرایش";
            // 
            // inputErrorProvider
            // 
            this.inputErrorProvider.ContainerControl = this;
            this.inputErrorProvider.RightToLeft = true;
            // 
            // EditForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(266, 203);
            this.Controls.Add(this.groupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "EditForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "فرم ویرایش";
            this.Load += new System.EventHandler(this.EditForm_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.EditForm_KeyDown);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.inputErrorProvider)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ComboBox AccountTypeComboBox;
        private System.Windows.Forms.Button editButton;
        private System.Windows.Forms.ComboBox placeComboBox;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox DepositDetailtextBox;
        private System.Windows.Forms.TextBox BudgetCodetextBox;
        private System.Windows.Forms.TextBox DepositTextBox;
        private System.Windows.Forms.TextBox DepositOwnerDetailTextBox;
        private System.Windows.Forms.TextBox billDetailCodetextBox;
        private System.Windows.Forms.TextBox refundTextBox;
        private System.Windows.Forms.MaskedTextBox dateMaskedTextBox;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.ErrorProvider inputErrorProvider;
    }
}