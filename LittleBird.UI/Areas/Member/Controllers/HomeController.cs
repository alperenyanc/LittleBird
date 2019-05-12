using LittleBird.Service.Option;
using LittleBird.UI.Areas.Member.Models.VM;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LittleBird.UI.Areas.Member.Controllers
{
    public class HomeController : Controller
    {
        TweetService _tweetService;
        CommentService _commentService;
        LikeService _likeService;
        public HomeController()
        {
            _tweetService = new TweetService();
            _commentService = new CommentService();
            _likeService = new LikeService();
        }
        public ActionResult Index()
        {
            //TweetDetailVM model = new TweetDetailVM();

            //model.Tweets = _tweetService.GetActive();

            //foreach (var item in model.Tweets)
            //{
            //    model.Comments = _commentService.GetDefault(x => x.TweetID == item.ID).OrderByDescending(x => x.CreatedDate).Take(10).ToList();

            //    model.LikeCount = _likeService.GetDefault(x => x.TweetID == item.ID).Count();
            //    model.CommentCount = _commentService.GetDefault(x => x.TweetID == item.ID).Count();
            //}

            //return View(model);
            ////var model =_articleService.GetActive().OrderByDescending(x => x.CreatedDate).Take(5);
            return View();
        }
    }
}