using PersianDate;
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
        
        private MainForm mainForm;

        public ManagerForm(MainForm main)
        {
            InitializeComponent();
            this.mainForm = main;
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
                usersDataGridView.Columns[6].HeaderText = "شهر";
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
                makeTable(sql.getValidationData());

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
            foreach (var a in newLogin.CityTables)
            {
                if (a.Id == newLogin.Id)
                {

                }
            }

            SqlManipulator sql = new SqlManipulator();
            Report rpt = new Report(sql.addUser(newLogin));
            rpt.Show();
            makeTableUsers(sql.getDataLogin());
        }

        private void removeButton_Click(object sender, EventArgs e)
        {
            try {
                selectedRow = usersDataGridView.CurrentCell.RowIndex;
                SqlManipulator sql = new SqlManipulator();
                DataGridViewRow newDataRow = usersDataGridView.Rows[selectedRow];
                UserTable deletePerson = new UserTable();
                deletePerson.Id = (int)newDataRow.Cells[0].Value;
                deletePerson.User = (string)newDataRow.Cells[1].Value;
                deletePerson.Password = (string)newDataRow.Cells[2].Value;
                sql.removeUser(deletePerson);
                var logindata = sql.getDataLogin();
                makeTableUsers(logindata);
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void makeTableUsers(IQueryable accounts)
        {  
            usersDataGridView.DataSource = accounts;
            DGV_SetStyle(usersDataGridView);
          


        }
        public void DGV_SetStyle(DataGridView Dgv)
        {
            foreach (DataGridViewRow Row in Dgv.Rows)
            {
                if (Row.Index % 2 == 0)
                {
                    Row.DefaultCellStyle.BackColor = Properties.Settings.Default.dgvColor;
                }
            }
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

        private void button4_Click(object sender, EventArgs e)
        {
            CityTable newCity = new CityTable();
            newCity.CityName = CityTextBox.Text;
            newCity.Id = Convert.ToInt64(IDTextBox.Text);
            SqlManipulator sql = new SqlManipulator();
            if (sql.addCity(newCity))
            {
                makeTable(sql.getDataCity());
                MessageBox.Show("با موفقیت شهر مورد نظر اضافه گردید");

            }
            else
            {
                MessageBox.Show("خطا");
            }
        }
        private void makeTable(IQueryable cities)
        {
            cityDataGridView.DataSource = cities;
            DGV_SetStyle(this.cityDataGridView);
        }
        private void makeValidationTable(IQueryable validationData)
        {
            validationDataGridView.DataSource = validationData;
            DGV_SetStyle(this.validationDataGridView);
            changeValidationTableColumnNames();
        }

        private void button3_Click(object sender, EventArgs e)
        {
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

        private void dgvColor_Click(object sender, EventArgs e)
        {
            DialogResult dlg = colorDialog1.ShowDialog();
            if (dlg == DialogResult.OK)
            {
                Properties.Settings.Default.dgvColor = colorDialog1.Color;
                this.mainForm.refreshDGV();
            }
           
        }

        private void addRestrictionButton_Click(object sender, EventArgs e)
        {
            try { 
            validationTable valid = new validationTable();
            valid.description = (string)this.descriptionTextBox.Text;

            DateTime startTime = startDateTimePickerX.SelectedDateInDateTime;
            DateTime endTime = endDateTimePickerX1.SelectedDateInDateTime;

            StartEndMonthClass date = new StartEndMonthClass();
            date.startDate = Convert.ToInt64(startTime.ToFa("yyyyMMdd"));
            date.endDate = Convert.ToInt64(endTime.ToFa("yyyyMMdd"));

            valid.startDate = date.startDate;
            valid.enDate = date.endDate;
            valid.City = Convert.ToInt64(validCityComboBox.SelectedValue);
            SqlManipulator sql = new SqlManipulator();
            Report rpt = new Report(sql.addValidation(valid));
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

            try {
                selectedRow = validationDataGridView.CurrentCell.RowIndex;
                SqlManipulator sql = new SqlManipulator();
                DataGridViewRow newDataRow = validationDataGridView.Rows[selectedRow];
                validationTable deletedRestriction = new validationTable();


                deletedRestriction.City = (long)newDataRow.Cells[0].Value;
                deletedRestriction.startDate = (long)newDataRow.Cells[1].Value;
                deletedRestriction.enDate = (long)newDataRow.Cells[2].Value;
                deletedRestriction.id = (long)newDataRow.Cells[3].Value;
                deletedRestriction.description = (String)newDataRow.Cells[4].Value;
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
}
