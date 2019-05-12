using LittleBird.Model.Option;
using LittleBird.UI.Areas.Admin.Models.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LittleBird.UI.Areas.Admin.Models.VM
{
    public class UpdateTweetVM

    {
        public UpdateTweetVM()
        {
          
            AppUsers = new List<AppUser>();
            Tweet = new TweetDTO();
        }
       
        public List<AppUser> AppUsers { get; set; }
        public TweetDTO Tweet { get; set; }
    }
}