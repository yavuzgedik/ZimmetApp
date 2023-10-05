using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ZimmetApp.DataAccess.EntityFramework;
using ZimmetApp.Entities.Models;

namespace ZimmetApp.WebUI.Controllers
{
    public class MusteriController : BaseController
    {
        public ActionResult Listele()
        {
            using (var db = new ZimmetDbContext())
            {
                var musteriler = db.Musteris
                    .Include("ZimmetTanims")
                    //.Where(x => x.IsDeleted == false)
                    .Where(x => !x.IsDeleted)
                    .ToList();

                return View(musteriler);
            }
        }

        public ActionResult Ekle()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Ekle(Musteri musteri)
        {
            using (var db = new ZimmetDbContext())
            {
                musteri.MusteriAdi = musteri.MusteriAdi.ToUpper();
                db.Musteris.Add(musteri);
                db.SaveChanges();
            }

            TempData["OK"] = "Müşteri Eklendi!";

            return RedirectToAction("Listele");
        }

        public ActionResult Sil(Guid id)
        {
            using (var db = new ZimmetDbContext())
            {
                var musteri = db.Musteris
                    .FirstOrDefault(x=> x.Id == id);
                //db.Musteris.Remove(musteri); //SİL

                musteri.IsDeleted = true;

                db.SaveChanges();

                TempData["OK"] = "Müşteri Silindi!";

                return RedirectToAction("Listele");
            }
        }
    }
}