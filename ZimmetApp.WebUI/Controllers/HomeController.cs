using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ZimmetApp.DataAccess.EntityFramework;

namespace ZimmetApp.WebUI.Controllers
{
    public class HomeController : BaseController
    {
        public ActionResult Index()
        {
            #region SessionControl
            //if (Session["User"] == null)
            //{
            //    return RedirectToAction("In", "Sign");
            //}
            //else
            //{
            //    return View();
            //}
            #endregion

            #region DB-Olusması-İcin
            //using(var db = new ZimmetDbContext())
            //{
            //    var userlist = db.Users.ToList();
            //}
            #endregion

            return View();
        }
    }
}