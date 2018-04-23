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
    public partial class infoForm : Form
    {
        public infoForm()
        {
            InitializeComponent();
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void listBox1_SelectedIndexChanged_1(object sender, EventArgs e)
        {

        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            this.pictureBox2.Hide();
            this.pictureBox1.Show();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            this.pictureBox1.Hide();
            this.pictureBox2.Show();
        }
    }
}
