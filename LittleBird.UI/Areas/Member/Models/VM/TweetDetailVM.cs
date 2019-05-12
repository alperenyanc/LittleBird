using LittleBird.Model.Option;
using LittleBird.Service.Option;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LittleBird.UI.Areas.Member.Models.VM
{
    public class TweetDetailVM
    {
        public TweetDetailVM()
        {
            AppUsers = new List<AppUser>();
            Comments = new List<Comment>();
            Likes = new List<Like>();
            Tweets = new List<Tweet>();

            Like = new Like();
            Tweet = new Tweet();
            AppUser = new AppUser();
            Comment = new Comment();
        }
        //public int LikeCount { get; set; }
        //public int CommentCount { get; set; }

        public List<Comment> Comments {get; set;}
        public List<Like> Likes { get; set; }
        public List<AppUser> AppUsers { get; set; }
        public List<Tweet> Tweets { get; set; }

        public Like Like { get; set; }
        public Comment Comment { get; set; }
        public AppUser AppUser { get; set; }
        public Tweet Tweet { get; set; }

       

    }
}