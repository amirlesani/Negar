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
    public partial class UserSettingsForm : Form
    {   
        private MainForm mainForm;
        private Color color ;
        bool isColorSelected;
        public UserSettingsForm(MainForm mainform)
        {
            InitializeComponent();
            this.mainForm = mainform;
            isColorSelected = false;
        }

        private void changeColorButton_Click(object sender, EventArgs e)
        {



          
            if (isColorSelected)
            { color = DGVcolorDialog.Color; }
            else { color = Properties.Settings.Default.dgvColor; }
              
            
                Properties.Settings.Default.dgvColor = color;
                this.mainForm.refreshDGV();
                 Properties.Settings.Default.Save();
        
        }

        private void UserSettingsForm_Load(object sender, EventArgs e)
        {
            DGVcolorDialog.AllowFullOpen = true;
            color = Properties.Settings.Default.dgvColor;
            this.rowsNumericUpDown.Value = Properties.Settings.Default.pageSize;
            this.colorPalletePictureBox.BackColor = Properties.Settings.Default.dgvColor;

        }

        private void changeRowsButton_Click(object sender, EventArgs e)
        {
            Properties.Settings.Default.pageSize = Convert.ToInt32(rowsNumericUpDown.Value);
            this.mainForm.setPageSize(Convert.ToInt32(rowsNumericUpDown.Value));
            Properties.Settings.Default.Save();
        }

        private void colorPalletePictureBox_Click(object sender, EventArgs e)
        {

            DialogResult dlg = DGVcolorDialog.ShowDialog();
            if (dlg == DialogResult.OK)
            {
                color = DGVcolorDialog.Color;
                isColorSelected = true;
                this.colorPalletePictureBox.BackColor = color;

            }
        }

        private void rowsNumericUpDown_ValueChanged(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
          
        }
    }
}
