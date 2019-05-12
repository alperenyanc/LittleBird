using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LittleBird.UI.Areas.Admin.Models.DTO
{
    public class TweetDTO
    {
        public Guid ID { get; set; }
        public string TweetContent { get; set; }
        public string ImagePath { get; set; }
        public DateTime? PublishDate { get; set; }

        public Guid AppUserID { get; set; }

    }
}