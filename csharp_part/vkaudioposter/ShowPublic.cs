using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace vkaudioposter
{
    public partial class ShowPublic : Form
    {
        public ShowPublic()
        {
            InitializeComponent();
        }


        private void ShowPublic_Load(object sender, EventArgs e)
        {
            string browser = string.Empty;
            RegistryKey key = null;
            try
            {
                key = Registry.ClassesRoot.OpenSubKey(@"HTTP\shell\open\command");
                if (key != null)
                {
                    // Get default Browser
                    browser = key.GetValue(null).ToString().ToLower().Trim(new[] { '"' });
                }
                if (!browser.EndsWith("exe"))
                {
                    //Remove all after the ".exe"
                    browser = browser.Substring(0, browser.LastIndexOf(".exe", StringComparison.InvariantCultureIgnoreCase) + 4);
                }
            }
            finally
            {
                if (key != null)
                {
                    key.Close();
                }
            }
            // Open the browser.
            Process proc = Process.Start(browser, "https://vk.com/wall-31640582?postponed=1");
            if (proc != null)
            {
                Thread.Sleep(5000);
                // Close the browser.
               // proc.Kill();
            }
        }
    }
}
