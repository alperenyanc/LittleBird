using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LittleBird.UI.Areas.Member.Models.DTO
{
    public class AddTweetDTO
    {
        public Guid ID{ get; set; }
        public string TweetContent { get; set; }
        public string ImagePath { get; set; }
        public DateTime? PublishDate { get; set; }

        public Guid AppUserID { get; set; }
    }
}