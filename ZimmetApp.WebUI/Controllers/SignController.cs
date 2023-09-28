using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ZimmetApp.DataAccess.EntityFramework;

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
                var user = db.Users.FirstOrDefault(x => x.UserCode == userCode && x.UserPassword == userPass);

                if (user != null)
                {
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
            Session.Abandon();
            return RedirectToAction("In", "Sign");
        }
    }
}