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
using WindowsFormsApplication1;

namespace negar
{
    public partial class FileCheckerForm : Form
    {
        public FileCheckerForm()
        {
            InitializeComponent();
            this.openFileDialog1.Multiselect = true;
        }

        string[] files;

        private void check(object f)
        {
            try { 
            string[] files = (string[])f;
            if (files == null || files.Length == 0)
            {
                MessageBox.Show("هشدار", "فایل را انتخاب کنید", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            ExcelManipulatorcs excel = new ExcelManipulatorcs();
            List<string> list = new List<string>();
            List<List<string>> t = new List<List<string>>();
            foreach (String file in  files)
                {
                    string filenameWithoutPath = Path.GetFileName(file);
                    var validation = excel.check(excel.getDataFromFile(file), filenameWithoutPath);
                    if (!validation.isValid) {
                    t.Add(validation.report);       
                }
                    else { string msg = " فایل  سالم است : \n" + filenameWithoutPath; list.Add(msg); }
                };
            t.Add(list);
            if (InvokeRequired)
            {
                this.Invoke(new Action(() => CreateAndShowForm(t)));
                return;
            }
            }
            catch(Exception )
            {
                MessageBox.Show("جدول خارج از قالب است");
            }


        }
        private void CreateAndShowForm(List<List<string>> list)
        {
            Reporter frm =  new Reporter(list);
            frm.ShowDialog();
        }

        private void openButton_Click(object sender, EventArgs e)
        {
            try { 
            DialogResult dr = this.openFileDialog1.ShowDialog();
            if (dr == System.Windows.Forms.DialogResult.OK)
            {
                files = openFileDialog1.FileNames;

            }

            if (files ==null)
                return;
            foreach (String file in files)
                {
                    string directoryPath = Path.GetDirectoryName(file);
                    this.adressTextBox.Text = directoryPath;
               }
            Thread newThread = new Thread(this.check);
            newThread.Start(files);
            }


            catch (Exception) { return; }
        }
    }
}
