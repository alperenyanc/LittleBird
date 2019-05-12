using LittleBird.UI.Areas.Member.Models.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LittleBird.UI.Areas.Member.Models.VM
{
    public class UpdateTweetVM
    {
        public UpdateTweetVM()
        {
            Tweet = new AddTweetDTO();
        }
        public AddTweetDTO Tweet { get; set; }
    }
}