using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ZimmetApp.DataAccess.EntityFramework;
using ZimmetApp.Entities.Helper;
using ZimmetApp.Entities.Models;
using ZimmetApp.WebUI.Operations;

namespace ZimmetApp.WebUI.Controllers
{
    public class ZimmetController : BaseController
    {
        public ActionResult Listele(Guid? musteri_id)
        {
            using (var db = new ZimmetDbContext())
            {
                var musteriler = db.Musteris
                    .Where(x => !x.IsDeleted)
                    .OrderBy(x => x.MusteriKod)
                    .ToList();

                ViewBag.Musteriler = musteriler;
            }
            
            return View();
        }

        [HttpPost]
        public ActionResult Listele(DateTime? start, DateTime? end, Guid? musteri_id)
        {
            using (var db = new ZimmetDbContext())
            {
                var user = Session["User"] as User;
                LogOP.LogOlusturma(user, LogDetay.ZimmetListeleme, Entities.Enums.LogTip.Read);

                var musteriler = db.Musteris
                    .Where(x => !x.IsDeleted)
                    .OrderBy(x => x.MusteriKod)
                    .ToList();

                ViewBag.Musteriler = musteriler;

                if (start == null && end == null && musteri_id != null)
                {
                    var zimmetler = db.ZimmetTanims
                        .Include("Musteri")
                        .Where(x => !x.IsDeleted && x.MusteriId == musteri_id)
                        .OrderBy(x => x.CreatedAt)
                        .ToList();

                    ViewBag.MusteriAdi = zimmetler != null && zimmetler.Count > 0 ? zimmetler.First().Musteri.MusteriAdi : "";

                    return View(zimmetler);
                }
                else
                {
                    var one = new DateTime(start.Value.Year, start.Value.Month, start.Value.Day, 0, 0, 0);
                    var two = new DateTime(end.Value.Year, end.Value.Month, end.Value.Day, 23, 59, 59);

                    TempData["Start"] = one;
                    TempData["End"] = two;

                    TempData["MusterId"] = musteri_id;

                    var zimmetler = db.ZimmetTanims
                        .Include("Musteri")
                        .Where(x => !x.IsDeleted
                        && x.CreatedAt >= one
                        && x.CreatedAt <= two
                        && (musteri_id == null || x.MusteriId == musteri_id))
                        .OrderBy(x => x.CreatedAt)
                        .ToList();

                    return View(zimmetler);
                }
            }
        }

        public ActionResult Ekle(Guid? zimmet_id)
        {
            var user = Session["User"] as User;

            using (var db = new ZimmetDbContext())
            {
                var musteriler = db.Musteris
                    .Where(x => !x.IsDeleted)
                    .OrderBy(x => x.MusteriKod)
                    .ToList();

                ViewBag.Musteriler = musteriler;

                if (zimmet_id == null)
                {
                    return View();
                }
                else
                {
                    LogOP.LogOlusturma(user, LogDetay.ZimmetDetay, Entities.Enums.LogTip.Read);

                    var zimmet = db.ZimmetTanims.FirstOrDefault(x => x.Id == zimmet_id);
                    return View(zimmet);
                }
            }
        }

        [HttpPost]
        public ActionResult Ekle(ZimmetTanim zimmetTanim)
        {
            var user = Session["User"] as User;

            using (var db = new ZimmetDbContext())
            {
                var dbzimmmetTanim = db.ZimmetTanims.FirstOrDefault(x => x.Id == zimmetTanim.Id);

                if (dbzimmmetTanim == null) // İLK KAYIT
                {
                    LogOP.LogOlusturma(user, LogDetay.ZimmetEkle, Entities.Enums.LogTip.Create);

                    db.ZimmetTanims.Add(zimmetTanim);
                    db.SaveChanges();

                    TempData["OK"] = "Zimmet Eklendi!";
                    return RedirectToAction("Listele");
                }
                else // GÜNCELLEME
                {
                    LogOP.LogOlusturma(user, LogDetay.ZimmetGuncelleme, Entities.Enums.LogTip.Update);

                    dbzimmmetTanim.Aciklama = zimmetTanim.Aciklama;
                    dbzimmmetTanim.Url = zimmetTanim.Url;
                    dbzimmmetTanim.KayitKullaniciAdi = zimmetTanim.KayitKullaniciAdi;
                    dbzimmmetTanim.KayitTelefonNo = zimmetTanim.KayitTelefonNo;
                    dbzimmmetTanim.Irtibat1 = zimmetTanim.Irtibat1;
                    dbzimmmetTanim.Irtibat2 = zimmetTanim.Irtibat2;
                    dbzimmmetTanim.MusteriId = zimmetTanim.MusteriId;
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
                var user = Session["User"] as User;
                LogOP.LogOlusturma(user, LogDetay.ZimmetSil, Entities.Enums.LogTip.Delete);

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