using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Windows.Forms;

namespace negar
{
    public partial class NoteBook : Form
    {
        private IQueryable<DaftarTable> tempData;
        private List<DaftarTable> dataForchanging;

        public NoteBook()
        {
            InitializeComponent();
            try
            {
                dataForchanging = new List<DaftarTable>();
                setDataGridView();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }
        private List<string> getColumnsHeader()
        {
            List<string> header = new List<string>();
            header.Add("شناسه");
            header.Add("استرداد");
            header.Add("شماره قبض سپرده");
            header.Add("تاریخ");
            header.Add("واحد ثبتی");
            header.Add("نوع حساب");
            header.Add("مشخصات صاحب سپرده");
            header.Add("کد مشخصات سپرده");
            header.Add("واریزی");
            header.Add("کد بودجه");
            header.Add("کد شهر");
            header.Add("تاریخ حقیقی");
            return header;
        }
        private void changeColumnName()
        {
            var header = getColumnsHeader();
            int i = 0;
            foreach (var a in header)
            {
                NoteBookDataGridView.Columns[i].HeaderText = a.ToString();
                i++;
            }
        }
        public void setDataGridView()
        {
            try
            {
                this.NoteBookDataGridView.DataSource = null;
                DGV_SetStyle(this.NoteBookDataGridView);
                this.NoteBookDataGridView.ClearSelection();
                XMLHandler xml = new XMLHandler();

                if (xml.isFileExist())
                {
                    var data = xml.loadXMLData();

                    if (data.Any())
                    {
                        tempData = data;

                        this.NoteBookDataGridView.DataSource = data.ToList();
                        changeColumnName();
                        DGV_SetStyle(this.NoteBookDataGridView);
                    }
                    else
                    {
                        this.NoteBookDataGridView.DataSource = null;
                        this.NoteBookDataGridView.Rows.Clear();
                        this.NoteBookDataGridView.Refresh();
                    }

                }
                else
                {
                    this.NoteBookDataGridView.Rows.Clear();
                    this.NoteBookDataGridView.Refresh();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }


        }
        public void DGV_SetStyle(DataGridView Dgv)
        {
            //foreach (DataGridViewRow Row in Dgv.Rows)
            //{
            //    if (Row.Index % 2 == 0)
            //    {
            //        Row.DefaultCellStyle.BackColor = Properties.Settings.Default.dgvColor;
            //    }
            //}
        }

        private void فایلToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            e.Cancel = true;
            this.Hide();

        }
        private void exitButton_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void فایلاکسلToolStripMenuItem_Click(object sender, EventArgs e)
        {

            Stream mystream;
            SaveFileDialog saveExcelDialog = new SaveFileDialog();
            saveExcelDialog.Filter = "Excel files (*.xlsx)|*.xlsx";
            saveExcelDialog.FilterIndex = 2;
            saveExcelDialog.RestoreDirectory = true;
            if (saveExcelDialog.ShowDialog() == DialogResult.OK)
            {
                if ((mystream = saveExcelDialog.OpenFile()) != null)
                {
                    var header = getColumnsHeader();
                    StartProgress();
                    ExcelGeneratorClass createReport = new ExcelGeneratorClass(tempData.ToList(), saveExcelDialog.FileName, header);
                    mystream.Close();
                    CloseProgress();
                    MessageBox.Show("فایل اکسل با موفقیت ساخته شد");

                }
            }
        }

        private void فایلمتنیToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveTextDialog = new SaveFileDialog();
            saveTextDialog.Filter = "Text files (*.txt)|*.txt";
            saveTextDialog.FilterIndex = 2;
            saveTextDialog.RestoreDirectory = true;
            if (saveTextDialog.ShowDialog() == DialogResult.OK)
            {
                textReportClass txt = new textReportClass(tempData, saveTextDialog.FileName);
            }
        }

        private void NoteBookDataGridView_SelectionChanged(object sender, EventArgs e)
        {
            dataForchanging.Clear();

            foreach (DataGridViewRow row in NoteBookDataGridView.SelectedRows)
            {
                try
                {
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

                    dataForchanging.Add(data);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.ToString());
                }

            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            XMLHandler xml = new XMLHandler();
            xml.remove(dataForchanging);
            setDataGridView();
            
        }
        private void rightclick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.Button == System.Windows.Forms.MouseButtons.Right)
            {
                contextMenuStrip1.Show(Cursor.Position.X, Cursor.Position.Y);
            }
        }

        private void NoteBookDataGridView_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            rightclick(sender, e);

        }

        private void حذفToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (dataForchanging.Any())
            {
                XMLHandler xml = new XMLHandler();
                xml.remove(dataForchanging);
                setDataGridView();
            }
            else
            {
                MessageBox.Show("خالی است");
            }
        }

        private void NoteBookDataGridView_CellMouseDown(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                try
                {
                    NoteBookDataGridView.CurrentCell = NoteBookDataGridView.Rows[e.RowIndex].Cells[e.ColumnIndex];
                    // Can leave these here - doesn't hurt
                    NoteBookDataGridView.Rows[e.RowIndex].Selected = true;
                    NoteBookDataGridView.Focus();

                    // selectedBiodataId = Convert.ToInt32(dgrdResults.Rows[e.RowIndex].Cells[1].Value);
                }
                catch (Exception)
                {
                    
                }
            }
        }

        private void خروجToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void حذفToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("آیا از حذف مطمئن هستید؟", "هشدار", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (dialogResult == DialogResult.Yes)
            {
                if (dataForchanging.Any())
                {
                    XMLHandler xml = new XMLHandler();
                    xml.remove(dataForchanging);
                    setDataGridView();

                }
                else
                {
                    MessageBox.Show("سطری را انتخاب کنید");
                }
            }

        }
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
                    catch (Exception) { }
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
        private void حذفهمهToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void NoteBookDataGridView_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Delete)
            {
                DialogResult dialogResult = MessageBox.Show("آیا از حذف مطمئن هستید؟", "هشدار", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (dialogResult == DialogResult.Yes)
                {
                    if (dataForchanging.Any())
                    {
                        XMLHandler xml = new XMLHandler();
                        xml.remove(dataForchanging);
                        setDataGridView();

                    }
                    else
                    {
                        MessageBox.Show("سطری را انتخاب کنید");
                    }
                }
            }
          
                // do something with selectedCell...
        }
        
    }
}
