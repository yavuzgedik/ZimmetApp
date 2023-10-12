using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using ZimmetApp.DataAccess.EntityFramework;
using ZimmetApp.Entities.Helper;
using ZimmetApp.Entities.Models;
using ZimmetApp.WebUI.Operations;

namespace ZimmetApp.WebUI.Controllers
{
    public class SignController : Controller
    {
        public ActionResult In()
        {
            return View();
        }

        [HttpPost]
        public ActionResult In(FormCollection form)
        {
            var userCode = form["UserCode"].ToString();
            var userPass = form["UserPassword"].ToString();


            #region ILK-VERIYON
            //if (userCode == "1" && userPass == "1")
            //{
            //    Session["User"] = userCode;
            //    return RedirectToAction("Index", "Home");
            //}
            //else
            //{
            //    TempData["Error"] = "Kullanıcı Bilgileri Hatalı!";
            //    return View();
            //}
            #endregion

            //Db Control

            using (var db = new ZimmetDbContext())
            {
                var hashPass = PasswordHash.MD5(userPass);
                var user = db.Users.FirstOrDefault(x => x.UserCode == userCode && x.UserPassword == hashPass && !x.IsDeleted);

                if (user != null)
                {
                    LogOP.LogOlusturma(user, LogDetay.SignIn, Entities.Enums.LogTip.SignIn);

                    #region Cookie

                    //HttpCookie ck;
                    //FormsAuthenticationTicket ticket = new FormsAuthenticationTicket(1, user.UserCode, DateTime.Now, DateTime.Now.AddDays(1), true, user.UserCode);

                    //string encTicket = FormsAuthentication.Encrypt(ticket);

                    //ck = new HttpCookie(FormsAuthentication.FormsCookieName, encTicket);
                    //ck.Expires = DateTime.Now.AddDays(1);
                    //ck.Path = FormsAuthentication.FormsCookiePath;
                    //Response.Cookies.Add(ck);

                    #endregion

                    Session["User"] = user;
                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    TempData["Error"] = "Kullanıcı Bilgileri Hatalı!";
                    return View();
                }
            }
        }

        public ActionResult Out()
        {
            var user = Session["User"] as User;
            LogOP.LogOlusturma(user, LogDetay.SignIn, Entities.Enums.LogTip.SignIn);
            Session.Abandon();
            return RedirectToAction("In", "Sign");
        }
    }
}