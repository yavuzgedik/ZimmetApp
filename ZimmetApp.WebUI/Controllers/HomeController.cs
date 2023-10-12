using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Caching;
using System.Web.Mvc;
using ZimmetApp.DataAccess.EntityFramework;
using ZimmetApp.Entities.Models;
using ZimmetApp.WebUI.Models.ViewModels;

namespace ZimmetApp.WebUI.Controllers
{
    public class HomeController : BaseController
    {
        private ZimmetAppInfoVM LoadData()
        {
            // Verileri veritabanından veya başka bir kaynaktan yükle
            using (var db = new ZimmetDbContext())
            {
                var zimmetAppInfoVM = new ZimmetAppInfoVM
                {
                    KullaniciSayisi = db.Users.Where(x => !x.IsDeleted).Count(),
                    MusteriSayisi = db.Musteris.Where(x => !x.IsDeleted).Count(),
                    ZimmetSayisi = db.ZimmetTanims.Where(x => !x.IsDeleted).Count(),
                    LogSayisi = db.ZimmetLogs.Where(x => !x.IsDeleted).Count(),
                    SonGuncelleme = DateTime.Now
                };
                return zimmetAppInfoVM;
            }
        }

        private void CacheData(ZimmetAppInfoVM zimmetAppInfoVM)
        {
            HttpContext.Cache.Insert("ZimmetInfo", zimmetAppInfoVM, null, DateTime.Now.AddSeconds(15), Cache.NoSlidingExpiration);
        }

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

            #region INFO-ESKI-KOD

            //ZimmetAppInfoVM zimmetAppInfoVM = new ZimmetAppInfoVM();

            //if (Session["ZimmetInfo"] != null)
            //{
            //    zimmetAppInfoVM = Session["ZimmetInfo"] as ZimmetAppInfoVM;
            //}
            //else
            //{
            //    using (var db = new ZimmetDbContext())
            //    {
            //        zimmetAppInfoVM.KullaniciSayisi = db.Users.Where(x => !x.IsDeleted).Count();
            //        zimmetAppInfoVM.MusteriSayisi = db.Musteris.Where(x => !x.IsDeleted).Count();
            //        zimmetAppInfoVM.ZimmetSayisi = db.ZimmetTanims.Where(x => !x.IsDeleted).Count();
            //        zimmetAppInfoVM.LogSayisi = db.ZimmetLogs.Where(x => !x.IsDeleted).Count();
            //        zimmetAppInfoVM.SonGuncelleme = DateTime.Now;

            //        Session["ZimmetInfo"] = zimmetAppInfoVM;
            //    }
            //}

            //return View(zimmetAppInfoVM);

            #endregion

            #region SESSION-INFO
            //ZimmetAppInfoVM zimmetAppInfoVM = new ZimmetAppInfoVM();
            //bool yenilemeKontrol = false;

            //if (Session["ZimmetInfo"] != null)
            //{
            //    zimmetAppInfoVM = Session["ZimmetInfo"] as ZimmetAppInfoVM;

            //    TimeSpan fark = DateTime.Now - zimmetAppInfoVM.SonGuncelleme; // Son güncelleme tarihinden itibaren geçen süre
            //    if (fark.TotalSeconds > 30) // Süre 30 saniyeden fazlaysa verileri güncelle
            //    {
            //        yenilemeKontrol = true;
            //    }
            //}
            //else
            //{
            //    yenilemeKontrol = true; // Session'da veri yoksa güncelleme yap
            //}

            //if (yenilemeKontrol)
            //{
            //    using (var db = new ZimmetDbContext())
            //    {
            //        zimmetAppInfoVM.KullaniciSayisi = db.Users.Where(x => !x.IsDeleted).Count();
            //        zimmetAppInfoVM.MusteriSayisi = db.Musteris.Where(x => !x.IsDeleted).Count();
            //        zimmetAppInfoVM.ZimmetSayisi = db.ZimmetTanims.Where(x => !x.IsDeleted).Count();
            //        zimmetAppInfoVM.LogSayisi = db.ZimmetLogs.Where(x => !x.IsDeleted).Count();
            //        zimmetAppInfoVM.SonGuncelleme = DateTime.Now;

            //        Session["ZimmetInfo"] = zimmetAppInfoVM;
            //    }
            //}

            //return View(zimmetAppInfoVM);
            #endregion

            ZimmetAppInfoVM zimmetAppInfoVM;

            // Önbellekten verileri alma
            if (HttpContext.Cache["ZimmetInfo"] != null)
            {
                zimmetAppInfoVM = HttpContext.Cache["ZimmetInfo"] as ZimmetAppInfoVM;
            }
            else
            {
                zimmetAppInfoVM = LoadData();
                CacheData(zimmetAppInfoVM);
            }

            return View(zimmetAppInfoVM);

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