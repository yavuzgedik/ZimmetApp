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
                    .OrderBy(x => x.MusteriKod)
                    .ToList();

                return View(musteriler);
            }
        }

        public ActionResult Ekle(Guid? musteri_id)
        {
            if (musteri_id == null)
            {
                return View();
            }
            else
            {
                using (var db = new ZimmetDbContext())
                {
                    var musteri = db.Musteris.FirstOrDefault(x => x.Id == musteri_id);
                    return View(musteri);
                }
            }
        }

        [HttpPost]
        public ActionResult Ekle(Musteri musteri)
        {
            using (var db = new ZimmetDbContext())
            {
                var dbMusteri = db.Musteris.FirstOrDefault(x => x.Id == musteri.Id);
                var control = db.Musteris.FirstOrDefault(x => x.MusteriKod == musteri.MusteriKod && !x.IsDeleted);

                if (dbMusteri == null) // İLK KAYIT
                {
                    if (control == null)
                    {
                        musteri.MusteriAdi = musteri.MusteriAdi.ToUpper();
                        db.Musteris.Add(musteri);
                        db.SaveChanges();

                        TempData["OK"] = "Müşteri Eklendi!";
                        return RedirectToAction("Listele");
                    }
                    else
                    {
                        TempData["NO"] = "Müşteri Kodu Kullanıyor!";
                        return View();
                    }
                }
                else // GÜNCELLEME
                {
                    dbMusteri.MusteriAdi = musteri.MusteriAdi.ToUpper();

                    if (control == null)
                    {
                        dbMusteri.MusteriKod = musteri.MusteriKod;

                        TempData["OK"] = "Müşteri Güncellendi!";
                    }
                    else
                    {
                        if (control.MusteriKod != dbMusteri.MusteriKod)
                        {
                            TempData["NO"] = "Müşteri Kodu Kullanıyor! Müşteri Güncelledi";
                        }
                        else
                        {
                            TempData["OK"] = "Müşteri Güncellendi!";
                        }
                    }

                    db.SaveChanges();
                    return RedirectToAction("Listele");
                }
            }
        }

        public ActionResult Sil(Guid id)
        {
            using (var db = new ZimmetDbContext())
            {
                var musteri = db.Musteris
                    .FirstOrDefault(x => x.Id == id);
                //db.Musteris.Remove(musteri); //SİL

                musteri.IsDeleted = true;

                db.SaveChanges();

                TempData["OK"] = "Müşteri Silindi!";

                return RedirectToAction("Listele");
            }
        }
    }
}