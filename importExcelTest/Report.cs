using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Windows.Forms;
using System.Xml.Linq;

namespace negar
{
    public partial class Report : Form
    {


        public Report(List<string> list,int errorType)
        {
            
            InitializeComponent();
            listView1.SmallImageList = errorImageList;
            listView1.AutoResizeColumns(ColumnHeaderAutoResizeStyle.ColumnContent);
            listView1.AutoResizeColumns(ColumnHeaderAutoResizeStyle.HeaderSize);


            //   reportListBox.DataSource = list;
            foreach (var a in list)
            {
                listView1.Items.Add(a, errorType);
            }
            SetListViewColumnSizes(listView1, -2);
        }
        public Report()
        {
            InitializeComponent();
            listView1.AutoResizeColumns(ColumnHeaderAutoResizeStyle.ColumnContent);
            listView1.AutoResizeColumns(ColumnHeaderAutoResizeStyle.HeaderSize);

            //reportListBox.DataSource = null;

        }
        public Report(List<List<string>> lists)
        {
            InitializeComponent();
            listView1.AutoResizeColumns(ColumnHeaderAutoResizeStyle.ColumnContent);
            listView1.AutoResizeColumns(ColumnHeaderAutoResizeStyle.HeaderSize);

            List<string> t = new List<string>();
            foreach (var list in lists)
            {
                t.AddRange(list);
            }
            foreach (var a in t)
            {
                listView1.Items.Add(a, (int)errorImages.info);

            }
            SetListViewColumnSizes(listView1,500);
        }
        private void SetListViewColumnSizes(ListView lvw, int width)
        {
            listView1.AutoResizeColumns(ColumnHeaderAutoResizeStyle.HeaderSize);

           
          
          
        }

        public void addItem(XElement data)
        {
            
            var messagesList = (from message in data.Elements("inserted").Elements("row")
                                select new
                                {
                                    Id = message.Element("Id").Value,
                                    DepositOwnerDetail = message.Element("DepositOwnerDetail").Value,
                                    CityID = message.Element("CityID").Value,
                                    CityName = message.Element("PlaceName").Value
                                    
                                });
             messagesList = (from message in data.Elements("deleted").Elements("row")
                                select new
                                {
                                    Id = message.Element("Id").Value,
                                    DepositOwnerDetail = message.Element("DepositOwnerDetail").Value,
                                    CityID = message.Element("CityID").Value,
                                    CityName = message.Element("PlaceName").Value
                                });
            Invoke(new Action(() =>
            {
                foreach (var a in messagesList)
                {
                    var msg =" شناسه  " +a.Id.ToString() + " شهر " + a.CityName.ToString() +" "+ a.DepositOwnerDetail.ToString()+"  تغییر کرده است " ;
                    //this.reportListBox.Items.Add(msg);

                    this.listView1.Items.Add(msg, (int)errorImages.watch);
                    SetListViewColumnSizes(listView1, -1);
                }
                //this.Show();
            }));
            //foreach (var a in messagesList)
            //{
            //    this.reportListBox.Items.Add(a.Id);
            //}

        }
        private void Report_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

      
    }
    internal static class FormExtensions
    {
        private static void ApplicationRunProc(object state)
        {
            Application.Run(state as Form);
        }

        public static void RunInNewThread(this Form form, bool isBackground)
        {
            if (form == null)
                throw new ArgumentNullException("form");
            if (form.IsHandleCreated)
                throw new InvalidOperationException("Form is already running.");
            Thread thread = new Thread(ApplicationRunProc);
            thread.SetApartmentState(ApartmentState.STA);
            thread.IsBackground = isBackground;
            thread.Start(form);
        }
    }
}

