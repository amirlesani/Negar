namespace negar
{
    partial class ManagerForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ManagerForm));
            this.colorDialog1 = new System.Windows.Forms.ColorDialog();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.persmissionCheckBox = new System.Windows.Forms.CheckBox();
            this.cityComboBox = new System.Windows.Forms.ComboBox();
            this.cityTableBindingSource2 = new System.Windows.Forms.BindingSource(this.components);
            this.maliDataSetBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.maliDataSet = new negar.MaliDataSet();
            this.familyLabel = new System.Windows.Forms.Label();
            this.nameLabel = new System.Windows.Forms.Label();
            this.familyTextBox = new System.Windows.Forms.TextBox();
            this.nameTextBox = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.removeButton = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.addButton = new System.Windows.Forms.Button();
            this.userNameTextBox = new System.Windows.Forms.TextBox();
            this.passWordTextBox = new System.Windows.Forms.TextBox();
            this.usersDataGridView = new System.Windows.Forms.DataGridView();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.cityDataGridView = new System.Windows.Forms.DataGridView();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.button3 = new System.Windows.Forms.Button();
            this.CityTextBox = new System.Windows.Forms.TextBox();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.button4 = new System.Windows.Forms.Button();
            this.IDTextBox = new System.Windows.Forms.TextBox();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.dgvColor = new System.Windows.Forms.Button();
            this.cityTableBindingSource1 = new System.Windows.Forms.BindingSource(this.components);
            this.daftarDataSet2 = new negar.DaftarDataSet2();
            this.cityTableTableAdapter1 = new negar.DaftarDataSet2TableAdapters.CityTableTableAdapter();
            this.cityTableBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.daftarTableBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.cityTableTableAdapter2 = new negar.MaliDataSetTableAdapters.CityTableTableAdapter();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cityTableBindingSource2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.maliDataSetBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.maliDataSet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.usersDataGridView)).BeginInit();
            this.tabPage2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cityDataGridView)).BeginInit();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            this.tabPage3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cityTableBindingSource1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.daftarDataSet2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cityTableBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.daftarTableBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Controls.Add(this.tabPage3);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Location = new System.Drawing.Point(0, 0);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.tabControl1.RightToLeftLayout = true;
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(763, 551);
            this.tabControl1.TabIndex = 2;
            this.tabControl1.Selected += new System.Windows.Forms.TabControlEventHandler(this.tabControl1_Selected);
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.groupBox1);
            this.tabPage1.Controls.Add(this.usersDataGridView);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(755, 525);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "مدیریت کاربران";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.persmissionCheckBox);
            this.groupBox1.Controls.Add(this.cityComboBox);
            this.groupBox1.Controls.Add(this.familyLabel);
            this.groupBox1.Controls.Add(this.nameLabel);
            this.groupBox1.Controls.Add(this.familyTextBox);
            this.groupBox1.Controls.Add(this.nameTextBox);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.removeButton);
            this.groupBox1.Controls.Add(this.pictureBox1);
            this.groupBox1.Controls.Add(this.addButton);
            this.groupBox1.Controls.Add(this.userNameTextBox);
            this.groupBox1.Controls.Add(this.passWordTextBox);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox1.Location = new System.Drawing.Point(3, 3);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.groupBox1.Size = new System.Drawing.Size(749, 223);
            this.groupBox1.TabIndex = 9;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "مدیر کاربری";
            // 
            // persmissionCheckBox
            // 
            this.persmissionCheckBox.AutoSize = true;
            this.persmissionCheckBox.Location = new System.Drawing.Point(597, 157);
            this.persmissionCheckBox.Name = "persmissionCheckBox";
            this.persmissionCheckBox.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.persmissionCheckBox.Size = new System.Drawing.Size(134, 17);
            this.persmissionCheckBox.TabIndex = 15;
            this.persmissionCheckBox.Text = "دسترسی به همه شهرها";
            this.persmissionCheckBox.UseVisualStyleBackColor = true;
            // 
            // cityComboBox
            // 
            this.cityComboBox.DataSource = this.cityTableBindingSource2;
            this.cityComboBox.DisplayMember = "CityName";
            this.cityComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cityComboBox.FormattingEnabled = true;
            this.cityComboBox.Location = new System.Drawing.Point(530, 79);
            this.cityComboBox.Name = "cityComboBox";
            this.cityComboBox.Size = new System.Drawing.Size(121, 21);
            this.cityComboBox.TabIndex = 14;
            this.cityComboBox.ValueMember = "Id";
            // 
            // cityTableBindingSource2
            // 
            this.cityTableBindingSource2.DataMember = "CityTable";
            this.cityTableBindingSource2.DataSource = this.maliDataSetBindingSource;
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
            // familyLabel
            // 
            this.familyLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)));
            this.familyLabel.AutoSize = true;
            this.familyLabel.Location = new System.Drawing.Point(657, 51);
            this.familyLabel.Name = "familyLabel";
            this.familyLabel.Size = new System.Drawing.Size(69, 13);
            this.familyLabel.TabIndex = 13;
            this.familyLabel.Text = "نام خانوادگی";
            // 
            // nameLabel
            // 
            this.nameLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)));
            this.nameLabel.AutoSize = true;
            this.nameLabel.Location = new System.Drawing.Point(706, 19);
            this.nameLabel.Name = "nameLabel";
            this.nameLabel.Size = new System.Drawing.Size(20, 13);
            this.nameLabel.TabIndex = 12;
            this.nameLabel.Text = "نام";
            // 
            // familyTextBox
            // 
            this.familyTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)));
            this.familyTextBox.Location = new System.Drawing.Point(551, 48);
            this.familyTextBox.Name = "familyTextBox";
            this.familyTextBox.Size = new System.Drawing.Size(100, 20);
            this.familyTextBox.TabIndex = 11;
            // 
            // nameTextBox
            // 
            this.nameTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)));
            this.nameTextBox.Location = new System.Drawing.Point(551, 19);
            this.nameTextBox.Name = "nameTextBox";
            this.nameTextBox.Size = new System.Drawing.Size(100, 20);
            this.nameTextBox.TabIndex = 10;
            // 
            // label3
            // 
            this.label3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)));
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(699, 83);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(27, 13);
            this.label3.TabIndex = 9;
            this.label3.Text = "شهر";
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)));
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(679, 137);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(47, 13);
            this.label2.TabIndex = 8;
            this.label2.Text = "گذر واژه";
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)));
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(668, 109);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(58, 13);
            this.label1.TabIndex = 7;
            this.label1.Text = "نام کاربری";
            // 
            // removeButton
            // 
            this.removeButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)));
            this.removeButton.Image = global::negar.Properties.Resources.Actions_list_remove_icon;
            this.removeButton.Location = new System.Drawing.Point(633, 180);
            this.removeButton.Name = "removeButton";
            this.removeButton.Size = new System.Drawing.Size(42, 26);
            this.removeButton.TabIndex = 5;
            this.removeButton.UseVisualStyleBackColor = true;
            this.removeButton.Click += new System.EventHandler(this.removeButton_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::negar.Properties.Resources.user;
            this.pictureBox1.Location = new System.Drawing.Point(44, 19);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(141, 145);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // addButton
            // 
            this.addButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)));
            this.addButton.Image = global::negar.Properties.Resources.add_icon__1_;
            this.addButton.Location = new System.Drawing.Point(681, 180);
            this.addButton.Name = "addButton";
            this.addButton.Size = new System.Drawing.Size(42, 26);
            this.addButton.TabIndex = 4;
            this.addButton.UseVisualStyleBackColor = true;
            this.addButton.Click += new System.EventHandler(this.addButton_Click);
            // 
            // userNameTextBox
            // 
            this.userNameTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)));
            this.userNameTextBox.Location = new System.Drawing.Point(551, 106);
            this.userNameTextBox.Name = "userNameTextBox";
            this.userNameTextBox.Size = new System.Drawing.Size(100, 20);
            this.userNameTextBox.TabIndex = 1;
            // 
            // passWordTextBox
            // 
            this.passWordTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)));
            this.passWordTextBox.Location = new System.Drawing.Point(551, 130);
            this.passWordTextBox.Name = "passWordTextBox";
            this.passWordTextBox.Size = new System.Drawing.Size(100, 20);
            this.passWordTextBox.TabIndex = 2;
            // 
            // usersDataGridView
            // 
            this.usersDataGridView.AllowUserToAddRows = false;
            this.usersDataGridView.AllowUserToDeleteRows = false;
            this.usersDataGridView.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.usersDataGridView.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.DisplayedHeaders;
            this.usersDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.usersDataGridView.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.usersDataGridView.Location = new System.Drawing.Point(3, 232);
            this.usersDataGridView.Name = "usersDataGridView";
            this.usersDataGridView.ReadOnly = true;
            this.usersDataGridView.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.usersDataGridView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.usersDataGridView.Size = new System.Drawing.Size(749, 290);
            this.usersDataGridView.TabIndex = 8;
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.cityDataGridView);
            this.tabPage2.Controls.Add(this.groupBox2);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(755, 525);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "مدیریت شهرها";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // cityDataGridView
            // 
            this.cityDataGridView.AllowUserToAddRows = false;
            this.cityDataGridView.AllowUserToDeleteRows = false;
            this.cityDataGridView.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.cityDataGridView.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.DisplayedHeaders;
            this.cityDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.cityDataGridView.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.cityDataGridView.Location = new System.Drawing.Point(3, 216);
            this.cityDataGridView.Name = "cityDataGridView";
            this.cityDataGridView.ReadOnly = true;
            this.cityDataGridView.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.cityDataGridView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.cityDataGridView.Size = new System.Drawing.Size(749, 306);
            this.cityDataGridView.TabIndex = 10;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Controls.Add(this.label5);
            this.groupBox2.Controls.Add(this.button3);
            this.groupBox2.Controls.Add(this.CityTextBox);
            this.groupBox2.Controls.Add(this.pictureBox2);
            this.groupBox2.Controls.Add(this.button4);
            this.groupBox2.Controls.Add(this.IDTextBox);
            this.groupBox2.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox2.Location = new System.Drawing.Point(3, 3);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.groupBox2.Size = new System.Drawing.Size(749, 207);
            this.groupBox2.TabIndex = 11;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "مدیریت شهرها";
            // 
            // label4
            // 
            this.label4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)));
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(697, 62);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(46, 13);
            this.label4.TabIndex = 9;
            this.label4.Text = " نام شهر";
            // 
            // label5
            // 
            this.label5.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)));
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(682, 33);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(61, 13);
            this.label5.TabIndex = 8;
            this.label5.Text = "شناسه شهر";
            // 
            // button3
            // 
            this.button3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)));
            this.button3.Image = global::negar.Properties.Resources.Actions_list_remove_icon;
            this.button3.Location = new System.Drawing.Point(571, 85);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(42, 24);
            this.button3.TabIndex = 5;
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // CityTextBox
            // 
            this.CityTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)));
            this.CityTextBox.Location = new System.Drawing.Point(561, 59);
            this.CityTextBox.Name = "CityTextBox";
            this.CityTextBox.Size = new System.Drawing.Size(100, 20);
            this.CityTextBox.TabIndex = 3;
            // 
            // pictureBox2
            // 
            this.pictureBox2.Image = global::negar.Properties.Resources.map_0000;
            this.pictureBox2.Location = new System.Drawing.Point(26, 30);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(137, 131);
            this.pictureBox2.TabIndex = 0;
            this.pictureBox2.TabStop = false;
            // 
            // button4
            // 
            this.button4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)));
            this.button4.Image = global::negar.Properties.Resources.add_icon__1_;
            this.button4.Location = new System.Drawing.Point(619, 85);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(42, 24);
            this.button4.TabIndex = 4;
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // IDTextBox
            // 
            this.IDTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)));
            this.IDTextBox.Location = new System.Drawing.Point(561, 30);
            this.IDTextBox.Name = "IDTextBox";
            this.IDTextBox.Size = new System.Drawing.Size(100, 20);
            this.IDTextBox.TabIndex = 2;
            // 
            // tabPage3
            // 
            this.tabPage3.Controls.Add(this.dgvColor);
            this.tabPage3.Location = new System.Drawing.Point(4, 22);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Size = new System.Drawing.Size(755, 525);
            this.tabPage3.TabIndex = 2;
            this.tabPage3.Text = "تنظیمات";
            this.tabPage3.UseVisualStyleBackColor = true;
            // 
            // dgvColor
            // 
            this.dgvColor.Location = new System.Drawing.Point(594, 13);
            this.dgvColor.Name = "dgvColor";
            this.dgvColor.Size = new System.Drawing.Size(153, 23);
            this.dgvColor.TabIndex = 0;
            this.dgvColor.Text = "تغییر رنگ جدول  اصلی";
            this.dgvColor.UseVisualStyleBackColor = true;
            this.dgvColor.Click += new System.EventHandler(this.dgvColor_Click);
            // 
            // cityTableBindingSource1
            // 
            this.cityTableBindingSource1.DataMember = "CityTable";
            this.cityTableBindingSource1.DataSource = this.daftarDataSet2;
            // 
            // daftarDataSet2
            // 
            this.daftarDataSet2.DataSetName = "DaftarDataSet2";
            this.daftarDataSet2.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // cityTableTableAdapter1
            // 
            this.cityTableTableAdapter1.ClearBeforeFill = true;
            // 
            // cityTableBindingSource
            // 
            this.cityTableBindingSource.DataMember = "CityTable";
            // 
            // daftarTableBindingSource
            // 
            this.daftarTableBindingSource.DataMember = "DaftarTable";
            // 
            // cityTableTableAdapter2
            // 
            this.cityTableTableAdapter2.ClearBeforeFill = true;
            // 
            // ManagerForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(763, 551);
            this.Controls.Add(this.tabControl1);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "ManagerForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "مدیریت";
            this.Load += new System.EventHandler(this.ManagerForm_Load);
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cityTableBindingSource2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.maliDataSetBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.maliDataSet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.usersDataGridView)).EndInit();
            this.tabPage2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.cityDataGridView)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            this.tabPage3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.cityTableBindingSource1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.daftarDataSet2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cityTableBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.daftarTableBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.ColorDialog colorDialog1;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.ComboBox cityComboBox;
        private System.Windows.Forms.BindingSource cityTableBindingSource1;
        private DaftarDataSet2 daftarDataSet2;
        private System.Windows.Forms.Label familyLabel;
        private System.Windows.Forms.Label nameLabel;
        private System.Windows.Forms.TextBox familyTextBox;
        private System.Windows.Forms.TextBox nameTextBox;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button removeButton;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Button addButton;
        private System.Windows.Forms.TextBox userNameTextBox;
        private System.Windows.Forms.TextBox passWordTextBox;
        private System.Windows.Forms.DataGridView usersDataGridView;
        private DaftarDataSet2TableAdapters.CityTableTableAdapter cityTableTableAdapter1;
        private System.Windows.Forms.BindingSource cityTableBindingSource;
        private System.Windows.Forms.BindingSource daftarTableBindingSource;
        private System.Windows.Forms.DataGridView cityDataGridView;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.TextBox CityTextBox;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.TextBox IDTextBox;
        private System.Windows.Forms.TabPage tabPage3;
        private System.Windows.Forms.Button dgvColor;
        private System.Windows.Forms.CheckBox persmissionCheckBox;
        private System.Windows.Forms.BindingSource maliDataSetBindingSource;
        private MaliDataSet maliDataSet;
        private System.Windows.Forms.BindingSource cityTableBindingSource2;
        private MaliDataSetTableAdapters.CityTableTableAdapter cityTableTableAdapter2;
    }
}