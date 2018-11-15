using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace vkaudioposter
{
    public partial class LoginForm : Form
    {
        bool valuesSet = Properties.Settings.Default.Values_set;
        public LoginForm()
        {
            Text = "Настройки";
            InitializeComponent();
            TB_ownerID.Text = Properties.Settings.Default["ownerid3"].ToString();
            TB_Token.PasswordChar = '*';
            TB_Token.Text = Properties.Settings.Default["Token"].ToString();
            TB_TokenApp.PasswordChar = '*';
            TB_TokenApp.Text = Properties.Settings.Default["accesstoken"].ToString();
            TB_PublicId.Text = Properties.Settings.Default["groupid"].ToString();
            TB_ftpAddress.Text = Properties.Settings.Default["ftpAddress"].ToString();
            TB_ftpLogin.Text = Properties.Settings.Default["ftpUsername"].ToString();
            TB_ftpPass.PasswordChar = '*';
            TB_ftpPass.Text = Properties.Settings.Default["ftpPassword"].ToString();
            TB_Login.Text = Properties.Settings.Default["Login"].ToString();
            TB_Pass.PasswordChar = '*';
            TB_Pass.Text = Properties.Settings.Default["Password"].ToString();
            TB_AppId.Text = Properties.Settings.Default["AppId"].ToString();
            this.toolTip1.SetToolTip(this, "Внимательно без ошибок задавайте настройки!");
            

            //toolTip1.ToolTipTitle="Номер телефона";
           // toolTip1.SetToolTip(TB_Login, "Номер телефона или e-mail");
            //toolTip1.SetToolTip(TB_ownerID, "Только цифры, никаких ников!");
           // toolTip1.SetToolTip(TB_AppId, "ID Standalone приложения, создайте Standalone через https://vk.com/dev и из Настроек скопируйте ID");
           // toolTip1.SetToolTip(TB_TokenApp, "Из Настроек Вашего приложения скопируйте токен");
           // toolTip1.SetToolTip(TB_Token, "Введите ID приложения и нажмите кнопку Get Token, затем скопируйте из ссылки в браузере все что после &token в поле Token");
           // toolTip1.SetToolTip(TB_ftpAddress, "Введите прямой путь FTP до файла posted_tracks.dll");
            //TB_Login
            //TB_Login

        }

        private void TB_ownerID_TextChanged(object sender, EventArgs e)
        {
            Properties.Settings.Default["ownerid3"] = Convert.ToUInt64(TB_ownerID.Text);
            this.toolTip1.SetToolTip(this, "Только цифры, никаких ников!");
            //Properties.Settings.Default.Upgrade();
            //Properties.Settings.Default.Save(); // Saves settings in application configuration file
        }

        private void btn_save_Click(object sender, EventArgs e)
        {
            TB_AppId.MaxLength = 7;
            TB_ownerID.MaxLength = 9;
            TB_PublicId.MaxLength = 9;
            //Properties.Settings.Default.Upgrade();
            Properties.Settings.Default.Save(); // Saves settings in application configuration file
            TB_ownerID.Text = Properties.Settings.Default["ownerid3"].ToString();
            TB_Token.PasswordChar = '*';
            TB_Token.Text = Properties.Settings.Default["Token"].ToString();
            TB_TokenApp.PasswordChar = '*';
            TB_TokenApp.Text = Properties.Settings.Default["accesstoken"].ToString();
            TB_PublicId.Text = Properties.Settings.Default["groupid"].ToString();
            TB_ftpAddress.Text = Properties.Settings.Default["ftpAddress"].ToString();
            TB_ftpLogin.Text = Properties.Settings.Default["ftpUsername"].ToString();
            TB_ftpPass.PasswordChar = '*';
            TB_ftpPass.Text = Properties.Settings.Default["ftpPassword"].ToString();
            TB_Login.Text = Properties.Settings.Default["Login"].ToString();
            TB_Pass.PasswordChar = '*';
            TB_Pass.Text = Properties.Settings.Default["Password"].ToString();
            TB_AppId.Text = Properties.Settings.Default["AppId"].ToString();
            MessageBox.Show("Настройки сохранены!");
            //Form1 defForm1 = new Form1();      
            this.Close();
        }

        private void TB_Token_TextChanged(object sender, EventArgs e)
        {
            Properties.Settings.Default["Token"] = TB_Token.Text;
            // Properties.Settings.Default.Upgrade();
            this.toolTip1.SetToolTip(label4, "Введите ID приложения и нажмите кнопку Get Token, затем скопируйте из ссылки в браузере все что после &token в поле Token");
        }

        private void TB_TokenApp_TextChanged(object sender, EventArgs e)
        {
            Properties.Settings.Default["accesstoken"] = TB_TokenApp.Text;
            this.toolTip1.SetToolTip(label2, "Из Настроек Вашего приложения скопируйте токен");
            //Properties.Settings.Default.Upgrade();
        }

        private void TB_PublicId_TextChanged(object sender, EventArgs e)
        {
            Properties.Settings.Default["groupid"] = Convert.ToInt64(TB_PublicId.Text);
            Properties.Settings.Default["groupid3"] = Convert.ToUInt64(TB_PublicId.Text);
           // Properties.Settings.Default.Upgrade();
        }

        private void TB_ftpAddress_TextChanged(object sender, EventArgs e)
        {
            Properties.Settings.Default["ftpAddress"] = TB_ftpAddress.Text;
            //  Properties.Settings.Default.Upgrade();
            this.toolTip1.SetToolTip(label5, "Введите прямой путь FTP до файла posted_tracks.dll (создайте его на сервере)");
        }

        private void TB_ftpLogin_TextChanged(object sender, EventArgs e)
        {
            Properties.Settings.Default["ftpUsername"] = TB_ftpLogin.Text;
            // Properties.Settings.Default.Upgrade();
            this.toolTip1.SetToolTip(label6, "Логин от FTP сервера");
        }

        private void TB_ftpPass_TextChanged(object sender, EventArgs e)
        {
            Properties.Settings.Default["ftpPassword"] = TB_ftpPass.Text;
            //Properties.Settings.Default.Upgrade();
        }

        private void TB_Login_TextChanged(object sender, EventArgs e)
        {
            Properties.Settings.Default["Login"] = TB_Login.Text;
            //Properties.Settings.Default.Upgrade();
        }

        private void TB_Pass_TextChanged(object sender, EventArgs e)
        {
            Properties.Settings.Default["Password"] = TB_Pass.Text;
            //Properties.Settings.Default.Upgrade();
        }

        private void BT_GetToken_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Скопируйте из ссылки, все что после &token= в поле Token ");
            //Открыть
            string url1= "https://oauth.vk.com/authorize?client_id=";
            string url2 = "&scope = notify, photos, friends, audio, video, notes, pages, docs, status, questions, offers, wall, groups, messages, notifications, stats, ads, offline&redirect_uri = http://api.vk.com/blank.html&display=page&response_type=token";
            string url = url1 + Properties.Settings.Default["AppId"].ToString() + url2;

            System.Diagnostics.Process.Start(url);

            //Properties.Settings.Default.Save();
            // https://oauth.vk.com/authorize?client_id=6707743&scope=notify,photos,friends,audio,video,notes,pages,docs,status,questions,offers,wall,groups,messages,notifications,stats,ads,offline&redirect_uri=http://api.vk.com/blank.html&display=page&response_type=token
        }

        private void TB_AppId_TextChanged(object sender, EventArgs e)
        {
            Properties.Settings.Default["AppId"] = TB_AppId.Text;
            // Properties.Settings.Default.Upgrade();
            this.toolTip1.SetToolTip(label10, "ID Standalone приложения, создайте Standalone через https://vk.com/dev и из Настроек скопируйте ID");
        }

        private void BT_Reset_Click(object sender, EventArgs e)
        {
            Properties.Settings.Default.Reset();
            TB_ownerID.Text = Properties.Settings.Default["ownerid3"].ToString();
            TB_Token.PasswordChar = '*';
            TB_Token.Text = Properties.Settings.Default["Token"].ToString();
            TB_TokenApp.PasswordChar = '*';
            TB_TokenApp.Text = Properties.Settings.Default["accesstoken"].ToString();
            TB_PublicId.Text = Properties.Settings.Default["groupid"].ToString();
            TB_ftpAddress.Text = Properties.Settings.Default["ftpAddress"].ToString();
            TB_ftpLogin.Text = Properties.Settings.Default["ftpUsername"].ToString();
            TB_ftpPass.PasswordChar = '*';
            TB_ftpPass.Text = Properties.Settings.Default["ftpPassword"].ToString();
            TB_Login.Text = Properties.Settings.Default["Login"].ToString();
            TB_Pass.PasswordChar = '*';
            TB_Pass.Text = Properties.Settings.Default["Password"].ToString();
            TB_AppId.Text = Properties.Settings.Default["AppId"].ToString();
            MessageBox.Show("Настройки сброшены по-умолчанию");
           // this.Close();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            //фильтр правильности ввода
            if (TB_ownerID.Text==null|| TB_Token.Text==null ||
                TB_TokenApp.Text==null || TB_PublicId.Text==null ||
                TB_ftpAddress.Text ==null|| TB_ftpLogin.Text==null ||
                TB_ftpPass.Text==null || TB_Login.Text==null ||
               TB_Pass.Text ==null || TB_AppId.Text ==null)
            {
                valuesSet = false;
                Properties.Settings.Default["Values_set"] = false;
            }
            else
            {
                valuesSet = true;
                Properties.Settings.Default["Values_set"] = true;
            }
            //Properties.Settings.Default["Values_set"] = true;

        }

        private void TB_ownerID_KeyPress(object sender, KeyPressEventArgs e)
        {
            char number = e.KeyChar;

            if (!Char.IsDigit(number) && e.KeyChar != Convert.ToChar(8))
            {
                e.Handled = true;
            }
        }

        private void TB_AppId_KeyPress(object sender, KeyPressEventArgs e)
        {
            char number = e.KeyChar;

            if (!Char.IsDigit(number) && e.KeyChar != Convert.ToChar(8))
            {
                e.Handled = true;
            }
        }

        private void TB_PublicId_KeyPress(object sender, KeyPressEventArgs e)
        {
            char number = e.KeyChar;

            if (!Char.IsDigit(number) && e.KeyChar != Convert.ToChar(8))//&&e.KeyChar!= Convert.ToChar(150) &&e.KeyChar!= Convert.ToChar(45) - это минус
            {
                e.Handled = true;
            }
        }

        private void bt_vkdev_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("https://vk.com/apps?act=manage"); 
        }

        private void LoginForm_Load(object sender, EventArgs e)
        {

        }
    } 
}
