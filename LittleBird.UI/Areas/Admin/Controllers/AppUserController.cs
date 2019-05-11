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
    public class AppUserController : Controller
    {
        AppUserService _appUserService;
        public AppUserController()
        {
            _appUserService = new AppUserService();
        }

        public ActionResult Add()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Add(AppUser data, HttpPostedFileBase Image)//httppostfilebase:Server'a atılacak olan resmi barındıracak olan property-resim yükleme yolu
        {
            List<string> UploadedImagePaths = new List<string>();

            UploadedImagePaths = ImageUploader.UploadSingleImage(ImageUploader.OriginalProfileImagePath, Image, 1);

            data.UserImage = UploadedImagePaths[0];

            if (data.UserImage == "0" || data.UserImage == "1" || data.UserImage == "2")
            {
                data.UserImage = ImageUploader.DefaultProfileImagePath;
                data.XSmallUserImage = ImageUploader.DefaultXSmallProfileImage;
                data.CruptedUserImage = ImageUploader.DefaulCruptedProfileImage;
            }
            else
            {
                data.XSmallUserImage = UploadedImagePaths[1];
                data.CruptedUserImage = UploadedImagePaths[2];
            }

            data.Status = Core.Enum.Status.Active;

            _appUserService.Add(data);

            return Redirect("/Admin/AppUser/List");
        }
        public ActionResult Update(Guid id)
        {
            AppUser appuser = _appUserService.GetByID(id);
            AppUserDTO model = new AppUserDTO();
            model.ID = appuser.ID;//
            model.FirstName = appuser.FirstName;
            model.LastName = appuser.LastName;
            model.UserName = appuser.UserName;
            model.Password = appuser.Password;
            model.Bio = appuser.Bio;
            model.Email = appuser.Email;
            model.followers = appuser.followers;
            model.following = appuser.following;
            model.UserImage = appuser.UserImage;
            model.Birthdate = appuser.Birthdate;
            model.PhoneNumber = appuser.PhoneNumber;
            model.Role = appuser.Role;
            
            model.XSmallUserImage = appuser.XSmallUserImage;
            model.CruptedUserImage = appuser.CruptedUserImage;
            return View(model);

        }
        [HttpPost]
        public ActionResult Update(AppUserDTO data, HttpPostedFileBase Image)
        {
            List<string> UploadedImagePaths = new List<string>();

            UploadedImagePaths = ImageUploader.UploadSingleImage(ImageUploader.OriginalProfileImagePath, Image, 1);

            data.UserImage = UploadedImagePaths[0];
            
            AppUser appuser = _appUserService.GetByID(data.ID);

            if (data.UserImage == "0" || data.UserImage == "1" || data.UserImage == "2")
            {
                if (appuser.UserImage == null || appuser.UserImage == ImageUploader.DefaultProfileImagePath)
                {
                    appuser.UserImage = ImageUploader.DefaultProfileImagePath;
                    appuser.XSmallUserImage = ImageUploader.DefaultXSmallProfileImage;
                    appuser.CruptedUserImage = ImageUploader.DefaulCruptedProfileImage;
                }
                else
                {
                    appuser.UserImage = appuser.UserImage;
                    appuser.XSmallUserImage = appuser.XSmallUserImage;
                    appuser.CruptedUserImage = appuser.CruptedUserImage;
                }
            }
            else
            {
                appuser.UserImage = UploadedImagePaths[0];//
                appuser.XSmallUserImage = UploadedImagePaths[1];
                appuser.CruptedUserImage = UploadedImagePaths[2];
            }
            appuser.FirstName = data.FirstName;
            appuser.LastName = data.LastName;
            appuser.UserName = data.UserName;
            appuser.Password = data.Password;
            appuser.Email = data.Email;
            appuser.followers = data.followers;
            appuser.following = data.following;
            appuser.Role = data.Role;
            appuser.PhoneNumber = data.PhoneNumber;
            appuser.Bio = data.Bio;
            appuser.Birthdate = data.Birthdate;

            _appUserService.Update(appuser);

            return Redirect("/Admin/AppUser/List");

        

        }
        public ActionResult List()
        {
            List<AppUser> model = _appUserService.GetActive();
            return View(model);
        }
        public RedirectResult Delete(Guid id)
        {
            _appUserService.Remove(id);
            return Redirect("/Admin/AppUser/List");
        }
    }
}