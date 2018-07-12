using System;
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
        int defaultAscending;
        private DaftarTable rowsData;
        Boolean advancedSearch;

        enum ascendingType
        {
             cityAscending = 0,
             dateAscending = 1,
             depositNameAscending = 2,
             refundAscending = 3,
             depositAscending =4,
             
        }
        //private ascendingType  defaultAscending ;
        private List<DaftarTable> datasForModify;
        private AdvancedSearchForm adv;
        bool godmode;
        private StartEndMonthClass startEnd;
        public MainForm()
        {

            MessageBoxManager.Yes = "بله";
            MessageBoxManager.No = "خیر";
            MessageBoxManager.Cancel = "لغو";
            MessageBoxManager.OK = "باشه";
            MessageBoxManager.Register();

           
            pageNumber = 0;
  
            lastSelectedRow = 0;
            selectedRowupdate = 0;
            InitializeComponent();
            monthComboBox.Enabled = false;
            orderComboBox.Enabled = false;
            yearComboBox.Enabled = false;
            advancedSearch = false;
            godmode = false;
            comboBox1.SelectedIndex = 1;
            this.orderComboBox.SelectedIndex = 0;
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
                var query = searchResultQuery(defaultAscending);
                refreshDVGquery(query,pageNumber);
                


            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }
        private void saveLastState(LasteStateClass state)
        {
                    refreshLastState(state,pageNumber);
        }
        public void setCityComboBox()
        {
            try { 
            cityComboBox.Items.Clear();
            if (!login.permission)
            {
                    try {
                        this.نامشهرToolStripMenuItem.Visible = false;
                        SqlManipulator sql = new SqlManipulator();
                        cityComboBox.Items.Add(new ComboboxItem(login.cityName, login.cityID));
                        cityComboBox.SelectedIndex = 0;
                        cityComboBox.Enabled = false;
                    }
                    catch(Exception ex)
                    {
                        MessageBox.Show(ex.ToString());
                    }

            }
            else {
                try {
                    cityComboBox.Items.Add(new ComboboxItem("همه شهرها", 0));
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
                if (login.permission)
                {
                    defaultAscending = (int)ascendingType.cityAscending;
                }
                else
                {
                    defaultAscending = (int)ascendingType.dateAscending;
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Data.ToString());
            }
        }
        public void DGV_SetStyle(DataGridView Dgv)
        {
            Dgv.RowsDefaultCellStyle.BackColor = Color.NavajoWhite;
            Dgv.AlternatingRowsDefaultCellStyle.BackColor = Properties.Settings.Default.dgvColor;
            Dgv.DefaultCellStyle.WrapMode = DataGridViewTriState.True;
            Dgv.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            Dgv.AutoResizeColumnHeadersHeight();

            //Dgv.AutoResizeColumns();
            foreach (DataGridViewColumn col in Dgv.Columns)
            {
                col.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            }
            Dgv.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
            Dgv.Refresh();
            Dgv.Invalidate();

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
                    this.cityComboBox.SelectedIndex = 0;

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
                search(defaultAscending);
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
        private Result  searchResultQuery(int orderType)
        {

            int value = this.comboBox1.SelectedIndex;
            var searchMode = (mode)this.orderComboBox.SelectedIndex;
            SqlManipulator sql = new SqlManipulator();
         
            if (login.permission)
            {
                var item = (ComboboxItem)cityComboBox.SelectedItem;
                login.cityID = item.Value;
            }

           if(searchAllCheckBox.Checked)
            {
                MaxMinClass allTime = new MaxMinClass();
                allTime = sql.findMaxminMonthDay(login.cityID);
                startEnd.startDate = allTime.min;
                startEnd.endDate = allTime.max;

            }
           
         
            Result result = new Result();
            switch (value)
            {
                case 0:
                    result = sql.budgetCodeQuery(login.cityID ,(this.searchTextBox.Text),startEnd,pageSize,searchMode);
                    break;
                case 1:
                    result =  sql.ownerQuery(login.cityID,this.searchTextBox.Text,startEnd,pageSize, searchMode);
                    break;
                case 2:
                    result = sql.AccountTypeQuery(login.cityID, this.searchTextBox.Text, startEnd, pageSize, searchMode);
                    break;
                case 3:
                    result =  sql.billDetailCodeQuery(login.cityID, this.searchTextBox.Text, startEnd, pageSize, searchMode);
                    break;
                case 4:
                    result =  sql.depositDetailCodeQuery(login.cityID, this.searchTextBox.Text, startEnd, pageSize, searchMode);
                    break;
                case 5:
                    result =  sql.depositQuery(login.cityID, this.searchTextBox.Text, startEnd, pageSize, searchMode);
                    break;
                case 6:
                    result =  sql.refundQuery(login.cityID, this.searchTextBox.Text, startEnd, pageSize, searchMode);
                    break;

            }
            if (login.permission)
            { result.query = result.query.OrderBy(x => x.PlaceName); }
            else {
                result.query = result.query.OrderByDescending(x => x.RealDate);
            }
            try {
                switch ((ascendingType)orderType)
                { 
                    case ascendingType.depositNameAscending:
                        result.query = result.query.OrderBy(x => x.DepositOwnerDetail);
                        return result;
                    case ascendingType.cityAscending:
                        result.query = result.query.OrderBy(x => x.PlaceName);
                        return result;
                    case ascendingType.dateAscending:
                        result.query = result.query.OrderByDescending(x => x.RealDate);
                        return result;
                    case ascendingType.refundAscending:
                        result.query = result.query.OrderByDescending(x => x.Refund);
                        return result;
                    case ascendingType.depositAscending:
                        result.query = result.query.OrderByDescending(x => x.Deposit);
                        return result;
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }


            return result;
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
                    refreshLastState(getLastState(),pageNumber);
                }
            }
            else
            {
                return;
            }
        }
        public void refreshLastState(LasteStateClass lastState, int pageNumber)
        {

            SqlManipulator sql = new SqlManipulator();
            ///if refresh need to make a new table use this state
            ///if refresh need to just 
            ///bool
            ///
            
            var  query = searchResultQuery((int)ascendingType.dateAscending);

            this.lastResult = query;


          //  this.pageNumberlabel.Text = "0";

            string sum = string.Format("{0:n0}", sql.sumPrice(query));
            this.sumStripStatusLabel1.Text = "مجموع واریزی " + sum + " " + "ریال ";
            paginationQuery(query, pageNumber);


            //var t = sql.pageResult(lastResult, pageNumber, pageSize);
            //makeTable(t.result);
            if (login.permission)
            {
                var item = (ComboboxItem)cityComboBox.SelectedItem;
                login.cityID = item.Value;
            }
            setYearMonthComboBox(login.cityID);
            try
            {
                if (lastState.lastMonthSelected != null || lastState.lastYearSelected != null)
                {
                    yearComboBox.SelectedIndex = lastState.lastYearSelected;
                    monthComboBox.SelectedIndex = lastState.lastMonthSelected;
                    this.orderComboBox.SelectedIndex = lastState.lastModeSelected;
                }
            }
            catch (Exception)
            {
                throw;
            }


        }
        public  void refreshLastState(LasteStateClass lastState,int pageNumber,Result query)
        {

            SqlManipulator sql = new SqlManipulator();
       
            this.lastResult = query;               
            this.pageNumberlabel.Text = "0";

            string sum = string.Format("{0:n0}", sql.sumPrice(query));
            this.sumStripStatusLabel1.Text = " جمع کل " + sum + " " + "ریال ";
            paginationQuery(query, pageNumber);


            //var t = sql.pageResult(lastResult, pageNumber, pageSize);
            //makeTable(t.result);
            if (login.permission)
            {
                var item = (ComboboxItem)cityComboBox.SelectedItem;
                login.cityID = item.Value;
            }
            setYearMonthComboBox(login.cityID);
            try {
                if(lastState.lastMonthSelected !=null || lastState.lastYearSelected !=null)
                {
                    yearComboBox.SelectedIndex = lastState.lastYearSelected;
                    monthComboBox.SelectedIndex = lastState.lastMonthSelected;
                    this.orderComboBox.SelectedIndex = lastState.lastModeSelected;
                }
                            }
            catch(Exception)
            {
                throw;
            }
            

        }
        void refreshDVGquery(Result result ,  int pageNumber)
        {
            try {
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
            catch(Exception)
            {
                throw;
            }
        }
        private void setPageCountText(Result result,int pageNumber)
        {
            string spc = " ";
    
            string p = " صفحه "+  result.queryPageNumber.ToString() ;
            this.counttoolStripStatusLabel1.Text = " رکورد "+ spc +result.recordCount.ToString() +"    "+ spc + p;
            if (result.queryPageNumber < 1) { this.forwardButton.Enabled = false; this.backwardButton.Enabled = false; }

            else if ((pageNumber >= result.queryPageNumber)) { forwardButton.Enabled = false; }
            else { forwardButton.Enabled = true; }
            this.statusStrip1.Invalidate();
            this.statusStrip1.Refresh();

        }
        void paginationQuery(Result result, int pageNumber)
        {
            setPageCountText(result,pageNumber);
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
                throw;
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

                refreshLastState(getLastState(),pageNumber);

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
            EditForm edit = new EditForm(rowsData,this,login,godmode,pageNumber,getLastState());
            edit.Show();
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
        LasteStateClass getLastState()
        {
            LasteStateClass lst = new LasteStateClass();
            lst.cityID = login.cityID;
            if(!this.searchAllCheckBox.Checked || this.advancedSearch)
            { lst.date = startEnd; }
           
            
            lst.searchValue = this.searchTextBox.Text;
            lst.lastModeSelected = this.orderComboBox.SelectedIndex;
            lst.lastYearSelected = this.yearComboBox.SelectedIndex;
            lst.lastMonthSelected = this.monthComboBox.SelectedIndex;
            return lst;
        }
        private void addButton_Click(object sender, EventArgs e)
        {
            AddEditForm add = new AddEditForm(login,this,false, rowsData,pageNumber,getLastState());
            add.Show();
        }

        private void updateButton3_Click(object sender, EventArgs e)
        {
            try {
                search(defaultAscending);

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
                    var query = searchResultQuery((int)ascendingType.dateAscending);
                    refreshDVGquery(query,pageNumber);
                
                }
                else
                {
                    search(defaultAscending);
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

            ManagerForm mng = new ManagerForm(this,login);
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
        private void resetNavigationButtons()
        {
            pageNumber = 0;
            page = 0;
            backwardButton.Enabled = false;
            forwardButton.Enabled = true;
            this.pageNumberlabel.Text = "0";


        }

        private void search_Button(object sender, EventArgs e)
        {
            search(defaultAscending);
    
        }
        private void search(int orderBy)
        {
            if (this.searchAllCheckBox.Checked)
            {
                if (login.permission)
                {
                    var item = (ComboboxItem)cityComboBox.SelectedItem;
                    login.cityID = item.Value;
                    this.monthComboBox.Enabled = false;
                    this.yearComboBox.Enabled = false;
                }
                var searchResult = searchResultQuery((int)orderBy);
                resetNavigationButtons();
                refreshLastState(getLastState(), pageNumber, searchResult);
                if (!searchResult.query.Any())
                {
                    this.mainDataGridView.DataSource = null;
                    this.forwardButton.Enabled = false;
                    return;
                }
                try
                {
                    lastResult = searchResult;
                }
                catch (Exception)
                {
                    return;
                }

            }
            else
            {
                Utility utl = new Utility();
                int year;
                long month;
                try
                {
                    var mItem = (ComboboxItem)monthComboBox.SelectedItem;
                    if (mItem.Value == 0)
                    {
                        return;
                    }
                    month = mItem.Value;
                    year = Convert.ToInt32(yearComboBox.SelectedItem);
                }
                catch (Exception )
                {
                     MessageBox.Show(" ! ابتدا تاریخ را مشخص نمائید","هشدار ",MessageBoxButtons.OK,MessageBoxIcon.Warning);
                    return;

                }
                try
                {
                    var starEndofMonth = utl.getStartEndofMonth(year, month);
                    startEnd = starEndofMonth;
                }
                catch (Exception)
                {
                    MessageBox.Show("خطا در تاریخ");
                }
                resetNavigationButtons();

                if (login.permission)
                {
                    var item = (ComboboxItem)cityComboBox.SelectedItem;
                    login.cityID = item.Value;
                }
                var query = searchResultQuery(orderBy);
                if (!query.query.Any())
                {
                    /// MessageBox.Show(" ! نتیجه ایی یافت نشد","هشدار ",MessageBoxButtons.OK,MessageBoxIcon.Information);
                    /// 
                    this.mainDataGridView.DataSource = null;
                    this.forwardButton.Enabled = false;
                    return;
                }
                try
                {
                    lastResult = query;

                }
                catch (Exception ex)
                {
                    return;
                }

                refreshLastState(getLastState(), pageNumber, query);
            }
        }
        public void advanceSearch(StartEndMonthClass date)
        {
            if (login.permission)
            {
                var item = (ComboboxItem)cityComboBox.SelectedItem;
                login.cityID = item.Value;
            } 

            startEnd = date;
            advancedSearch = true;

            monthComboBox.Enabled = false;
            yearComboBox.Enabled = false;
            resetNavigationButtons();
            refreshLastState(getLastState(), pageNumber);

            //saveLastState(getLastState());
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
                catch (Exception )
                {
                  //  MessageBox.Show(ex.ToString());
                    MessageBox.Show("تاریخی برای تنظیم اولیه وجود ندارد ! با پشتیبانی تماس بگیرید");
                    return;
                }
            }
        }
        //private void searchinMonth()
        //{
        //    if (login.permission)
        //    {
        //        var item = (ComboboxItem)cityComboBox.SelectedItem;
        //        login.cityID = item.Value;
        //    }
        //    try {
        //        SqlManipulator sql = new SqlManipulator();
        //        Utility utl = new Utility();
        //        var mItem = (ComboboxItem)monthComboBox.SelectedItem;
        //        long month = mItem.Value;
        //        int year = Convert.ToInt32(yearComboBox.SelectedItem);

        //        try {
        //            var starEndofMonth = utl.getStartEndofMonth(year, month);
        //            startEnd = starEndofMonth;
        //        }
        //        catch (Exception)
        //        {
        //            MessageBox.Show("خطا در تاریخ");
        //        }
        //        pageNumber = 0;
        //        page = 0;
        //        backwardButton.Enabled = false;
        //        forwardButton.Enabled = true;
        //        LasteStateClass laste = new LasteStateClass();
        //        laste.cityID = login.cityID;
        //        laste.date = startEnd;
        //        laste.searchValue = this.searchTextBox.Text;
        //        /////alpha testing
        //        laste.lastYearSelected = this.yearComboBox.SelectedIndex;
        //        laste.lastMonthSelected = this.monthComboBox.SelectedIndex;
        //        laste.lastModeSelected = this.orderComboBox.SelectedIndex;

        //        lastYearSelected = this.yearComboBox.SelectedIndex;
        //        lastMonthSelected = this.monthComboBox.SelectedIndex;
        //        //// alpha testing
        //        saveLastState(laste);
        //    }
        //    catch (Exception) { throw; }
        //}
       
        private void monthComboBox_SelectionChangeCommitted(object sender, EventArgs e)
        {
            //  searchinMonth();
            search(defaultAscending);

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

                            MessageBox.Show("فایل اکسل با موفقیت ساخته شد", "پیغام سیستم ", MessageBoxButtons.OK, MessageBoxIcon.Information);

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
                        StartProgress();
                        textReportClass txt = new textReportClass(q.query, saveTextDialog.FileName);
                        CloseProgress();
                        MessageBox.Show("فایل متنی با موفقیت ساخته شد", "پیغام سیستم ", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
                else
                {
                    MessageBox.Show("تاریخ یا شهر را انتخاب کنید", "پیغام سیستم ", MessageBoxButtons.OK, MessageBoxIcon.Information);

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
            if(searchAllCheckBox.Checked)
            {
                monthComboBox.Enabled = false;
            }
            else
            {
                monthComboBox.Enabled = true;
            }
            
        }



        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            try {
                MessageBoxManager.Unregister();
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
            catch(Exception)
            {
                throw;
            }

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
            AddEditForm add = new AddEditForm(login, this, false, rowsData,pageNumber,getLastState());
            add.Show();

        }

        private void تغییرToolStripMenuItem_Click(object sender, EventArgs e)
        {
            EditForm edit = new EditForm(rowsData, this, login,godmode,pageNumber,getLastState());
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
            EditForm edit = new EditForm(rowsData, this, login,godmode,pageNumber,getLastState());
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
                search(defaultAscending);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void اضافهToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            AddEditForm add = new AddEditForm(login, this, true, rowsData,pageNumber,getLastState());
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
                EditForm edit = new EditForm(rowsData, this, login,godmode,pageNumber,getLastState());
                edit.Show();
            }
            if(e.KeyCode == Keys.F1)
            {
                AddEditForm add = new AddEditForm(login, this, true, rowsData,pageNumber,getLastState());
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
            ManagerForm mng = new ManagerForm(this,this.login);
            mng.Show();
        }

        private void searchTextBox_KeyUp(object sender, KeyEventArgs e)
        {
            if ((e.KeyCode == Keys.Enter) || (e.KeyCode == Keys.Return))
            {
                search(defaultAscending);
            }
        }
       
       
        private void notificate()
        {
            SqlManipulator sql = new SqlManipulator();
            var dbname = Properties.Settings.Default.dbName;
            sql.notify(login.Id,dbname);
            
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
                MessageBox.Show("لطفا سطری را برای اضافه کردن به دفتر انتخاب کنید", "پیغام سیستم ", MessageBoxButtons.OK, MessageBoxIcon.Information);


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

      

        private void orderComboBox_SelectionChangeCommitted(object sender, EventArgs e)
        {
        }

        private void monthComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            orderComboBox.Enabled = true;
        }

        private void ShowSelectedDataButton_Click(object sender, EventArgs e)
        {
            search(defaultAscending);
        }
        private void ascendBy(ascendingType ascendby)
        {
          
        }

        private void نامشهرToolStripMenuItem_Click(object sender, EventArgs e)
        {
            search((int)ascendingType.cityAscending);
        }

        private void تاریخToolStripMenuItem_Click(object sender, EventArgs e)
        {
            search((int)ascendingType.dateAscending);
        }

        private void شمارهقبضToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
        }

        private void نامصاحبسپردهToolStripMenuItem_Click(object sender, EventArgs e)
        {
            search((int)ascendingType.depositNameAscending);
        }

        private void واریزیToolStripMenuItem_Click(object sender, EventArgs e)
        {
            search((int)ascendingType.depositAscending);

        }

        private void استردادیToolStripMenuItem_Click(object sender, EventArgs e)
        {
            search((int)ascendingType.refundAscending);

        }
    }


}
