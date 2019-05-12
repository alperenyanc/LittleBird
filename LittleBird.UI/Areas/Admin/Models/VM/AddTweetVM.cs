using LittleBird.Model.Option;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LittleBird.UI.Areas.Admin.Models.VM
{
    public class AddTweetVM
    {
        public AddTweetVM()
        {
            AppUsers = new List<AppUser>();
        }
        public List<AppUser> AppUsers { get; set; }
    }
}