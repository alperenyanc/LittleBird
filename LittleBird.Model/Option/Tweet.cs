using LittleBird.Core.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LittleBird.Model.Option
{
    public class Tweet : CoreEntity
    {
        public string TweetContent { get; set; }
        public string ImagePath { get; set; }
        public DateTime? PublishDate { get; set; }

        public Guid AppUserID { get; set; }
        public virtual AppUser AppUser { get; set; }



        public virtual List<Comment> Comments { get; set; }
        public virtual List<Like> Likes { get; set; }
    }
}
