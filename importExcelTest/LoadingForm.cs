using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Windows.Forms;

namespace negar
{
    public partial class LoadingForm : Form
    {

        public LoadingForm()
        {
            InitializeComponent();
            Size size = new Size(30, 30);
        
            this.FormBorderStyle = FormBorderStyle.None;
            this.Size = size;
            this.BackColor =Color.Turquoise;
            this.TransparencyKey = Color.Turquoise;

            //  MessageBox.Show("hiiii");

        }
        //This method begins the animation.

       
        private void LoadingForm_Load(object sender, EventArgs e)
        {
        }
    }
}
