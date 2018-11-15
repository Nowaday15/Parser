using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace vkaudioposter
{
    class JsonSearch
    {
        public class Rootobject
        {
            public object[][] list { get; set; }
            public bool hasMore { get; set; }
            public int nextOffset { get; set; }
            public int totalCount { get; set; }
            public int AUDIO_ITEM_INDEX_AUTHOR_ID { get; set; }
        }

    }
}
