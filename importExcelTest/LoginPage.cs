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
    
    public partial class LoginPage : Form
    {
        private bool permission;
        MainForm form;
         
        int currentVersion = global.currentVersion;
        SplashScreenForm formwait;
        public LoginPage()
        {
            InitializeComponent();
            form = new MainForm();

           
            //try {  }
            //catch(Exception ex) { MessageBox.Show(ex.ToString()); };



        }
        Timer tmr;

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
                        return false;
                    }

                }
                catch (SqlException err)
                {

                    MessageBox.Show(err.Message);
                    return false;
                }
            }
        }

        private void loginButton_Click(object sender, EventArgs e)
        {
            try
            {
                var cn = Properties.Settings.Default.MainConnectionString;
                if (IsServerConnected(cn))
                {
                    UserManagerDataClassesDataContext db = new UserManagerDataClassesDataContext(cn);
                    foreach (var q in db.UserTables)
                    {
                        if (q.User == this.UserNametextBox.Text && q.Password == this.PasswordTextBox.Text)
                        {
                            this.Hide();
                            LoginInfo login = new LoginInfo();
                            login.cityID = q.City;
                            login.Name = q.Name;
                            login.Id = q.Id;
                            login.family = q.Family;
                            login.permission = q.Permission.Value;
                            login.user = q.User;
                            login.update = q.Update.Value;
                            login.messages = q.Messages;
                            login.version  = q.Version ?? default(int) ;
                            login.adminVersion = q.AdminVersion ?? default(bool);
                            if ( login.version > currentVersion && !login.adminVersion)
                            {
                                MessageBox.Show(login.messages, "نسخه شما بروز نیست . آخرین نسخه بروز شده را نصب کنید ",
                                   MessageBoxButtons.OK,
                                   MessageBoxIcon.Stop);
                                this.Close();
                                return;
                            }
                          

                            SqlManipulator sql = new SqlManipulator();
                            if (!login.adminVersion)
                            {
                                if (login.update)
                                {
                                    MessageBox.Show(login.messages, "پیغام ",
                                    MessageBoxButtons.OK,
                                    MessageBoxIcon.Information);
                                    try {
                                        sql.MessagesSeenStatus(false, login);
                                    }
                                    catch(Exception)
                                    { MessageBox.Show("خطا در  پیغام"); }
                                }
                            }
                            string cityName = sql.getCityName(login.cityID);
                            login.cityName = cityName;
                                                       form.setLoginData(login);
                            
                            Properties.Settings.Default.LastUser = this.UserNametextBox.Text;

                            tmr = new Timer();

                            //set time interval 3 sec

                            tmr.Interval = 3500;

                            //starts the timer
                            formwait = new SplashScreenForm();
                            formwait.Show();
                            tmr.Start();

                            tmr.Tick += tmr_Tick;
                            permission = q.Permission.Value;
                            Properties.Settings.Default.Save();
                            return;
                        }
                    }
                    MessageBox.Show("نام کاربری و گذر واژه فاقد اعتبار است", "خطا",
                      MessageBoxButtons.OK,
                      MessageBoxIcon.Error);
                    return;
                }
                else
                {
                    MessageBox.Show("ارتباط با سرور قطع است ، تنظیمات سرور را بررسی کنید", "خطا",
                       MessageBoxButtons.OK,
                       MessageBoxIcon.Error);

                    return;
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }
        void tmr_Tick(object sender, EventArgs e)

        {

            //after 3 sec stop the timer
            
            tmr.Stop();

            //display mainform
            formwait.Hide();
            form.Show();


            //hide this form

            this.Hide();

        }
       
        private void GearPictureBox_MouseClick(object sender, MouseEventArgs e)
        {
            form_ServerSetting srv = new form_ServerSetting();
            srv.Show();
        }

        private void LoginButton_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                loginButton_Click(this, new EventArgs());
            }
        }

        private void PasswordTextBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                loginButton_Click(this, new EventArgs());
            }
        }

        private void UserNametextBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                loginButton_Click(this, new EventArgs());
            }
        }

       
        private void LoginPage_Load(object sender, EventArgs e)
        {
            UserNametextBox.Text = Properties.Settings.Default.LastUser.ToString();
            
        }

        private void GearPictureBox_Click(object sender, EventArgs e)
        {

        }
    }
}
public static class global
{
    public static Int32 currentVersion = 1;
}
