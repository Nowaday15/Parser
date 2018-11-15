using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace vkaudioposter
{
    class Track
    {
        //public string Artist { get; set; }
        private string Title;
        //private string FullId;//1235467_1234567
        private long OwnerId; //1231467
        private long MediaId; //_21313414

        public Track()
        {
            Title = null;
            OwnerId = 0;
            MediaId = 0;
            return;
        }

        public Track(Track toCopy)
        {
            this.Title = toCopy.Title;
            this.OwnerId = toCopy.OwnerId;
            this.MediaId = toCopy.MediaId;
            return;
        }

        public Track(string CurrentTitle, string CurrentFullId)
        {
            SetTitle(CurrentTitle);
            SetFullId(CurrentFullId);
            return;
        }

        public Track(string CurrentTitle, long CurrentMediaId, long CurrentOwnerId)
        {
            SetTitle(CurrentTitle);
            SetMediaId(CurrentMediaId);
            SetOwnerId(CurrentOwnerId);
            return;
        }

        ~Track()
        {

        }

        public void SetTrack(string CurrentTitle, string CurrentFullId)
        {
            SetTitle(CurrentTitle);
            SetFullId(CurrentFullId);
            return;
        }

        public void SetTitle(string CurrentTitle)
        {
            Title = CurrentTitle.Replace("%20", " ");
            //Title = CurrentTitle;

            return;
        }
        public void SetFullId(string CurrentFullId)
        {
            // FullId = subs2;

            int ind3 = CurrentFullId.IndexOf("_"); // Нашли символ "_"
            string temp_string = CurrentFullId.Substring(0, ind3);//отделили все что до него (то есть айди юзера)
            //OwnerId = Convert.ToInt64(temp_string); // owner id
            SetOwnerId(temp_string);

            int dlina = CurrentFullId.Length - 1; //индекс последнего символа
            temp_string = CurrentFullId.Remove(0, ind3 + 1);//отделили все что после "_"
            //MediaId = Convert.ToInt64(temp_string); // media id
            SetMediaId(temp_string);
            //Title = CurrentTitle;
            return;
        }
        public void SetOwnerId(long CurrentOwnerId)
        {
            OwnerId = CurrentOwnerId;
            return;
        }

        public void SetMediaId(long CurrentMediaId)
        {
            MediaId = CurrentMediaId;
            return;
        }

        public void SetOwnerId(string CurrentOwnerId)
        {
            SetOwnerId(Convert.ToInt64(CurrentOwnerId));
            return;
        }

        public void SetMediaId(string CurrentMediaId)
        {
            SetMediaId(Convert.ToInt64(CurrentMediaId));
            return;
        }

        public string GetTitle()
        {
            return Title;
        }

         public string GetFullId()
        {
           string FullId = OwnerId + "_" + MediaId;
           return FullId;
        }

        public long GetOwnerId()
        {
            return OwnerId;
        }
        public long GetMediaId()
        {
            return MediaId;
        }

    }
}
