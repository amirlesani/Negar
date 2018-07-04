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
    public partial class EditForm : Form
    {
        DaftarTable data;
        MainForm form;
        LoginInfo login;
        LasteStateClass lastState;
        int pageNumber;
        bool godmode;
        public EditForm(DaftarTable data,MainForm form,LoginInfo login,bool godmode,int pageNumber,LasteStateClass lastState)
        {
            InitializeComponent();
            this.data = data;
            this.form = form;
            this.pageNumber = pageNumber;
            this.lastState = lastState;
            this.godmode = godmode;
            this.login = login;
        }
        private void setPlaceComboBox()
        {
            AccountTypeComboBox.SelectedIndex = 0;
            placeComboBox.Items.Clear();
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
        private void numericonly(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) )
            {
                e.Handled = true;
            }

            // only allow one decimal point
            //if ((e.KeyChar == '.') && ((sender as TextBox).Text.IndexOf('.') > -1))
            //{
            //    e.Handled = true;
            //}
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

        private void editButton_Click(object sender, EventArgs e)
        {  
            try
            {
                if (!inputValidation()) { return; }
                Utility utl = new Utility();
                SqlManipulator sql = new SqlManipulator();
                DaftarTable newDaftar = new DaftarTable();
                if (login.permission)
                {
                    var itm = (ComboboxItem)placeComboBox.SelectedItem;
                    login.cityID = itm.Value;
                }
                else
                {
                    newDaftar.CityID = login.cityID;
                }
                newDaftar.Id = data.Id;
                 
                //var item = (ComboboxItem)placeComboBox.SelectedItem;
                //newDaftar.CityID = item.Value;
                newDaftar.Refund = Convert.ToInt64(this.refundTextBox.Text);
                newDaftar.AccountType = this.AccountTypeComboBox.SelectedItem.ToString();
              //  newDaftar.BillDetailCode = Convert.ToInt64(this.billDetailCodetextBox.Text);
                newDaftar.CodeBudget = Convert.ToInt64(this.BudgetCodetextBox.Text);
                //newDaftar.Date = this.dateMaskedTextBox.Text;
                newDaftar.PlaceName = placeComboBox.SelectedItem.ToString();
               // newDaftar.RealDate = utl.changeToRealDate(newDaftar.Date);
                newDaftar.Deposit = Convert.ToInt64(this.DepositTextBox.Text);
                newDaftar.RealDate = data.RealDate;
                newDaftar.DepositDetail = Convert.ToInt64(this.DepositDetailtextBox.Text);
                newDaftar.DepositOwnerDetail = this.DepositOwnerDetailTextBox.Text;
                newDaftar.CityID = data.CityID;

                if (sql.isRestricted(newDaftar,login.permission))
                {
                    MessageBox.Show("دسترسی شما به این تاریخ توسط مدیر سیستم محدود شده است","خطا",
                          MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
                    return;
                };
                Report rpt = new Report(sql.update(newDaftar,godmode), (int)errorImages.info);
                rpt.Show();
                form.refreshLastState(lastState, pageNumber);
                this.Hide();
            }
            catch (Exception ex)
            {
                MessageBox.Show("ورودی های خود را کنترل نمائید" , "خطا",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
                MessageBox.Show(ex.Message);
            }
        }

        private void EditForm_Load(object sender, EventArgs e)
        {
            try {
                setPlaceComboBox();
                this.billDetailCodetextBox.Text = data.BillDetailCode.ToString();
                this.billDetailCodetextBox.Visible = false;

                this.DepositTextBox.Text = data.Deposit.ToString();
                this.DepositOwnerDetailTextBox.Text = data.DepositOwnerDetail.ToString();
                this.DepositDetailtextBox.Text = data.DepositDetail.ToString();
                this.refundTextBox.Text = data.Refund.ToString();

                this.dateMaskedTextBox.Text = data.Date.ToString();
                this.dateMaskedTextBox.Visible = false;

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
                placeComboBox.Visible = false;
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        private void ClosbeButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void billDetailCodetextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            numericonly(sender, e);

        }

        private void BudgetCodetextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            numericonly(sender, e);
        }

        private void DepositTextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            numericonly(sender, e);
        }

        private void refundTextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            numericonly(sender, e);
        }

        private void DepositDetailtextBox_KeyUp(object sender, KeyEventArgs e)
        {
            Control_KeyUp(sender, e);
        }

        private void DepositDetailtextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            numericonly(sender, e);

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

        private void dateMaskedTextBox_KeyUp(object sender, KeyEventArgs e)
        {
            Control_KeyUp(sender, e);

        }

        private void AccountTypeComboBox_KeyUp(object sender, KeyEventArgs e)
        {
            Control_KeyUp(sender, e);

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

        private void EditForm_KeyDown(object sender, KeyEventArgs e)
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
