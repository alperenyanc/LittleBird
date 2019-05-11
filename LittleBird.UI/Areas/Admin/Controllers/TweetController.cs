using LittleBird.Model.Option;
using LittleBird.Service.Option;
using LittleBird.UI.Areas.Admin.Models.DTO;
using LittleBird.Utility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LittleBird.UI.Areas.Admin.Controllers
{
    public class TweetController : Controller
    {
        TweetService _tweetService;
        AppUserService _appUserService;
        CommentService _commentService;
        
        public TweetController()
        {
            _tweetService = new TweetService();
            _appUserService = new AppUserService();
            _commentService = new CommentService();
        }
        public ActionResult Add()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Add(Tweet data, HttpPostedFileBase Image)
        {
            List<string> UploadedImagePaths = new List<string>();

            UploadedImagePaths = ImageUploader.UploadSingleImage(ImageUploader.OriginalProfileImagePath, Image, 1);

            data.ImagePath = UploadedImagePaths[0];

            if (data.ImagePath == "0" || data.ImagePath == "1" || data.ImagePath == "2")
            {
                data.ImagePath = ImageUploader.DefaultProfileImagePath;
                data.ImagePath = ImageUploader.DefaultXSmallProfileImage;
                data.ImagePath = ImageUploader.DefaulCruptedProfileImage;
            }
            else
            {
                data.ImagePath = UploadedImagePaths[1];
                data.ImagePath = UploadedImagePaths[2];
            }

            data.Status = Core.Enum.Status.Active;
            data.PublishDate = DateTime.Now;
            _tweetService.Add(data);
            return Redirect("/Admin/Tweet/List");
        }

        public ActionResult List()
        {
            List<Tweet> model = _tweetService.GetActive();
            return Redirect("/Admin/Tweet/List");
        }
        public ActionResult Update(Guid id)
        {
            Tweet tweet = _tweetService.GetByID(id);
            TweetDTO model = new TweetDTO();
            model.id = tweet.ID;
            model.ImagePath = tweet.ImagePath;
            model.TweetContent = tweet.TweetContent;
            model.PublishDate = DateTime.Now;
            return View(model);
        }
        [HttpPost]
        public ActionResult Update(Tweet data, HttpPostedFileBase Image)
        {

            List<string> UploadedImagePaths = new List<string>();

            UploadedImagePaths = ImageUploader.UploadSingleImage(ImageUploader.OriginalProfileImagePath, Image, 1);

            data.ImagePath = UploadedImagePaths[0];

            Tweet update = _tweetService.GetByID(data.ID);

            if (data.ImagePath == "0" || data.ImagePath == "1" || data.ImagePath == "2")
            {

                if (update.ImagePath == null || update.ImagePath == ImageUploader.DefaultProfileImagePath)
                {
                    update.ImagePath = ImageUploader.DefaultProfileImagePath;
                    
                    update.ImagePath = ImageUploader.DefaultXSmallProfileImage;
                    update.ImagePath = ImageUploader.DefaulCruptedProfileImage;
                }
                else
                {
                    update.ImagePath = update.ImagePath;
                }

            }
            else
            {
                update.ImagePath = UploadedImagePaths[0];
                update.ImagePath = UploadedImagePaths[1];
                update.ImagePath = UploadedImagePaths[2];
            }

            update.PublishDate = data.PublishDate;
            update.TweetContent = data.TweetContent;
            update.AppUserID = data.AppUserID;
            update.Status = Core.Enum.Status.Updated;
            _tweetService.Update(update);

            return Redirect("/Admin/Tweet/List");


        }
        public RedirectResult Delete(Guid id)
        {
            _tweetService.Remove(id);
            return Redirect("/Admin/Tweet/List");
        }

    }
}