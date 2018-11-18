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
    public partial class SplashScreen : Form
    {
        private int timeLeft;

        public SplashScreen()
        {
            InitializeComponent();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            //if(timeLeft>0)
            //{
            //    timeLeft = timeLeft - 1;
            //}
            //else
            //{
            //    timer1.Start();
            //    new Form1().Show();
            //    this.Hide();
            //}\     //after 3 sec stop the timer

            timer1.Stop();

            //display mainform

            Form1 mf = new Form1();

            mf.Show();

            //hide this form

            this.Hide();
        }

        private void SplashScreen_Load(object sender, EventArgs e)
        {
            //timeLeft = 10;
            //timer1.Start();
        }

        private void SplashScreen_Shown(object sender, EventArgs e)
        {
            timer1 = new Timer();

            //set time interval 3 sec

            timer1.Interval = 3000;

            //starts the timer

            timer1.Start();

            timer1.Tick += timer1_Tick;
        }
    }
}
