using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using VkNet;
using VkNet.Model;
using VkNet.Model.RequestParams;

namespace vkaudioposter
{
    public partial class Reposter : Form
    {
        string Login = Properties.Settings.Default["Login"].ToString();
        string Password = Properties.Settings.Default["Password"].ToString();

        //string Token = "57da846be4093a126adc01a970a971b2fd699fca108fda53090dd41a180385988775854c6b0da7c88d602";
        string Token = Properties.Settings.Default["Token"].ToString();
        ulong n = 9;
        long? overalreposts=20; //от 20-500 добавить потом
        long? offset = 0; //0-смещение добавить потом слайдер или ввод 
        long? ownid = -(long?)Properties.Settings.Default["groupid"];

        public Reposter()
        {

            //Properties.Settings.Default["Token"] = "Some Value";
            InitializeComponent();

            for (ulong i=1; i<=n+1; i++)
            dUD_PostCount.Items.Add(i);
            // dUD_PostCount.SelectedItem = 1;
            TB_Phone.Text = Login;
            TB_Id.Text = ownid.ToString();
            TB_Pass.PasswordChar = '*';
            TB_Pass.Text = Password;
            //pB_reposting.Step = (int)n+1;
           // TB_count.Maximum = (int)n+1;
            TB_count.Minimum = 1;
            TB_Id.MaxLength = 12;

            //lb_Count.Text = TB_count.Value.ToString();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            pB_reposting.Value = 0;
            var api = new VkApi();
            //api.Wall.Get(skipAuthorization=false);
            //Авторизация
            api.Authorize(new ApiAuthParams
            {
                Login = Login,
                Password = Password,
                AccessToken = Token
            });
            //Console.WriteLine(api.UserId);
            //Console.ReadLine();
            var get = api.Wall.Get(new WallGetParams
            {
                OwnerId = ownid,
                Count = n,
                // CaptchaKey=,
                //  CaptchaSid=,
            });

            //get.TotalCount
            //Check if reposted by me?
            int i = 0;
            while (i < (int)n)//пока число постов меньше заданного
            {
                string obj = "wall" + get.WallPosts[i].OwnerId.ToString() + "_" + get.WallPosts[i].Id.ToString();
                //long? obj2 = "wall" + get.WallPosts[i].OwnerId + "_" + get.WallPosts[i].Id;
                //var reposts = api.Wall.GetReposts(-31640582, get.WallPosts[i].Id,null,null,true); //Получаем 20 репостов i-ой записи
                //var profiles = reposts.Profiles;
                //for (int j = 0; j <= profiles.Count; j++)//первые 20 репостеров
                //{
                    //if (profiles[j].FirstName != "High" && profiles[j].LastName != "Volume") //если там нет
                    //{
                        try
                        {
                            var repost = api.Wall.Repost(@obj, null, null, false);//captcha
                            i++; //идем дальше
                         pB_reposting.PerformStep();
                            //continue;
                        }
                        catch (Exception)
                        {
                            //var repost = api.Wall.Repost(@obj, null, null, false);//captcha
                            MessageBox.Show("Ошибка репоста!");
                            break;
                        }
                   // }
                    //else 
                //}
                
            }
            MessageBox.Show("Готово!\nСделано репостов: "+n+" свежих записей.");
        }

        private void dUD_PostCount_SelectedItemChanged(object sender, EventArgs e)
        {

        }

        private void TB_Id_TextChanged(object sender, EventArgs e)
        {

            ownid = Convert.ToInt64(TB_Id.Text);
            Properties.Settings.Default["ownid"] = ownid;
            Properties.Settings.Default.Save();
        }

        private void TB_Phone_TextChanged(object sender, EventArgs e)
        {
            Login = TB_Phone.Text;
        }

        private void TB_count_Scroll(object sender, EventArgs e)
        {
            n = Convert.ToUInt64(TB_count.Value);
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            //TB_count.Value
            // pB_reposting.Step = (int)n + 1;
            n = Convert.ToUInt64(TB_count.Value);
            //TB_count.Maximum = (int)n + 1;
            lb_Count.Text = TB_count.Value.ToString();
        }

        private void TB_Id_KeyPress(object sender, KeyPressEventArgs e)
        {
            char number = e.KeyChar;

            if (!Char.IsDigit(number) && e.KeyChar != Convert.ToChar(8))
            {
                e.Handled = true;
            }
        }

        private void Reposter_Load(object sender, EventArgs e)
        {

        }
    }
}
