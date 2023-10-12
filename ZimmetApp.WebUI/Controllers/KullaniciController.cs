using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ZimmetApp.DataAccess.EntityFramework;
using ZimmetApp.Entities.Helper;
using ZimmetApp.Entities.Models;
using ZimmetApp.WebUI.Filters;
using ZimmetApp.WebUI.Models.ViewModels;

namespace ZimmetApp.WebUI.Controllers
{
    [AuthAdmin]
    public class KullaniciController : BaseController
    {
        #region Admin-Kontrolu
        //protected override void OnAuthorization(AuthorizationContext filterContext)
        //{
        //    if (Session["User"] != null)
        //    {
        //        var kullanici = Session["User"] as User;

        //        if (!kullanici.IsAdmin)
        //        {
        //            filterContext.Result = new RedirectResult(Url.Action("Index", "Home"));
        //        }
        //    }
        //    else
        //    {
        //        filterContext.Result = new RedirectResult(Url.Action("In", "Sign"));
        //    }
        //}
        #endregion

        public ActionResult Listele()
        {
            using (var db = new ZimmetDbContext())
            {
                var kullanicilar = db.Users
                    .Where(x => !x.IsDeleted)
                    .ToList();

                return View(kullanicilar);
            }

            #region Ornek
            //var kullaniciliar = new List<User>();

            //using (var db = new ZimmetDbContext())
            //{
            //    kullaniciliar = db.Users
            //        .Where(x => !x.IsDeleted)
            //        .ToList();
            //}

            //return View(kullaniciliar);
            #endregion
        }

        public ActionResult Ekle(Guid? userId)
        {
            if (userId == null)
            {
                return View();
            }
            else
            {
                using (var db = new ZimmetDbContext())
                {
                    var kullanici = db.Users.FirstOrDefault(x => x.Id == userId);
                    return View(kullanici);
                }
            }
        }

        [HttpPost]
        public ActionResult Ekle(User kullanici)
        {
            using (var db = new ZimmetDbContext())
            {
                // DB'de kullanıcı kayıtlı mı diye kontrol ediliyor.
                var dbUser = db.Users.FirstOrDefault(x => x.Id == kullanici.Id);

                //var control = db.Musteris.FirstOrDefault(x => x.MusteriKod == musteri.MusteriKod && !x.IsDeleted);

                if (dbUser == null) // İLK KAYIT
                {
                    // USerCode Kontrolü
                    var control = db.Users.FirstOrDefault(x => x.UserCode == kullanici.UserCode && !x.IsDeleted);

                    if (control == null)
                    {
                        var pw = kullanici.UserPassword != null ? kullanici.UserPassword.Trim() : null;
                        if (pw != null && pw != "")
                        {
                            kullanici.UserPassword = PasswordHash.MD5(pw);
                        }

                        db.Users.Add(kullanici);
                        db.SaveChanges();

                        TempData["OK"] = "Kullanıcı Eklendi!";
                        return RedirectToAction("Listele");
                    }
                    else
                    {
                        TempData["NO"] = "Kullanıcı Kodu Kullanılıyor!";
                        return RedirectToAction("Ekle");
                    }
                }
                else // GÜNCELLEME
                {
                    dbUser.FirstName = kullanici.FirstName;
                    dbUser.LastName = kullanici.LastName;
                    dbUser.Email = kullanici.Email;
                    dbUser.IsAdmin = kullanici.IsAdmin;

                    var pw = kullanici.UserPassword != null ? kullanici.UserPassword.Trim() : null;
                    if (pw != null && pw != "")
                    {
                        dbUser.UserPassword = PasswordHash.MD5(pw);
                    }

                    dbUser.UpdatedAt = DateTime.Now;

                    TempData["OK"] = "Kullanıcı Güncellendi!";

                    db.SaveChanges();
                    return RedirectToAction("Listele");
                }
            }
        }

        public ActionResult Sil(Guid id)
        {
            using (var db = new ZimmetDbContext())
            {
                var kullanici = db.Users.FirstOrDefault(x => x.Id == id);

                kullanici.UpdatedAt = DateTime.Now;
                kullanici.IsDeleted = true;

                //db.Users.Remove(kullanici);

                db.SaveChanges();

                TempData["OK"] = "Kullanıcı Silindi!";

                return RedirectToAction("Listele");
            }
        }
    }
}