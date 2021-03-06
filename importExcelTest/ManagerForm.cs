﻿using PersianDate;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace negar
{
    public partial class ManagerForm : Form
    {
        int selectedRow;
        private MaxMinClass startendDate;
        private MainForm mainForm;
        private LoginInfo login;
        public ManagerForm(MainForm main,LoginInfo login)
        {
            InitializeComponent();
            this.mainForm = main;
            this.login = login;
            if (!this.login.adminVersion) { this.ControlTab.TabPages.Remove(tabPage3); };

        }
        private Boolean changeColumnName()
        {
            try
            {

                usersDataGridView.Columns[0].HeaderText = "شناسه";
                usersDataGridView.Columns[1].HeaderText = "نام ";
                usersDataGridView.Columns[2].HeaderText = " نام خانوادگی";
                usersDataGridView.Columns[3].HeaderText = "نام کاربری";
                usersDataGridView.Columns[4].HeaderText = "گذر واژه";
                usersDataGridView.Columns[5].HeaderText = "دسترسی";
                usersDataGridView.Columns[6].HeaderText = "دسترسی ادمین";
                usersDataGridView.Columns[7].HeaderText = "پیغام";
                usersDataGridView.Columns[8].HeaderText = "شهر";



                return true;
            }
            catch(Exception )
            {
                MessageBox.Show("خطایی در جدول پیش آمده است");
                return false;
            }

        }
        private Boolean changeValidationTableColumnNames()
        {
            try
            {
                
                this.validationDataGridView.Columns[0].HeaderText = "شناسه";
                this.validationDataGridView.Columns[1].HeaderText = "توضیحات ";
                this.validationDataGridView.Columns[2].HeaderText = " شهر";
                this.validationDataGridView.Columns[3].HeaderText = "شروع";
                this.validationDataGridView.Columns[4].HeaderText = "پایان";

                return true;
            }
            catch (Exception)
            {
                MessageBox.Show("خطایی در جدول پیش آمده است");
                return false;
            }

        }
        private Boolean changeCityDGVname()
        {
            try
            {
                cityDataGridView.Columns[0].HeaderText = "شهر";
                cityDataGridView.Columns[1].HeaderText = "شناسه";
                DGV_SetStyle(cityDataGridView);

                return true;
            }
            catch ( Exception)
            {
                MessageBox.Show("خطایی در جدول پیش آمده است");
                return false;
            }

        }

        private void ManagerForm_Load(object sender, EventArgs e)
        {
          
            ExtensionMethods.DoubleBuffered(this.usersDataGridView,true);
            selectedRow = 0;
            SqlManipulator sql = new SqlManipulator();
            try
            {
                makeTableUsers(sql.getDataLogin());
                //usersDataGridView.Columns[0].Visible = false;
                var cities = sql.queryCities();
                cityComboBox.DataSource = cities;

                // this.cityTableTableAdapter.Fill(this.daftarDataSet1.CityTable);
                makeTable(sql.getDataCity());
                makeTableUsers(sql.getDataLogin());
                makeValidationTable(sql.getValidationData());
                startendDate = sql.findMaxminMonthDay(0);
                this.versionTextBox.Text = global.currentVersion.ToString();
                this.versionTextBox.Enabled = false;
                DGV_SetStyle(this.cityDataGridView);


                changeCityDGVname();

                changeColumnName();
                selectedRow = 0;

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void addButton_Click(object sender, EventArgs e)
        {
            UserTable newLogin = new UserTable();
            newLogin.Name = nameTextBox.Text;
            newLogin.Family = familyTextBox.Text;
            newLogin.User = userNameTextBox.Text;
            newLogin.Password = passWordTextBox.Text;
            newLogin.City = Convert.ToInt64(cityComboBox.SelectedValue);
            newLogin.Permission = persmissionCheckBox.Checked;
            newLogin.AdminVersion = AdminCheckBox.Checked;
            newLogin.Update = false;
            newLogin.Messages = " ";
            newLogin.Version = global.currentVersion;

            SqlManipulator sql = new SqlManipulator();
            Reporter rpt = new Reporter(sql.addUser(newLogin), (int)errorImages.info);
            rpt.Show();
            makeTableUsers(sql.getDataLogin());
        }

        private void removeButton_Click(object sender, EventArgs e)
        {
            try {
               
                DialogResult dialogResult = MessageBox.Show("آیا از حذف مطمئن هستید؟", "هشدار", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (dialogResult == DialogResult.Yes)
                {
                    selectedRow = usersDataGridView.CurrentCell.RowIndex;
                    SqlManipulator sql = new SqlManipulator();
                    DataGridViewRow newDataRow = usersDataGridView.Rows[selectedRow];
                    UserTable deletePerson = new UserTable();
                    deletePerson.Id = (int)newDataRow.Cells[0].Value;
                    deletePerson.User = (string)newDataRow.Cells[1].Value;
                    deletePerson.Password = (string)newDataRow.Cells[2].Value;

                    if (login.Id == deletePerson.Id)
                    {
                        MessageBox.Show("این کاربر مجوز حذف خود را ندارد", "پیغام سیستم ", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        return;
                    }
                    sql.removeUser(deletePerson);
                    var logindata = sql.getDataLogin();
                    makeTableUsers(logindata);
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void makeTableUsers(IQueryable accounts)
        {  
            usersDataGridView.DataSource = accounts;

            changeColumnName();
            DGV_SetStyle(usersDataGridView);
          
        }
        public void DGV_SetStyle(DataGridView Dgv)
        {

            Dgv.RowsDefaultCellStyle.BackColor = Color.Bisque;
            Dgv.AlternatingRowsDefaultCellStyle.BackColor = Properties.Settings.Default.dgvColor;
            Dgv.DefaultCellStyle.WrapMode = DataGridViewTriState.True;
            Dgv.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            
            //Dgv.AutoResizeColumns();
            foreach(DataGridViewColumn col in Dgv.Columns)
            {
                col.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            }
            Dgv.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
            Dgv.Refresh();
            Dgv.Invalidate();
        }


        private void tabControl1_Selected(object sender, TabControlEventArgs e)
        {
            if (e.TabPage == tabPage1)
            {
                selectedRow = 0;
                
                SqlManipulator sql = new SqlManipulator();
                try
                {
                    makeTableUsers(sql.getDataLogin());
                    
                   /// usersDataGridView.Columns[0].Visible = false;
                    var cities = sql.queryCities();
                    cityComboBox.DataSource = cities;
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.ToString());
                }

            }
            if(e.TabPage == tabPage2)

            {
                selectedRow = 0;
                SqlManipulator sql = new SqlManipulator();
                makeTable(sql.getDataCity());

            }
            if(e.TabPage == tabPage4)
            {
                try {
                   
                    SqlManipulator sql = new SqlManipulator();
                    makeValidationTable(sql.getValidationData());
                    var cities = sql.queryCities();
                    validCityComboBox.DataSource = cities;
                }
                catch(Exception  ex)
                {
                    MessageBox.Show(ex.ToString());
                }

            }
        }

        private void addCityToFormManagerButton_Click(object sender, EventArgs e)
        {
            try {
                CityTable newCity = new CityTable();
                newCity.CityName = CityTextBox.Text;
                newCity.Id = Convert.ToInt64(IDTextBox.Text);
                SqlManipulator sql = new SqlManipulator();
                if (sql.addCity(newCity))
                {
                    makeTable(sql.getDataCity());
                    MessageBox.Show("با موفقیت شهر مورد نظر اضافه گردید");
                    mainForm.setCityComboBox();

                }
                else
                {
                    MessageBox.Show("خطا");
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }
        private void makeTable(IQueryable cities)
        {
            cityDataGridView.DataSource = cities;
            changeCityDGVname();
            DGV_SetStyle(this.cityDataGridView);
        }
        private void makeValidationTable(IQueryable validationData)
        {
            validationDataGridView.DataSource = validationData;
            DGV_SetStyle(this.validationDataGridView);
            changeValidationTableColumnNames();
        }

        private void RemoveButton_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("آیا از حذف مطمئن هستید؟", "هشدار", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (dialogResult == DialogResult.Yes)
            {
                try {
                    selectedRow = cityDataGridView.CurrentCell.RowIndex;
                    SqlManipulator sql = new SqlManipulator();
                    DataGridViewRow newDataRow = cityDataGridView.Rows[selectedRow];
                    CityTable deletedCity = new CityTable();

                    deletedCity.Id = (long)newDataRow.Cells[1].Value;
                    deletedCity.CityName = (string)newDataRow.Cells[0].Value;
                    sql.removeCity(deletedCity);
                    var cityData = sql.getDataCity();
                    makeTable(cityData);
                }
                catch(Exception)
                {
                    throw;
                }
            }
        }

        

        private void addRestrictionButton_Click(object sender, EventArgs e)
        {
            addRestriction();
            
        }
        private void addRestriction()
        {
            try
            {
                validationTable valid = new validationTable();

                DateTime endTime = endDateTimePickerX1.SelectedDateInDateTime;

                StartEndMonthClass date = new StartEndMonthClass();

                date.endDate = Convert.ToInt64(endTime.ToFa("yyyyMMdd"));

                valid.startDate = startendDate.min;
                valid.enDate = date.endDate;
                valid.City = Convert.ToInt64(validCityComboBox.SelectedValue);
                SqlManipulator sql = new SqlManipulator();

                //if (this.lockAllCitiesCheckBox.Checked == true)
                //{
                //    var cities = sql.getDataCity();
                //    foreach(var city in cities)
                //    {
                        
                //    }
                //}
                var cityName = sql.getCityName(valid.City);
                FarsiDateUtil startDate = new FarsiDateUtil(startendDate.min.ToString());
                FarsiDateUtil endDate = new FarsiDateUtil(date.endDate.ToString());
                valid.description = "قفل" + " " + cityName + "  " + endDate.MonthName + endDate.Year;
                Reporter rpt = new Reporter(sql.addValidation(valid), (int)errorImages.info);
                rpt.Show();
                makeValidationTable(sql.getValidationData());

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());

            }
        }

        private void deleteRestrictionButton_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("آیا از حذف مطمئن هستید؟", "هشدار", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (dialogResult == DialogResult.Yes)
            {
               
                try {
                selectedRow = validationDataGridView.CurrentCell.RowIndex;

                SqlManipulator sql = new SqlManipulator();
                DataGridViewRow newDataRow = validationDataGridView.Rows[selectedRow];
                validationTable deletedRestriction = new validationTable();


                deletedRestriction.City = (long)newDataRow.Cells[2].Value;
                deletedRestriction.startDate = (long)newDataRow.Cells[3].Value;
                deletedRestriction.enDate = (long)newDataRow.Cells[4].Value;
                deletedRestriction.id = (long)newDataRow.Cells[0].Value;
                deletedRestriction.description = (String)newDataRow.Cells[1].Value;
                sql.removeRestriction(deletedRestriction);
                var data = sql.getValidationData();
                makeValidationTable(data);
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            }
        }
        
        enum lockOption { manualLock, lockprvMonth,unlockprvMonth};
        int lockValue;
        private void lockchangingRadioButton(object sender, EventArgs e)
        {
            RadioButton btn = sender as RadioButton;
            if (btn != null && btn.Checked)
            {
                switch (btn.Name)
                {
                    case ("manualLockButton"):
                        lockValue = (int)lockOption.manualLock;
                        break;
                    case ("lockLastMonth"):

                        lockValue = (int)lockOption.lockprvMonth;
                        groupBox2.Enabled = false;
                        break;
                    case ("unlockprvMonth"):
                        ////lock groupbox
                        ///unlock prv month
                        lockValue = (int)lockOption.unlockprvMonth;
                        groupBox2.Enabled = false;
                        break;
                }

            }
        }
        private void lockLastMonth_CheckedChanged(object sender, EventArgs e)
        {

            lockchangingRadioButton(sender,e);
        }

        private void unlockprvMonth_CheckedChanged(object sender, EventArgs e)
        {
            lockchangingRadioButton(sender, e);

        }

        private void usersDataGridView_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.ColumnIndex == 5)
            {
                if (e.Value is bool)
                {
                    bool value = (bool)e.Value;
                    e.Value = (value) ? " مدیر سیستم " : " کاربر ";
                    e.FormattingApplied = true;
                }
            }
            if (e.ColumnIndex == 6)
            {
                if (e.Value is bool)
                {
                    bool value = (bool)e.Value;
                    e.Value = (value) ? " بله " : " خیر ";
                    e.FormattingApplied = true;
                }
                else
                {
                    e.Value = "خیر";

                }
            }
        }

        private void lockAllCitiesCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            //if(this.lockAllCitiesCheckBox.Checked == true)
            //{
            //    this.cityComboBox.Enabled = false;
            //}
        }

        private void ColumnSyncButton_Click(object sender, EventArgs e)
        {
           
        }

        private void sendButton_Click(object sender, EventArgs e)
        {
            SqlManipulator sql = new SqlManipulator();
           if (sql.sendMessages(this.MessageRichTextBox.Text))
            { MessageBox.Show("پیغام با موفقیت ارسال شد ، در ورود جدید به کاربران پیغام شما نمایش خواهد داده شد  "); }
            else { MessageBox.Show("خطایی رخ داده است "); };
        }

        private void updateButton_Click(object sender, EventArgs e)
        {
            try {
                if (activateCheckBox.Checked)
                {
                    SqlManipulator sql = new SqlManipulator();
                   if( sql.sendUpdateNotify(Int32.Parse(this.versionTextBox.Text.ToString())))
                    { MessageBox.Show("با  موفقیت پیام بروزرسانی ارسال شد ، کاربران ملزم به استفاده از  نسخه جدید می باشند "); }
                }
                else
                {
                    this.versionTextBox.Text = global.currentVersion.ToString();
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void activateCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            if(this.activateCheckBox.Checked)
            {
                this.versionTextBox.Enabled = true;
            }
            else
            {
                this.versionTextBox.Enabled = false;
            }
        }
    }
}
