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
    public partial class AddEditForm : Form
    {
        LoginInfo login = new LoginInfo();
        MainForm form;
        bool copy;
        DaftarTable data;
        public AddEditForm(LoginInfo login, MainForm form,bool addCopiedRow, DaftarTable data)
        {
            InitializeComponent();
            this.login = login;
            this.form = form;
            this.data = data;
            this.AccountTypeComboBox.SelectedIndex = 0;
            this.copy = addCopiedRow;
            setPlaceComboBox();
        }
        private void setPlaceComboBox()
        {
            if (!login.permission)
            {
                placeComboBox.Items.Add(new ComboboxItem(login.cityName, login.cityID));
                placeComboBox.SelectedIndex = 0;
                placeComboBox.Enabled = false;
            }
            else {
                try
                {
                    SqlManipulator sql = new SqlManipulator();
                    var cities = sql.queryCities();
                    foreach (var city in cities)
                    {
                        placeComboBox.Items.Add(new ComboboxItem(city.CityName, city.Id));
                    }
                    placeComboBox.Enabled = true;
                    placeComboBox.SelectedIndex = 0;
                }
                catch (Exception)
                {
                    throw;
                }
            }

        }

        private void AddEditForm_Load(object sender, EventArgs e)
        {
            if(this.copy)
            {
                try
                {
                    this.billDetailCodetextBox.Text = data.BillDetailCode.ToString();
                    this.DepositTextBox.Text = data.Deposit.ToString();
                    this.DepositOwnerDetailTextBox.Text = data.DepositOwnerDetail.ToString();
                    this.DepositDetailtextBox.Text = data.DepositDetail.ToString();
                    this.refundTextBox.Text = data.Refund.ToString();
                    this.dateMaskedTextBox.Text = data.Date.ToString();
                    this.AccountTypeComboBox.SelectedText = data.AccountType.ToString();
                    this.BudgetCodetextBox.Text = data.CodeBudget.ToString();
                    var x = data.CityID;
                    int c = 0;
                    foreach (var i in placeComboBox.Items)
                    {
                        var p = (ComboboxItem)i;
                        if (p.Value == x)
                        {
                            placeComboBox.SelectedIndex = c;
                        }
                        c++;
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }
        private bool inputValidation()
        {
            Utility utl = new Utility();
            inputErrorProvider.Clear();
            if (utl.isNullorWhiteSpace(DepositOwnerDetailTextBox.Text))
            {
                inputErrorProvider.SetError(this.DepositOwnerDetailTextBox, "ورودی خالی است");
                return false;
            }
            if (!utl.isvalidDate(this.dateMaskedTextBox.Text))
            {
                inputErrorProvider.SetError(dateMaskedTextBox, "تاریخ اشتباه است");
                return false;
            }
            if (utl.isNullorWhiteSpace(billDetailCodetextBox.Text))
            {
                inputErrorProvider.SetError(this.billDetailCodetextBox, "ورودی خالی است");
                return false;
            }
            if (utl.isNullorWhiteSpace(BudgetCodetextBox.Text))
            {
                inputErrorProvider.SetError(this.BudgetCodetextBox, "ورودی خالی است");
                return false;
                
            }
            if (utl.isNullorWhiteSpace(DepositTextBox.Text))
            {
                inputErrorProvider.SetError(this.DepositTextBox, "ورودی خالی است");
                return false;
            }
            if (utl.isNullorWhiteSpace(refundTextBox.Text))
            {   

                inputErrorProvider.SetError(this.refundTextBox, "ورودی خالی است");
                return false;
            }
            if (utl.isNullorWhiteSpace(DepositDetailtextBox.Text))
            {
                inputErrorProvider.SetError(this.DepositDetailtextBox, "ورودی خالی است");
                return false;
            }
            else
            {
                inputErrorProvider.Clear();
                return true;
            }
        }
        private void addButton_Click(object sender, EventArgs e)
        {
            try
            {  
                Utility utl = new Utility();
                DaftarTable newDaftar = new DaftarTable();

                   if (!inputValidation()) { return; }

                    newDaftar.Refund = Convert.ToInt64(this.refundTextBox.Text);
                    newDaftar.AccountType = YeKe.ApplyCorrectYeKe(this.AccountTypeComboBox.Text);

                    newDaftar.BillDetailCode = Convert.ToInt64(this.billDetailCodetextBox.Text);
                    newDaftar.CodeBudget = Convert.ToInt64(this.BudgetCodetextBox.Text);
                    newDaftar.Date = (this.dateMaskedTextBox.Text);

                    newDaftar.RealDate = utl.changeToRealDate(newDaftar.Date);
                    newDaftar.Deposit = Convert.ToInt64(this.DepositTextBox.Text);
                    newDaftar.DepositDetail = Convert.ToInt64(this.DepositDetailtextBox.Text);
                    newDaftar.DepositOwnerDetail = YeKe.ApplyCorrectYeKe(this.DepositOwnerDetailTextBox.Text);

                    if (login.permission)
                    {
                        var item = (ComboboxItem)placeComboBox.SelectedItem;
                        login.cityID = item.Value;
                        newDaftar.Id = utl.idGenerator(login.cityID, newDaftar.Date, newDaftar.BillDetailCode);
                        newDaftar.CityID = login.cityID;
                        newDaftar.PlaceName = item.Text;

                    }
                    else
                    {
                        newDaftar.Id = utl.idGenerator(login.cityID, newDaftar.Date, newDaftar.BillDetailCode);
                        newDaftar.CityID = login.cityID;
                        newDaftar.PlaceName = login.cityName;
                    }



                SqlManipulator sql = new SqlManipulator();
                if (sql.isRestricted(newDaftar))
                {
                    MessageBox.Show("دسترسی شما به این تاریخ توسط مدیر سیستم محدود شده است" ,"خطا",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Error);
                    return;
                };
               
                Report rpt = new Report( sql.addRow(newDaftar));
                    rpt.Show();
                    
                    form.refreshLastState();
                }
               
            catch (Exception ex)
            {
                MessageBox.Show(ex.Data.ToString(),
                    "خطا",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
                MessageBox.Show("ورودی های  خود را کنترل نمایید");
            }
        }

        private void ClosbeButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void DepositOwnerDetailTextBox_TextChanged(object sender, EventArgs e)
        {

        }
        private void Control_KeyUp(object sender, KeyEventArgs e)
        {
            if ((e.KeyCode == Keys.Enter) || (e.KeyCode == Keys.Return))
            {
                this.SelectNextControl((Control)sender, true, true, true, true);
            }
        }


        private void DepositOwnerDetailTextBox_KeyUp(object sender, KeyEventArgs e)
        {
            Control_KeyUp(sender, e);
        }

        private void dateTextBox_KeyUp(object sender, KeyEventArgs e)
        {
            Control_KeyUp(sender, e);

        }

        private void AccountTypeComboBox_KeyUp(object sender, KeyEventArgs e)
        {
            Control_KeyUp(sender, e);

        }

        private void billDetailCodetextBox_TextChanged(object sender, EventArgs e)
        {

        }

        private void billDetailCodetextBox_KeyUp(object sender, KeyEventArgs e)
        {
            Control_KeyUp(sender, e);

        }

        private void BudgetCodetextBox_KeyUp(object sender, KeyEventArgs e)
        {
            Control_KeyUp(sender, e);

        }

        private void DepositTextBox_KeyUp(object sender, KeyEventArgs e)
        {
            Control_KeyUp(sender, e);

        }

        private void refundTextBox_KeyUp(object sender, KeyEventArgs e)
        {
            Control_KeyUp(sender, e);
        }

        private void placeComboBox_KeyUp(object sender, KeyEventArgs e)
        {
            Control_KeyUp(sender, e);

        }

        private void DepositDetailtextBox_KeyUp(object sender, KeyEventArgs e)
        {
            Control_KeyUp(sender, e);
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void billDetailCodetextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            numericonly(sender,e);
        }
        private void numericonly(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) &&
           (e.KeyChar != '.'))
            {
                e.Handled = true;
            }

            // only allow one decimal point
            if ((e.KeyChar == '.') && ((sender as TextBox).Text.IndexOf('.') > -1))
            {
                e.Handled = true;
            }
        }

        private void BudgetCodetextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            numericonly(sender, e);

        }

        private void DepositTextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            numericonly(sender, e);
        }

        private void refundTextBox_TextChanged(object sender, EventArgs e)
        {

        }

        private void refundTextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            numericonly(sender, e);
        }

        private void DepositDetailtextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            numericonly(sender, e);
        }

        private void dateMaskedTextBox_KeyUp(object sender, KeyEventArgs e)
        {
            Control_KeyUp(sender, e);
        }

        private void AddEditForm_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                this.Close();
            }
     }
        protected override bool ProcessDialogKey(Keys keyData)
        {
            if (Form.ModifierKeys == Keys.None && keyData == Keys.Escape)
            {
                this.Close();
                return true;
            }
            return base.ProcessDialogKey(keyData);
        }

    }
}
