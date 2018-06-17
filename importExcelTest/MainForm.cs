﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using PersianDate;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Windows.Forms;
using System.IO;
using WindowsFormsApplication1;
using System.Globalization;
using System.Drawing.Text;
using System.Threading;
using System.Xml.Linq;
/// <summary>
/// Written By AmirHosein Lessani 2018 
/// 21 May 2018
/// </summary>
namespace negar
{
    public partial class MainForm : Form
    {   
        private List<long> selectedID;
        private int selectedRowupdate;
        private int pageNumber;
        private int lastSelectedRow;
        private  Result lastResult;
        private NoteBook ntp;
        private LoginInfo login;
        private DaftarTable rowsData;

        private List<DaftarTable> datasForModify;
        private AdvancedSearchForm adv;
        bool godmode;
        private StartEndMonthClass startEnd;
        public MainForm()
        {
            pageNumber = 0;
            lastSelectedRow = 0;
            selectedRowupdate = 0;
            InitializeComponent();
            monthComboBox.Enabled = false;
            yearComboBox.Enabled = false;
            godmode = false;
            comboBox1.SelectedIndex = 1;
            selectedID = new List<long>();
            datasForModify = new List<DaftarTable>();

            ExtensionMethods.DoubleBuffered(mainDataGridView, true);
            adv = new AdvancedSearchForm(this);
            ntp = new NoteBook();
            startEnd = new StartEndMonthClass();
            lastResult = new Result();

        }
        public void setLoginData(LoginInfo login)
        {
            this.login = login;
            userToolStripStatusLabel.Text = " کاربر :"+ login.Name + "" + login.family;
            this.statusStrip1.Invalidate();
            this.statusStrip1.Refresh();
            

         }
         int pageSize = Properties.Settings.Default.pageSize;
       public void setPageSize(int pageSize)
        {
            this.pageSize = pageSize;
            forwardButton.Enabled = true;
            backwardButton.Enabled = false;
            pageNumber = 0;

            try
            {
                if (login.permission)
                {
                    var item = (ComboboxItem)cityComboBox.SelectedItem;
                    login.cityID = item.Value;
                }

                    ///too halat e search e
                SqlManipulator sql = new SqlManipulator();
                var query = searchResultQuery();
                refreshDVGquery(query,pageNumber);
                


            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }
        private void saveLastState(LasteStateClass state)
        {
            SqlManipulator sql = new SqlManipulator();
            var query = searchResultQuery();

            this.lastResult = query;
            this.pageNumberlabel.Text = "0";

            string sum = string.Format("{0:n0}", sql.sumPrice(query));
            this.sumStripStatusLabel1.Text = "مجموع واریزی "+sum +" "+ "ریال ";
            paginationQuery(query,pageNumber);
        }
        public void setCityComboBox()
        {
            try { 
            cityComboBox.Items.Clear();
            if (!login.permission)
            { SqlManipulator sql = new SqlManipulator();
                cityComboBox.Items.Add(new ComboboxItem(login.cityName, login.cityID));
                cityComboBox.SelectedIndex = 0;
                cityComboBox.Enabled = false;

            }
            else {
                try {
                    cityComboBox.Items.Add(new ComboboxItem("همه", 0));
                    SqlManipulator sql = new SqlManipulator();
                    var cities = sql.queryCities();
                    foreach (var city in cities)
                    {
                        cityComboBox.Items.Add(new ComboboxItem(city.CityName, city.Id));
                    }
                    cityComboBox.Enabled = true;
                    cityComboBox.SelectedIndex = 0;
                  
                }catch(Exception)
                {
                    throw;
                }
            }
            }
            catch(Exception)
            {

            }
        }
        private void setDataGrid()
        {   
            mainDataGridView.VirtualMode = true;
            try
            {
                mainDataGridView.SuspendLayout();
                foreach (DataGridViewColumn c in mainDataGridView.Columns)
                {
                    c.AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
                }
                mainDataGridView.ResumeLayout();
                mainDataGridView.ClearSelection();
                setRowNumber(mainDataGridView);

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Data.ToString());
            }
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
        private void setUserInformation(LoginInfo login)
        {
            userToolStripStatusLabel.Text = "کاربر :" + login.Name + " "+ login.family+" " + "شهرستان:" + login.cityName;
            statusStrip1.Invalidate();
            statusStrip1.Refresh();

        }
        private void MainForm_Load(object sender, EventArgs e)
        {
            setDataGrid();
            setCityComboBox();

            backwardButton.Enabled = false;
            setUserInformation(login);
            setPermission();
            this.backwardButton.Enabled = false;
            this.forwardButton.Enabled = false;
            
            setinLoad();
           
        }
        private void setinLoad()
        {
            try {
                if (login.permission)
                {
                    this.cityComboBox.SelectedIndex = 1;

                    if (yearComboBox.Items.Count == 0)
                    {
                        return;
                    }
                    if (yearComboBox.Items.Count > 0)
                    {
                        this.yearComboBox.SelectedIndex = this.yearComboBox.Items.Count - 1;
                        if (monthComboBox.Enabled)
                        {
                            this.monthComboBox.SelectedIndex = 0;
                        }
                    }
                    
                }
                else
                {
                    this.cityComboBox.SelectedIndex = 0;

                    if(yearComboBox.Items.Count ==0)
                    {
                        return;
                    }
                    
                    
                    if (yearComboBox.Items.Count > 0)
                    {
                        this.yearComboBox.SelectedIndex = this.yearComboBox.Items.Count - 1;
                        if (monthComboBox.Enabled)
                        {
                            this.monthComboBox.SelectedIndex = 0;
                        }
                    }
                    
                }
                searchinMonth();
            }
            catch (Exception) { throw; }
        }
        public void setPermission()
        {   
            ///this is alpha test 
            ///To Do
           /// this.echoButton.Visible = false;
            ///Echo is under Proccessing
            if (login.permission)
            {
                مدیریتToolStripMenuItem1.Visible = true;
                شنیدنToolStripMenuItem.Visible = true;
            }
            else {
                مدیریتToolStripMenuItem1.Visible = false;
                شنیدنToolStripMenuItem.Visible = false;
            }
        }
         Result  searchResultQuery()
        {
            int value = this.comboBox1.SelectedIndex;

            SqlManipulator sql = new SqlManipulator();
         
            if (login.permission)
            {
                var item = (ComboboxItem)cityComboBox.SelectedItem;
                login.cityID = item.Value;
            }
            StartEndMonthClass se = new StartEndMonthClass();
           if(searchAllCheckBox.Checked)
            {
                MaxMinClass allTime = new MaxMinClass();
                allTime = sql.findMaxminMonthDay(login.cityID);
                se.startDate = allTime.min;
                se.endDate = allTime.max;
                startEnd.startDate = allTime.min;
                startEnd.endDate = allTime.max;

            }
           else
            {  
                se.startDate = startEnd.startDate;
                se.endDate = startEnd.endDate;
            }
            Result query = new Result();
            switch (value)
            {
                case 0:
                    query = sql.budgetCodeQuery(login.cityID ,(this.searchTextBox.Text),startEnd,pageSize);
                    break;
                case 1:
                    query = sql.ownerQuery(login.cityID,this.searchTextBox.Text,startEnd,pageSize);
                    break;
                case 2:
                    query = sql.AccountTypeQuery(login.cityID, this.searchTextBox.Text, startEnd, pageSize);
                    break;
                case 3:
                    query =  sql.billDetailCodeQuery(login.cityID, this.searchTextBox.Text, startEnd, pageSize);
                    break;
                case 4:
                    query =  sql.depositDetailCodeQuery(login.cityID, this.searchTextBox.Text, startEnd, pageSize);
                    break;
                case 5:
                    query =  sql.depositQuery(login.cityID, this.searchTextBox.Text, startEnd, pageSize);
                    break;
                case 6:
                    query =  sql.refundQuery(login.cityID, this.searchTextBox.Text, startEnd, pageSize);
                    break;

            }
            return query;
        }
        private void makeTable(IQueryable<DaftarTable> data)
        { 
            try
            {
              
                mainDataGridView.DataSource = data.ToList();
                mainDataGridView.ClearSelection();
                setRowNumber(mainDataGridView);
                changeColumnName();
                DGV_SetStyle(mainDataGridView);
                if (lastSelectedRow > 0)
                {
                   // mainDataGridView.Rows[lastSelectedRow].Selected = true;
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }
        private void esterdadButton_Click(object sender, EventArgs e)
        {
            refund();
        }
        private void refund()
        {
            string msg = "در صورت استرداد وجه قابلیت ویرایش و حذف نخواهید داشت "; 
            DialogResult dialogResult = MessageBox.Show("آیا از استرداد وجه مطمئن هستید؟ "+msg, "هشدار", MessageBoxButtons.YesNo,MessageBoxIcon.Warning);
            if (dialogResult == DialogResult.Yes)
            {
                SqlManipulator sql = new SqlManipulator();
                if (!datasForModify.Any())
                {
                    MessageBox.Show("لطفا سطری را جهت استرداد انتخاب نمائید");
                }
                else
                {
                    var refundItems = sql.refund(datasForModify,godmode);
                    Report rpt = new Report(refundItems, (int)errorImages.info);
                    rpt.Show();
                    refreshState();
                }
            }
            else
            {
                return;
            }
        }
        public  void refreshLastState()
        {
            SqlManipulator sql = new SqlManipulator();
            var t = sql.pageResult(lastResult, pageNumber, pageSize);
            makeTable(t.query);
            if (login.permission)
            {
                var item = (ComboboxItem)cityComboBox.SelectedItem;
                login.cityID = item.Value;
            }
            setYearMonthComboBox(login.cityID);
            yearComboBox.SelectedIndex = 0;
            monthComboBox.Enabled = true;

        }
        void refreshDVGquery(Result result ,  int pageNumber)
        {
            if (login.permission)
            {
                var item = (ComboboxItem)cityComboBox.SelectedItem;
                login.cityID = item.Value;
            }
                SqlManipulator sql = new SqlManipulator();
               this.lastResult = result;
                var t = sql.pageResult(result, 0, pageSize);
                makeTable(t.query);
        }
        private void setPageCountText(Result result)
        {
            string spc = " ";

            string p = " صفحه "+  result.queryPageNumber.ToString() ;
            this.counttoolStripStatusLabel1.Text = " رکورد "+ spc +result.recordCount.ToString() +"    "+ spc + p;
            if (result.queryPageNumber < 1) { this.forwardButton.Enabled = false; this.backwardButton.Enabled = false; }
            else { forwardButton.Enabled = true; }
            this.statusStrip1.Invalidate();
            this.statusStrip1.Refresh();

        }
        void paginationQuery(Result result, int pageNumber)
        {
            setPageCountText(result);
            SqlManipulator sql = new SqlManipulator();
            var t = sql.pageResult(result, pageNumber, pageSize);
            //pageNumber = t.queryPageNumber;
            makeTable(t.query);

        }

        private void mainDataGridView_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            changeSelected();
            rightclick(sender,e);
        }
        private void rightclick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.Button == System.Windows.Forms.MouseButtons.Right)
            {
                contextMenuStrip1.Show(Cursor.Position.X, Cursor.Position.Y);
            }
        }
        private void changeSelected()
        {
            try
            {
                
                selectedRowupdate = mainDataGridView.CurrentCell.RowIndex;
                DataGridViewRow newDataRow = mainDataGridView.Rows[selectedRowupdate];

                rowsData = new DaftarTable();
                rowsData.Id = Convert.ToInt64(newDataRow.Cells[0].Value);
                rowsData.Refund = Convert.ToInt64(newDataRow.Cells[1].Value);
                rowsData.BillDetailCode = Convert.ToInt64(newDataRow.Cells[2].Value);
                rowsData.Date = newDataRow.Cells[3].Value.ToString();
                rowsData.AccountType = newDataRow.Cells[5].Value.ToString();
                rowsData.DepositOwnerDetail = newDataRow.Cells[6].Value.ToString();
                rowsData.DepositDetail = Convert.ToInt64(newDataRow.Cells[7].Value);
                rowsData.Deposit = Convert.ToInt64(newDataRow.Cells[8].Value);
                rowsData.CodeBudget  = Convert.ToInt64(newDataRow.Cells[9].Value);
                rowsData.CityID = Convert.ToInt64(newDataRow.Cells[10].Value);
                rowsData.RealDate = Convert.ToInt64(newDataRow.Cells[11].Value);

                           
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Data.ToString());
            }
        }
        private void mainDataGridView_SelectionChanged(object sender, EventArgs e)
        {
            datasForModify.Clear();

            foreach (DataGridViewRow row in mainDataGridView.SelectedRows)
            {
                try {
                    DaftarTable data = new DaftarTable();

                    data.Id = Convert.ToInt64(row.Cells[0].Value);
                    data.Refund = Convert.ToInt64(row.Cells[1].Value);
                    data.BillDetailCode = Convert.ToInt64(row.Cells[2].Value);
                    data.Date = row.Cells[3].Value.ToString();
                    data.PlaceName = row.Cells[4].Value.ToString();
                    data.AccountType = row.Cells[5].Value.ToString();
                    data.DepositOwnerDetail = row.Cells[6].Value.ToString();
                    data.DepositDetail = Convert.ToInt64(row.Cells[7].Value);
                    data.Deposit = Convert.ToInt64(row.Cells[8].Value);
                    data.CodeBudget = Convert.ToInt64(row.Cells[9].Value);
                    data.CityID = Convert.ToInt64(row.Cells[10].Value);
                    data.RealDate = Convert.ToInt64(row.Cells[11].Value);

                    datasForModify.Add(data);
                }
                catch(Exception ex)
                {
                    MessageBox.Show(ex.ToString());
                }

                // var id =  row.Cells[0].Value.ToString();
                //selectedID.Add(Convert.ToInt64(id));
            }
        }
        private void setRowNumber(DataGridView dgv)
        {
            try {
                foreach (DataGridViewRow r in dgv.Rows)
                {
                    dgv.Rows[r.Index].HeaderCell.Value = (r.Index + 1).ToString();
                    dgv.RowHeadersWidth = 50;
                }
            }
            catch(Exception)
            {

            }
        }
      
       
        private void changeColumnName()
        {
            Utility utl = new Utility();
            var header = utl.getColumnsHeader();
            int i = 0;
            foreach (var a in header)
            {
                mainDataGridView.Columns[i].HeaderText = a.ToString() ;
                i++;
            }
        }
        private void deleteButton_Click(object sender, EventArgs e)
        {
            delete();
        }
        private void delete()
        {
            DialogResult dialogResult = MessageBox.Show("آیا از حذف مطمئن هستید؟", "هشدار", MessageBoxButtons.YesNo,MessageBoxIcon.Warning);
            if (dialogResult == DialogResult.Yes)
            {
                SqlManipulator sql = new SqlManipulator();
                if(!datasForModify.Any())
                {
                    MessageBox.Show("لطفا سطری را برای حذف انتخاب کنید");
                }
                var rpt = sql.remove(datasForModify,godmode,login.permission);

                Report r = new Report(rpt, (int)errorImages.info);
                r.Show();

                datasForModify.Clear();

                LasteStateClass lst = new LasteStateClass();
                lst.cityID = login.cityID;
                lst.date = startEnd;
                lst.searchValue = this.searchTextBox.Text;
                refreshLastState();

            }
            else if (dialogResult == DialogResult.No)
            {
                return;
            }
        }

        private void cityComboBox_SelectionChangeCommitted(object sender, EventArgs e)
        {
            searchTextBox.Clear();
            if (login.permission)
            {
                var item = (ComboboxItem)cityComboBox.SelectedItem;
                login.cityID = item.Value;
            }
            setYearMonthComboBox(login.cityID);
        }
        private void updateButton_Click(object sender, EventArgs e)
        {
            EditForm edit = new EditForm(rowsData,this,login,godmode);
            edit.Show();
        }
        public void refreshState()
        {
            LasteStateClass lst = new LasteStateClass();

            if (login.permission)
            {
                var item = (ComboboxItem)cityComboBox.SelectedItem;
                login.cityID = item.Value;
            }
            lst.cityID = login.cityID;
            lst.date = startEnd;
            lst.searchValue = this.searchTextBox.Text;
            saveLastState(lst);
        }
        private void comboBox1_SelectionChangeCommitted(object sender, EventArgs e)
        {
            searchTextBox.Clear();
        }
        
        private void اضافهکردنفایلToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ImportExcel excelForm = new ImportExcel(this,this.login);
            excelForm.Show();
        }

        private void خروجToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }        

        private void addButton_Click(object sender, EventArgs e)
        {
            AddEditForm add = new AddEditForm(login,this,false, rowsData);
            add.Show();
        }

        private void updateButton3_Click(object sender, EventArgs e)
        {
            try {
                refreshLastState();
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }
        public void refreshDGV()
        {
            try
            {
                if (login.permission)
                {
                    var item = (ComboboxItem)cityComboBox.SelectedItem;
                    login.cityID = item.Value;
                }
                if (this.searchTextBox.Text.Length > 0)
                {
                    SqlManipulator sql = new SqlManipulator();
                    var query = searchResultQuery();
                    refreshDVGquery(query,pageNumber);
                
                }
                else
                {
                    SqlManipulator sql = new SqlManipulator();
                    var query = sql.searchByDate(login.cityID,pageSize,startEnd.startDate,startEnd.endDate) ;
                    var t = sql.pageResult(query, pageNumber, pageSize);
                    makeTable(t.query);
                }
                yearComboBox.Items.Clear();
                setYearMonthComboBox(login.cityID);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }


        private void mainDataGridView_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            try {
                if ((e.ColumnIndex == 1)
             && e.Value != null)
                {
                    DataGridViewCell cell =
                        this.mainDataGridView.Rows[e.RowIndex].Cells[e.ColumnIndex];

                    cell.ToolTipText = HumanReadableInteger.NumberToText(Convert.ToInt64(e.Value), Language.Persian) + " ریال";
                }
                if ((e.ColumnIndex == 8)
           && e.Value != null)
                {
                    DataGridViewCell cell =
                        this.mainDataGridView.Rows[e.RowIndex].Cells[e.ColumnIndex];

                    cell.ToolTipText = HumanReadableInteger.NumberToText(Convert.ToInt64(e.Value), Language.Persian) + " ریال";
                }
            }
            catch(Exception exp)
            { MessageBox.Show(exp.Message); }
        }

        

        private void cityComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            try {
                if (login.permission)
                {
                    var item = (ComboboxItem)cityComboBox.SelectedItem;
                    login.cityID = item.Value;
                }
                setYearMonthComboBox(login.cityID);
                
                try
                {
                    mainDataGridView.ClearSelection();
                    if(searchAllCheckBox.Checked)
                    { yearComboBox.Enabled = false; }
                    else { yearComboBox.Enabled = true; }
                    monthComboBox.Enabled = false;
                    
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }
        private void تنظیماتToolStripMenuItem_Click(object sender, EventArgs e)
        {
            UserSettingsForm stngs = new UserSettingsForm(this);
            stngs.Show();
        }

        private void مدیریتToolStripMenuItem_Click(object sender, EventArgs e)
        {

            ManagerForm mng = new ManagerForm(this);
            mng.Show();
        }


        int page;
        
        private void forwardButton_Click(object sender, EventArgs e)
        {
            pageNumber++;
            var s = this.lastResult.queryPageNumber.ToString();
            page = this.lastResult.queryPageNumber ;
            backwardButton.Enabled = true;
            if (pageNumber > page )
            {
                forwardButton.Enabled = false;
                return;
            }
            pageNumberlabel.Text = pageNumber.ToString();


                var p = this.lastResult;
                if (lastResult.queryPageNumber == 0)
                {
                    forwardButton.Enabled = false;
                    return;
                }
                paginationQuery(p,pageNumber);
                backwardButton.Enabled = true;

            if (pageNumber >= page)
            {
                forwardButton.Enabled = false;
            }
            
        }

        private void backardButton_Click(object sender, EventArgs e)
        {

            forwardButton.Enabled = true;
            pageNumber--;

            pageNumberlabel.Text = pageNumber.ToString();
            forwardButton.Enabled = true;

            paginationQuery(this.lastResult, pageNumber);
            if (pageNumber == 0)
            {
                backwardButton.Enabled = false;
                return;
            }
        }

        private void search_Button(object sender, EventArgs e)
        {
            search();
    
        }
        private void search()
        {
            pageNumber = 0;
            backwardButton.Enabled = false;


            if (login.permission)
            {
                var item = (ComboboxItem)cityComboBox.SelectedItem;
                login.cityID = item.Value;
            }
            var query = searchResultQuery();
            if (!query.query.Any())
            {
                MessageBox.Show("نتیجه ایی یافت نشد","هشدار ",MessageBoxButtons.OK,MessageBoxIcon.Information);
                return;
            }
            try
            {
                lastResult = query;

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }

            LasteStateClass lst = new LasteStateClass();
            lst.cityID = login.cityID;
            lst.date = startEnd;
            lst.searchValue = this.searchTextBox.Text;
            saveLastState(lst);
            forwardButton.Enabled = true;
        }
        public void advanceSearch(StartEndMonthClass date)
        {
            if (login.permission)
            {
                var item = (ComboboxItem)cityComboBox.SelectedItem;
                login.cityID = item.Value;
            } 

            startEnd = date;
            monthComboBox.Enabled = false;
            yearComboBox.Enabled = false;
            LasteStateClass state = new LasteStateClass();
            state.cityID = login.cityID;
            state.searchValue = this.searchTextBox.Text;
            state.date = startEnd;
            saveLastState(state);
        }
        private void advanceSearchButton_Click_1(object sender, EventArgs e)
        {
            adv.Show(); 
        }

        private void setYearMonthComboBox(long cityID)
        {

            yearComboBox.Items.Clear();
            monthComboBox.Items.Clear();
            SqlManipulator sql = new SqlManipulator();
            var minmax = sql.findMaxminMonthDay(cityID);
            Utility utl = new Utility();
            if (minmax != null)
            {
                try
                {
                    long endDate = Convert.ToInt64(utl.formatStringDate(minmax.max.ToString()).ToEn().ToFa("yyyy"));
                    long startDate = Convert.ToInt64(utl.formatStringDate(minmax.min.ToString()).ToEn().ToFa("yyyy"));
                    for (long year = startDate; year <= endDate; year++)
                    {
                        yearComboBox.Items.Add(year);
                    }
                    for (int month = 1; month <= 12; month++)
                    {
                        monthComboBox.Items.Add(new ComboboxItem(utl.getMonthName(month), month));
                    }

                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.ToString());
                }
            }
        }
        private void searchinMonth()
        {
            if (login.permission)
            {
                var item = (ComboboxItem)cityComboBox.SelectedItem;
                login.cityID = item.Value;
            }
            try {
                SqlManipulator sql = new SqlManipulator();
                Utility utl = new Utility();
                var mItem = (ComboboxItem)monthComboBox.SelectedItem;
                long month = mItem.Value;
                int year = Convert.ToInt32(yearComboBox.SelectedItem);

                Result result = new Result();
                try {
                    var starEndofMonth = utl.getStartEndofMonth(year, month);
                    result = sql.searchByDate(login.cityID, pageSize, starEndofMonth.startDate, starEndofMonth.endDate);
                    startEnd = starEndofMonth;
                }
                catch (Exception)
                {
                    MessageBox.Show("خطا در تاریخ");
                }
                pageNumber = 0;
                page = 0;
                backwardButton.Enabled = false;
                forwardButton.Enabled = true;
                LasteStateClass laste = new LasteStateClass();
                laste.cityID = login.cityID;
                laste.date = startEnd;
                laste.searchValue = this.searchTextBox.Text;
                saveLastState(laste);
            }
            catch (Exception) { throw; }
        }
       
        private void monthComboBox_SelectionChangeCommitted(object sender, EventArgs e)
        {
            searchinMonth();
        }

        private void بهعنواناکسلToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try {

                SqlManipulator sql = new SqlManipulator();
                Result q = new Result();
                q = this.lastResult;
                if (q.query == null)
                {
                    MessageBox.Show("تاریخ یا شهر را انتخاب کنید");

                }
                if (q.query.ToList().Any())
                {
                    Stream mystream;
                    SaveFileDialog saveExcelDialog = new SaveFileDialog();
                    saveExcelDialog.Filter = "Excel files (*.xlsx)|*.xlsx";
                    saveExcelDialog.FilterIndex = 2;
                    saveExcelDialog.RestoreDirectory = true;
                    if(saveExcelDialog.ShowDialog() == DialogResult.OK)
                    {
                        if ((mystream = saveExcelDialog.OpenFile()) != null)
                        {
                            StartProgress();
                            Utility utl = new Utility();
                            var header = utl.getColumnsHeader();
                            ExcelGeneratorClass createReport = new ExcelGeneratorClass(q.query, saveExcelDialog.FileName,header);
                            mystream.Close();
                            CloseProgress();
                            MessageBox.Show("فایل اکسل با موفقیت ساخته شد");

                        }
                    }
                }
                else
                {
                    MessageBox.Show("تاریخ یا شهر را انتخاب کنید");
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void چاپToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            ClsPrint _ClsPrint = new ClsPrint(mainDataGridView, "جدول خروجی");
            _ClsPrint.PrintForm();
        }
      

        private void فایلمتنیToolStripMenuItem_Click(object sender, EventArgs e)
        {

            try
            {

                SqlManipulator sql = new SqlManipulator();
                Result q = new Result();
                q = this.lastResult;

                if (q.query == null)
                {
                    MessageBox.Show("تاریخ یا شهر را انتخاب کنید");
                    
                }
                if (q.query.ToList().Any())
                {
                    SaveFileDialog saveTextDialog = new SaveFileDialog();
                    saveTextDialog.Filter = "Text files (*.txt)|*.txt";
                    saveTextDialog.FilterIndex = 2;
                    saveTextDialog.RestoreDirectory = true;
                    if (saveTextDialog.ShowDialog() == DialogResult.OK)
                    {
                            textReportClass txt = new textReportClass(q.query, saveTextDialog.FileName);
                    }
                }
                else
                {
                    MessageBox.Show("تاریخ یا شهر را انتخاب کنید");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }


        private void aboutUsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            infoForm inf = new infoForm();
            inf.Show();
        }

        private void yearComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            monthComboBox.Enabled = true;
        }



        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            // Determine if text has changed in the textbox by comparing to original text.
            // Display a MsgBox asking the user to save changes or abort.
            // Determine if text has changed in the textbox by comparing to original text.
            // e.Cancel = false;
            Environment.Exit(Environment.ExitCode);


            if (System.Windows.Forms.Application.MessageLoop)
            {
                // WinForms app
                System.Windows.Forms.Application.Exit();
            }
            else
            {
                // Console app
                System.Environment.Exit(1);
            }

            Application.Exit();

        }

        private void searchAllCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            if(searchAllCheckBox.Checked)
            {
                yearComboBox.Enabled = false;
                monthComboBox.Enabled = false;
            }
            else
            {
                yearComboBox.Enabled = true;
                monthComboBox.Enabled = true;
            }
        }
      
       
        #region
        LoadingForm loadform = new LoadingForm();
        private void StartProgress()
        {
            loadform = new LoadingForm();
            ShowProgress();
        }
        private void CloseProgress()
        {
            // Thread.Sleep(200);
            loadform.Invoke(new Action(loadform.Close));
        }
        private void ShowProgress()
        {
            try
            {
                if (this.InvokeRequired)
                {
                    try
                    {
                        loadform.ShowDialog();
                    }
                    catch (Exception ) { }
                }
                else
                {
                    Thread th = new Thread(ShowProgress);
                    th.IsBackground = false;
                    th.Start();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        #endregion

        private void اضافهToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AddEditForm add = new AddEditForm(login, this, false, rowsData);
            add.Show();

        }

        private void تغییرToolStripMenuItem_Click(object sender, EventArgs e)
        {
            EditForm edit = new EditForm(rowsData, this, login,godmode);
            edit.Show();
        }

        private void mainDataGridView_CellMouseLeave(object sender, DataGridViewCellEventArgs e)
        {
           
        }

        private void mainDataGridView_CellMouseDown(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                try
                {
                    mainDataGridView.CurrentCell = mainDataGridView.Rows[e.RowIndex].Cells[e.ColumnIndex];
                    // Can leave these here - doesn't hurt
                    mainDataGridView.Rows[e.RowIndex].Selected = true;
                    mainDataGridView.Focus();

                   // selectedBiodataId = Convert.ToInt32(dgrdResults.Rows[e.RowIndex].Cells[1].Value);
                }
                catch (Exception)
                {

                }
            }

        }

      
        private void removeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            delete();
        }

        private void addToolStripMenuItem_Click(object sender, EventArgs e)
        {
            EditForm edit = new EditForm(rowsData, this, login,godmode);
            edit.Show();
        }

        private void استردادToolStripMenuItem_Click(object sender, EventArgs e)
        {
            refund();
        }

        private void بروزرسانیToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                refreshLastState();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void اضافهToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            AddEditForm add = new AddEditForm(login, this, true, rowsData);
            add.Show();
        }

        private void mainDataGridView_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Delete)
            {
                delete();
                // do something with selectedCell...
            }
            if(e.KeyCode == Keys.F2)
            {
                EditForm edit = new EditForm(rowsData, this, login,godmode);
                edit.Show();
            }
            if(e.KeyCode == Keys.F1)
            {
                AddEditForm add = new AddEditForm(login, this, true, rowsData);
                add.Show();
            }
        }

        private void checkToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FileCheckerForm file = new FileCheckerForm();
            file.Show();
        }

        private void بررسیفایلاکسلToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FileCheckerForm file = new FileCheckerForm();
            file.Show();
        }

        private void مدیریتToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            ManagerForm mng = new ManagerForm(this);
            mng.Show();
        }

        private void searchTextBox_KeyUp(object sender, KeyEventArgs e)
        {
            if ((e.KeyCode == Keys.Enter) || (e.KeyCode == Keys.Return))
            {
                search();
            }
        }
       
       
        private void notificate()
        {
            SqlManipulator sql = new SqlManipulator();
            sql.notify(login.Id);

        }

        private void شنیدنToolStripMenuItem_Click(object sender, EventArgs e)
        {
            notificate();
        }

        private void اضافهبهدفترToolStripMenuItem_Click(object sender, EventArgs e)
        {
            XMLHandler xml = new XMLHandler();
            if (!datasForModify.Any())
            {
                MessageBox.Show("لطفا سطری را برای اضافه کردن به دفتر انتخاب کنید");
                return;
            }
            else
            {
                if(xml.addToNoteBook(datasForModify))
                {
                    try {
                        ntp.setDataGridView();
                    }
                    catch(Exception ex)
                    {
                        MessageBox.Show(ex.ToString());
                    }
                }
            }
            //var rpt = sql.remove(datasForModify, godmode, login.permission);

        }

               private void دفترToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ntp.Show();
        }

       
    }


}
