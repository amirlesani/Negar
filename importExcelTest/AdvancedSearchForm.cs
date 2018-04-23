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
    
    public partial class AdvancedSearchForm : Form
    {
        MainForm form;
        public AdvancedSearchForm(MainForm form)
        {
            InitializeComponent();
            this.form = form;
            this.ControlBox = false;
        }

        private void searchButton_Click(object sender, EventArgs e)
        {

            DateTime endTime = dateTimePickerX1.SelectedDateInDateTime;
            DateTime startTime = dateTimePickerX2.SelectedDateInDateTime;

            StartEndMonthClass date = new StartEndMonthClass();
            date.startDate = Convert.ToInt64(startTime.ToFa("yyyyMMdd"));
            date.endDate = Convert.ToInt64(endTime.ToFa("yyyyMMdd"));
           
            form.advanceSearch(date);
            this.Hide();
            
        }

        private void AdvancedSearchForm_Load(object sender, EventArgs e)
        {

        }

        private void dateTimePickerX1_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void dateTimePickerX1_Load_1(object sender, EventArgs e)
        {

        }
    }
}
