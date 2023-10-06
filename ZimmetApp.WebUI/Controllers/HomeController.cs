using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ZimmetApp.DataAccess.EntityFramework;
using ZimmetApp.Entities.Models;

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

        public ActionResult Arama(FormCollection form)
        {
            var aramaDegeri = form["AramaDegeri"].ToString();

            using (var db = new ZimmetDbContext())
            {
                var musteriAdi = aramaDegeri.ToUpper();

                var dbMusteri = db.Musteris
                        .FirstOrDefault(x => !x.IsDeleted && x.MusteriAdi.Contains(musteriAdi));

                if (dbMusteri != null)
                {
                    return RedirectToAction("Listele", "Zimmet", new { musteri_id = dbMusteri.Id });
                }
                else
                {
                    TempData["NO"] = "Müşteri Bilgisi Bulunamadı!";
                    return RedirectToAction("Index");
                }
            }
        }
    }
}