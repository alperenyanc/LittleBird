using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LittleBird.UI.Areas.Member.Controllers
{
    public class CommentController : Controller
    {
        // GET: Member/Comment
        public ActionResult Index()
        {
            return View();
        }
    }
}