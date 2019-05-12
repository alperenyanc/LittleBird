using LittleBird.Model.Option;
using LittleBird.Service.Option;
using LittleBird.UI.Areas.Member.Models.VM;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LittleBird.UI.Areas.Member.Controllers
{
    public class LikeController : Controller
    {

        AppUserService _appUserService;
        LikeService _likeService;
        CommentService _commentService;
        public LikeController()
        {
            _appUserService = new AppUserService();
            _likeService = new LikeService();
            _commentService = new CommentService();
        }
        public JsonResult AddLike(Guid id)
        {
            JsonCommentLikeVM jr = new JsonCommentLikeVM();
            Guid appuserID = _appUserService.FindByUserName(HttpContext.User.Identity.Name).ID;

            if (!(_likeService.Any(x => x.AppUserID == appuserID && x.TweetID == id)))
            {
                Like like = new Like();
                like.TweetID = id;
                like.AppUserID = appuserID;
                _likeService.Add(like);

                //Kullanıcıya gönderilecek mesaj oluşturulur.

                jr.Likes = _likeService.GetDefault(x => x.TweetID == id).Count();
                jr.userMessage = "likes it";
                jr.isSuccess = true;
                jr.Likes = _likeService.GetDefault(x => x.TweetID == id && (x.Status == Core.Enum.Status.Active || x.Status == Core.Enum.Status.Updated)).Count();
                jr.Comments = _commentService.GetDefault(x => x.TweetID == id && (x.Status == Core.Enum.Status.Active || x.Status == Core.Enum.Status.Updated)).Count();
                return Json(jr, JsonRequestBehavior.AllowGet);
            }
            else
            {
                jr.isSuccess = false;
                jr.userMessage = "You've liked this article before!";

                return Json(jr, JsonRequestBehavior.AllowGet);
            }
        }
    }
}