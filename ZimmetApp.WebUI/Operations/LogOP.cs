using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ZimmetApp.DataAccess.EntityFramework;
using ZimmetApp.Entities.Enums;
using ZimmetApp.Entities.Helper;
using ZimmetApp.Entities.Models;

namespace ZimmetApp.WebUI.Operations
{
    public class LogOP
    {
        public static void LogOlusturma(User user, string logDetay, LogTip logTip)
        {
            using (var db = new ZimmetDbContext())
            {
                string clientIP = HttpContext.Current.Request.UserHostAddress;

                db.ZimmetLogs.Add(new ZimmetLog()
                {
                    IpAdres = clientIP,
                    BilgisayarAdi = "",
                    DCAdi = "",
                    Detay = logDetay,
                    LogTip = logTip,
                    UserId = user.Id
                });

                db.SaveChanges();
            }
        }
    }
}