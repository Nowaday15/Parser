using Microsoft.Scripting.Utils;
using NuGet;
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
using VkNet.Model.Attachments;
using VkNet.Model.RequestParams;

namespace vkaudioposter
{
    public partial class PostPoned : Form
    {
        string Token = Properties.Settings.Default["Token"].ToString();
        long ownid = -(long)Properties.Settings.Default["groupid"];
        public PostPoned()
        {
            InitializeComponent();
        }

        private void PostPoned_Load(object sender, EventArgs e)
        {
            var _api = new VkApi();

            _api.Authorize(new ApiAuthParams
            {
                AccessToken = Token
            });

            VkNet.Enums.SafetyEnums.WallFilter postponed = VkNet.Enums.SafetyEnums.WallFilter.Postponed;
            VkNet.Enums.SafetyEnums.WallFilter sugg = VkNet.Enums.SafetyEnums.WallFilter.Suggests;
            //VkNet.Model.Attachments track = Audio;
            var get = _api.Wall.Get(new WallGetParams
            {
                OwnerId = ownid,
                Count=25,
                Filter=postponed
            });

            foreach(var i in get.WallPosts)
            {
                foreach (var j in i.Attachments)
                {
                   // if (j.Type == typeof(MediaAttachment))
                        //attachments.AddRange(j);
                   // lstV_Posts.Items.Add();
                }
                
            }

        }
    }
}
