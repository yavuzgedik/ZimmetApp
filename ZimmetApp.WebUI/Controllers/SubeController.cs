using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ZimmetApp.DataAccess.EntityFramework;
using ZimmetApp.WebUI.Models.ViewModels;

namespace ZimmetApp.WebUI.Controllers
{
    public class SubeController : Controller
    {
        [HttpPost]
        public ActionResult DepartmanListesi(Guid subeId)
        {
            using (var db = new ZimmetDbContext())
            {
                var departmanlar = db.Departmans
                    .Where(x => x.SubeId == subeId)
                    .Select(x => new DepartmanVM()
                    {
                        DepartmanAdi = x.DepartmanAdi,
                        DepartmanId = x.Id
                    }).ToList();


                return Json(new { success = true, value = departmanlar }, JsonRequestBehavior.AllowGet);
            }
        }
    }
}