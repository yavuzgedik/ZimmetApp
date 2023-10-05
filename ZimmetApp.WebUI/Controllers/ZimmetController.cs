using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ZimmetApp.DataAccess.EntityFramework;
using ZimmetApp.Entities.Models;

namespace ZimmetApp.WebUI.Controllers
{
    public class ZimmetController : Controller
    {
        public ActionResult Listele()
        {
            using (var db = new ZimmetDbContext())
            {
                var zimmetler = db.ZimmetTanims
                    .Include("Musteri")
                    .Where(x => !x.IsDeleted)
                    .OrderBy(x => x.CreatedAt)
                    .ToList();

                return View(zimmetler);
            }
        }

        public ActionResult Ekle(Guid? zimmet_id)
        {
            if (zimmet_id == null)
            {
                return View();
            }
            else
            {
                using (var db = new ZimmetDbContext())
                {
                    var zimmet = db.ZimmetTanims.FirstOrDefault(x => x.Id == zimmet_id);
                    return View(zimmet);
                }
            }
        }

        [HttpPost]
        public ActionResult Ekle(ZimmetTanim zimmetTanim)
        {
            using (var db = new ZimmetDbContext())
            {
                var dbzimmmetTanim = db.ZimmetTanims.FirstOrDefault(x => x.Id == zimmetTanim.Id);

                if (dbzimmmetTanim == null) // İLK KAYIT
                {
                    db.ZimmetTanims.Add(zimmetTanim);
                    db.SaveChanges();

                    TempData["OK"] = "Zimmet Eklendi!";
                    return RedirectToAction("Listele");
                }
                else // GÜNCELLEME
                {
                    dbzimmmetTanim.Aciklama = zimmetTanim.Aciklama;
                    dbzimmmetTanim.Url = zimmetTanim.Url;
                    dbzimmmetTanim.KayitKullaniciAdi = zimmetTanim.KayitKullaniciAdi;
                    dbzimmmetTanim.KayitTelefonNo = zimmetTanim.KayitTelefonNo;
                    dbzimmmetTanim.Irtibat1 = zimmetTanim.Irtibat1;
                    dbzimmmetTanim.Irtibat2 = zimmetTanim.Irtibat2;

                    dbzimmmetTanim.UpdatedAt = DateTime.Now;

                    


                    db.SaveChanges();

                    TempData["OK"] = "Zimmet Güncelledi!";
                    return RedirectToAction("Listele");
                }
            }
        }

        public ActionResult Sil(Guid id)
        {
            using (var db = new ZimmetDbContext())
            {
                var zimmet = db.ZimmetTanims
                    .FirstOrDefault(x => x.Id == id);

                zimmet.IsDeleted = true;

                db.SaveChanges();

                TempData["OK"] = "Zimmet Kaydı Silindi!";

                return RedirectToAction("Listele");
            }
        }
    }
}