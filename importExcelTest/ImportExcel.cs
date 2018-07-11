using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Windows.Forms;
using WindowsFormsApplication1;

namespace negar
{

    public partial class ImportExcel : Form
    { 
      
        private MainForm mainForm;
        private LoginInfo login;
        private static List<IQueryable<Daftarcs>> excelData;
        private static string path;
        public ImportExcel(MainForm mainForm,LoginInfo login)
        {
            InitializeComponent();
            this.mainForm = mainForm;
            this.login = login;
            excelDataGridView.Enabled = false;
            excelData = new List<IQueryable<Daftarcs>>();
            excelMonthscomboBox.Enabled = false;
            importAllButton.Enabled = false;
            importButton1.Enabled = false;

        }
        private void setComboBoxCity()
        {  
            if(login.permission)
            { 
            try {
            cityComboBox.Enabled = true;
            SqlManipulator sql = new SqlManipulator();
            var cities = sql.queryCities();
            foreach (var city in cities)
            {
                cityComboBox.Items.Add(new ComboboxItem(city.CityName, city.Id));
            }
                    cityComboBox.SelectedIndex = 0;
                }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
                MessageBox.Show("شهری در پایگاه داده وجود ندارد");
            }
            }
            else
            {  
                cityComboBox.Items.Add(new ComboboxItem(login.cityName, login.cityID));
                cityComboBox.SelectedIndex = 0;
                cityComboBox.Enabled = false;
            }
        }
        private void Main_Load(object sender, EventArgs e)
        {
            setComboBoxCity();   
        }
        private void changeColumnName()
        {
            excelDataGridView.Columns[0].HeaderText = "استرداد";
            excelDataGridView.Columns[1].HeaderText = "کد مشخصات سپرده";
            excelDataGridView.Columns[2].HeaderText = "تاریخ";
            excelDataGridView.Columns[3].HeaderText = "واحد ثبتی";
            excelDataGridView.Columns[4].HeaderText = "نوع حساب";
            excelDataGridView.Columns[5].HeaderText = "مشخصات صاحب سپرده";
            excelDataGridView.Columns[6].HeaderText = "کد سپرده";
            excelDataGridView.Columns[7].HeaderText = "واریزی";
            excelDataGridView.Columns[8].HeaderText = "کد بودجه";
            excelDataGridView.Columns[9].HeaderText = "تاریخ حقیقی";
        }
        private Boolean setComboBoxData(IEnumerable<string> months)
        {   
            
            excelMonthscomboBox.Items.Clear();
            excelMonthscomboBox.Enabled = false;
      
            foreach (var month in months)
            {
                excelMonthscomboBox.Items.Add(month);
            }
            excelMonthscomboBox.Enabled = true;
            return true;
        }
        private void makeTable(IQueryable<Daftarcs> data)
        {
            try {
                if (data != null)
                {
                    var bs = new BindingSource();
                    bs.DataSource = data.ToList();
                    excelDataGridView.DataSource = bs;
                    DGV_SetStyle(this.excelDataGridView);
                }
              
            }
            catch (Exception ) { throw; }
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
            Thread th = new Thread(ShowProgress);
            th.Abort();
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
        private void openButton1_Click(object sender, EventArgs e)
        {
            excelMonthscomboBox.Enabled = false;
            excelDataGridView.Enabled = true;
            OpenFileDialog openFileDialog1 = new OpenFileDialog();

            openFileDialog1.Filter = "Excel Files|*.xlsx";
            openFileDialog1.Title = "فایل اکسل را انتخاب نمائید";
            if (openFileDialog1.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                ExcelValidationClass valid = new ExcelValidationClass();
                var file = openFileDialog1.FileName;
                path = file;
                try
                {
                   // StartProgress();
                    ExcelManipulatorcs excel = new ExcelManipulatorcs();
                    try {
                        excelData = excel.getDataFromFile(path);
                        valid = excel.check(excelData,file);
                        

                    }
                    catch (Exception ex) { MessageBox.Show(ex.Message); };
                    var monthComboBox = excel.getSheetsName(path);
                    if(!setComboBoxData(monthComboBox))
                    {
                        MessageBox.Show("sheet's name are not correct!");
                    }
                    excelMonthscomboBox.Enabled = true;
                    importButton1.Enabled = true;
                    excelMonthscomboBox.SelectedIndex = 0;
                    if (valid.isValid)
                    {
                        excelData = excel.ignoreBlanksRow(excelData);
                        makeTable(excelData[0]);
                        excelMonthscomboBox.SelectedIndex = 0;
                        changeColumnName();
                       // CloseProgress();
                    }
                    else
                    {
                        Report rpt = new Report(valid.report, (int)errorImages.info);
                        rpt.Show();
                        importButton1.Enabled = false;
                    }
            }
                catch (Exception a)
            {
                MessageBox.Show("خطا در باز کردن فایل. فایل مورد نظر خارج از قالب است! " + a.Message + " ");
              //  CloseProgress();

            }
        }
        }

        private void excelMonthscomboBox_SelectedIndexChanged(object sender, EventArgs e)
        {

            try {
                int select = excelMonthscomboBox.SelectedIndex;

                var x = excelData[select];

                makeTable(x);
            }
            catch(Exception ex )
            {
                MessageBox.Show(ex.Message);
            }
        }
 
        private void importAllButton_Click(object sender, EventArgs e)
        {
            try
            {
                if (login.permission)
                {
                    var dataToimport = excelData;
                    SqlManipulator sql = new SqlManipulator();
                    Utility util = new Utility();
                    foreach (var data in dataToimport)
                    {
                        var convertedData = util.convertYekeQuery(data.ToList());
                        var query = convertedData.AsQueryable();
                        ComboboxItem itm = (ComboboxItem)cityComboBox.SelectedItem;
                        long id = itm.Value;
                        sql.excelToSqlCopy(query, id);
                    }
                }
                else
                {
                    var dataToimport = excelData;
                    SqlManipulator sql = new SqlManipulator();
                    Utility util = new Utility();
                    foreach (var data in dataToimport)
                    {
                        var convertedData = util.convertYekeQuery(data.ToList());
                        var query = convertedData.AsQueryable();
                       
                        sql.excelToSqlCopy(query, login.cityID);
                    }
                }

                this.mainForm.refreshDGV();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Data.ToString());
            }
            this.Hide();
        }

        private void importButton1_Click(object sender, EventArgs e)
        {
            try
            {  
                if(refundRadioButton.Checked == false && depositRadioButton.Checked == false)
                {
                    MessageBox.Show("  لطفا نوع فایل را انتخاب  نمایید", "خطا",MessageBoxButtons.OK,MessageBoxIcon.Warning);
                    return;
                }
               // StartProgress();
                if (login.permission)
                {
                    var dataToimport = excelData[excelMonthscomboBox.SelectedIndex];
                 
                    SqlManipulator sql = new SqlManipulator();
                   

                    ExcelManipulatorcs excel = new ExcelManipulatorcs();
                    var query = excel.dataCorrection(dataToimport);

                    var itm = (ComboboxItem)cityComboBox.SelectedItem;
                    long id = itm.Value;

                    if (this.refundRadioButton.Checked)
                    {
                        var report = sql.refundFromFile(query, id);
                        Report rpt = new Report(report, Convert.ToInt32(errorImages.info));
                        rpt.Show();
                    }
                    if (this.depositRadioButton.Checked)
                    {
                        sql.excelToSqlCopy(query, id);
                    }

                    this.mainForm.refreshDGV();
                }
                else
                {
                    Utility util = new Utility();
                    var dataToimport = excelData[excelMonthscomboBox.SelectedIndex];
                    SqlManipulator sql = new SqlManipulator();
                    
                    var convertedData = util.convertYekeQuery(dataToimport.ToList());
                    convertedData = util.convertToRealDate(convertedData);

                    var query = convertedData.AsQueryable();

                    if(this.refundRadioButton.Checked)
                    {

                        var report =  sql.refundFromFile(query, login.cityID);
                        Report rpt = new Report(report,Convert.ToInt32(errorImages.info));
                        rpt.Show();
                    }
                    if (this.depositRadioButton.Checked)
                    {
                        sql.excelToSqlCopy(query, login.cityID);
                    }
                    

                    this.mainForm.refreshDGV();
                }
                excelData.Clear();
                
                this.Hide();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
          //  CloseProgress();
        }
        private void cityComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void ImportExcel_FormClosing(object sender, FormClosingEventArgs e)
        {
          
           

        }

        private void depositRadioButton_CheckedChanged(object sender, EventArgs e)
        {
        }

        private void refundRadioButton_CheckedChanged(object sender, EventArgs e)
        {
        }

        private void depositRadioButton_Click(object sender, EventArgs e)
        {
            refundRadioButton.Checked = false;

        }

        private void refundRadioButton_Click(object sender, EventArgs e)
        {
            depositRadioButton.Checked = false;

        }
    }
}