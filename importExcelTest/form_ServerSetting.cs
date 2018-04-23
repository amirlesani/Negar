using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace negar
{
    public partial class form_ServerSetting : Form
    {
        public form_ServerSetting()
        {
            InitializeComponent();
        }

        private void saveButton_Click(object sender, EventArgs e)
        {
            if (dataBasetextBox.Text != null || dataBasetextBox.Text != " ")
            {
                Properties.Settings.Default.ServerDataSource = serverComboBox.Text.ToString();
                Properties.Settings.Default.dbName = dataBasetextBox.Text.ToString();
                Properties.Settings.Default.dbUserName = userNameTextBox.Text.ToString();
                Properties.Settings.Default.dbPassword = passWordTextBox.Text.ToString();
                Properties.Settings.Default.Save();
                toolStripServerStatusLabel.Text = "با موفقیت ذخیره گردید";
                statusStrip1.Invalidate();
                statusStrip1.Refresh();

            }
            else
            {
                toolStripServerStatusLabel.Text = "خطا در ذخیره سازی";
                statusStrip1.Invalidate();
                statusStrip1.Refresh();
            }
        }


        private static bool IsServerConnected(string connectionString)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                
                    System.Net.NetworkInformation.Ping p = new System.Net.NetworkInformation.Ping();
                    System.Net.NetworkInformation.PingReply reply = p.Send(connection.DataSource);

                    if (reply.Status == System.Net.NetworkInformation.IPStatus.Success)
                    {
                        connection.Open();
                        return true;

                    }
                    else
                    {
                        MessageBox.Show(reply.Status.ToString(), "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return false;
                    }

                }
                catch (SqlException err)
                {
                    MessageBox.Show(err.Message, "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);

                return false;
                }
            }
        }
        private void button1_Click(object sender, EventArgs e)
        {
            string connectionString = string.Format("Data Source={0};Initial Catalog={1};User ID={2};Password={3};Connect Timeout=5",
             serverComboBox.Text.ToString(), dataBasetextBox.Text, userNameTextBox.Text, passWordTextBox.Text);

          //  SqlConnection cn = new SqlConnection(connectionString);



            Properties.Settings.Default.MainConnectionString = connectionString.ToString();




                if (IsServerConnected(connectionString))
                {
                toolStripServerStatusLabel.Text = "ارتباط برقرار شد";
                statusStrip1.Invalidate();
                statusStrip1.Refresh();
                }
                else
                {
                toolStripServerStatusLabel.Text = "خطا در ارتباط";
                statusStrip1.Invalidate();
                statusStrip1.Refresh();
            }

        }

        private void form_ServerSetting_Load(object sender, EventArgs e)
        {

            serverComboBox.Items.Add("127.0.0.1");

            serverComboBox.Text = Properties.Settings.Default.ServerDataSource;
            dataBasetextBox.Text = Properties.Settings.Default.dbName;
            userNameTextBox.Text = Properties.Settings.Default.dbUserName;
            passWordTextBox.Text = Properties.Settings.Default.dbPassword;
        }
    }
}
