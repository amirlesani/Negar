namespace negar
{
    partial class ImportExcel
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ImportExcel));
            this.importAllButton = new System.Windows.Forms.Button();
            this.excelMonthscomboBox = new System.Windows.Forms.ComboBox();
            this.openButton1 = new System.Windows.Forms.Button();
            this.importButton1 = new System.Windows.Forms.Button();
            this.excelDataGridView = new System.Windows.Forms.DataGridView();
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.cityComboBox = new System.Windows.Forms.ComboBox();
            this.cityTableBindingSource1 = new System.Windows.Forms.BindingSource(this.components);
            this.maliDataSetBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.maliDataSet = new negar.MaliDataSet();
            this.cityTableBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.cityTableTableAdapter = new negar.MaliDataSetTableAdapters.CityTableTableAdapter();
            this.depositRadioButton = new System.Windows.Forms.RadioButton();
            this.refundRadioButton = new System.Windows.Forms.RadioButton();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            ((System.ComponentModel.ISupportInitialize)(this.excelDataGridView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cityTableBindingSource1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.maliDataSetBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.maliDataSet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cityTableBindingSource)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // importAllButton
            // 
            this.importAllButton.Location = new System.Drawing.Point(550, 322);
            this.importAllButton.Name = "importAllButton";
            this.importAllButton.Size = new System.Drawing.Size(146, 23);
            this.importAllButton.TabIndex = 1;
            this.importAllButton.Text = "وارد کردن همه ی ورق ها";
            this.importAllButton.UseVisualStyleBackColor = true;
            this.importAllButton.Visible = false;
            this.importAllButton.Click += new System.EventHandler(this.importAllButton_Click);
            // 
            // excelMonthscomboBox
            // 
            this.excelMonthscomboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.excelMonthscomboBox.FormattingEnabled = true;
            this.excelMonthscomboBox.Location = new System.Drawing.Point(702, 297);
            this.excelMonthscomboBox.Name = "excelMonthscomboBox";
            this.excelMonthscomboBox.Size = new System.Drawing.Size(156, 21);
            this.excelMonthscomboBox.TabIndex = 3;
            this.excelMonthscomboBox.SelectedIndexChanged += new System.EventHandler(this.excelMonthscomboBox_SelectedIndexChanged);
            // 
            // openButton1
            // 
            this.openButton1.Location = new System.Drawing.Point(600, 295);
            this.openButton1.Name = "openButton1";
            this.openButton1.Size = new System.Drawing.Size(96, 23);
            this.openButton1.TabIndex = 2;
            this.openButton1.Text = "باز کردن فایل";
            this.openButton1.UseVisualStyleBackColor = true;
            this.openButton1.Click += new System.EventHandler(this.openButton1_Click);
            // 
            // importButton1
            // 
            this.importButton1.Location = new System.Drawing.Point(498, 295);
            this.importButton1.Name = "importButton1";
            this.importButton1.Size = new System.Drawing.Size(96, 23);
            this.importButton1.TabIndex = 0;
            this.importButton1.Text = "وارد کردن";
            this.importButton1.UseVisualStyleBackColor = true;
            this.importButton1.Click += new System.EventHandler(this.importButton1_Click);
            // 
            // excelDataGridView
            // 
            this.excelDataGridView.AllowUserToAddRows = false;
            this.excelDataGridView.AllowUserToDeleteRows = false;
            this.excelDataGridView.AllowUserToOrderColumns = true;
            this.excelDataGridView.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.DisplayedCells;
            this.excelDataGridView.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.DisplayedCells;
            this.excelDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.excelDataGridView.Dock = System.Windows.Forms.DockStyle.Top;
            this.excelDataGridView.Location = new System.Drawing.Point(0, 0);
            this.excelDataGridView.Name = "excelDataGridView";
            this.excelDataGridView.ReadOnly = true;
            this.excelDataGridView.Size = new System.Drawing.Size(859, 289);
            this.excelDataGridView.TabIndex = 5;
            // 
            // cityComboBox
            // 
            this.cityComboBox.DataBindings.Add(new System.Windows.Forms.Binding("SelectedValue", this.cityTableBindingSource1, "CityName", true));
            this.cityComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cityComboBox.FormattingEnabled = true;
            this.cityComboBox.Location = new System.Drawing.Point(702, 324);
            this.cityComboBox.Name = "cityComboBox";
            this.cityComboBox.Size = new System.Drawing.Size(156, 21);
            this.cityComboBox.TabIndex = 4;
            this.cityComboBox.SelectedIndexChanged += new System.EventHandler(this.cityComboBox_SelectedIndexChanged);
            // 
            // cityTableBindingSource1
            // 
            this.cityTableBindingSource1.DataMember = "CityTable";
            this.cityTableBindingSource1.DataSource = this.maliDataSetBindingSource;
            // 
            // maliDataSetBindingSource
            // 
            this.maliDataSetBindingSource.DataSource = this.maliDataSet;
            this.maliDataSetBindingSource.Position = 0;
            // 
            // maliDataSet
            // 
            this.maliDataSet.DataSetName = "MaliDataSet";
            this.maliDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // cityTableBindingSource
            // 
            this.cityTableBindingSource.DataMember = "CityTable";
            this.cityTableBindingSource.DataSource = this.maliDataSetBindingSource;
            // 
            // cityTableTableAdapter
            // 
            this.cityTableTableAdapter.ClearBeforeFill = true;
            // 
            // depositRadioButton
            // 
            this.depositRadioButton.AutoSize = true;
            this.depositRadioButton.Location = new System.Drawing.Point(115, 16);
            this.depositRadioButton.Name = "depositRadioButton";
            this.depositRadioButton.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.depositRadioButton.Size = new System.Drawing.Size(78, 17);
            this.depositRadioButton.TabIndex = 6;
            this.depositRadioButton.TabStop = true;
            this.depositRadioButton.Text = "دریافت وجه";
            this.depositRadioButton.UseVisualStyleBackColor = true;
            this.depositRadioButton.CheckedChanged += new System.EventHandler(this.depositRadioButton_CheckedChanged);
            this.depositRadioButton.Click += new System.EventHandler(this.depositRadioButton_Click);
            // 
            // refundRadioButton
            // 
            this.refundRadioButton.AutoSize = true;
            this.refundRadioButton.Location = new System.Drawing.Point(6, 16);
            this.refundRadioButton.Name = "refundRadioButton";
            this.refundRadioButton.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.refundRadioButton.Size = new System.Drawing.Size(103, 17);
            this.refundRadioButton.TabIndex = 7;
            this.refundRadioButton.TabStop = true;
            this.refundRadioButton.Text = "سپرده استهلاکی";
            this.refundRadioButton.UseVisualStyleBackColor = true;
            this.refundRadioButton.CheckedChanged += new System.EventHandler(this.refundRadioButton_CheckedChanged);
            this.refundRadioButton.Click += new System.EventHandler(this.refundRadioButton_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Controls.Add(this.refundRadioButton);
            this.groupBox1.Controls.Add(this.depositRadioButton);
            this.groupBox1.Location = new System.Drawing.Point(9, 300);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.groupBox1.Size = new System.Drawing.Size(263, 45);
            this.groupBox1.TabIndex = 8;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "نوع فایل";
            // 
            // ImportExcel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ClientSize = new System.Drawing.Size(859, 357);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.cityComboBox);
            this.Controls.Add(this.importAllButton);
            this.Controls.Add(this.excelMonthscomboBox);
            this.Controls.Add(this.openButton1);
            this.Controls.Add(this.importButton1);
            this.Controls.Add(this.excelDataGridView);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(2);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "ImportExcel";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "فرم نمایش  اکسل";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.ImportExcel_FormClosing);
            this.Load += new System.EventHandler(this.Main_Load);
            ((System.ComponentModel.ISupportInitialize)(this.excelDataGridView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cityTableBindingSource1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.maliDataSetBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.maliDataSet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cityTableBindingSource)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button importAllButton;
        private System.Windows.Forms.ComboBox excelMonthscomboBox;
        private System.Windows.Forms.Button openButton1;
        private System.Windows.Forms.Button importButton1;
        private System.Windows.Forms.DataGridView excelDataGridView;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private System.Windows.Forms.ComboBox cityComboBox;
        private MaliDataSet maliDataSet;
        private System.Windows.Forms.BindingSource maliDataSetBindingSource;
        private MaliDataSetTableAdapters.CityTableTableAdapter cityTableTableAdapter;
        private System.Windows.Forms.BindingSource cityTableBindingSource;
        private System.Windows.Forms.BindingSource cityTableBindingSource1;
        private System.Windows.Forms.RadioButton depositRadioButton;
        private System.Windows.Forms.RadioButton refundRadioButton;
        private System.Windows.Forms.GroupBox groupBox1;
    }
}