using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Beamin_Control.WebSite.Boss_Notice
{


    // Root myDeserializedClass = JsonConvert.DeserializeObject<Root>(myJsonResponse);
    public class Notice
    {
        public long id { get; set; }
        public string contents { get; set; }
        public List<Image> images { get; set; }
        public DateTime createdAt { get; set; }
        public string displayStatus { get; set; }
        public string blockType { get; set; }
        public string blockMessage { get; set; }
    }

    public class Image
    {
        public long id { get; set; }
        public string imageUrl { get; set; }
        public int sequence { get; set; }
        public string displayStatus { get; set; }
        public string blockMessage { get; set; }
    }

    public class Boss_Notice_Response
    {
        public bool next { get; set; }
        public List<Notice> notices { get; set; }
        public List<Notice> announcements { get; set; }


        public string errorType { get; set; }
        public string errorMessage { get; set; }
    }




    public class Announcement
    {
        public long id { get; set; }
        public string contents { get; set; }
        public List<object> images { get; set; }
        public DateTime createdAt { get; set; }
        public string displayStatus { get; set; }
        public string blockType { get; set; }
        public string blockMessage { get; set; }
    }

    //public class Word_From_Boss_Response
    //{
    //    public bool next { get; set; }
    //    public string errorType { get; set; }
    //    public string errorMessage { get; set; }
    //    public List<Announcement> announcements { get; set; }
    //}
}
