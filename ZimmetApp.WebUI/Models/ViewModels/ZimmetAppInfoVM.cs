using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ZimmetApp.WebUI.Models.ViewModels
{
    public class ZimmetAppInfoVM
    {
        public ZimmetAppInfoVM()
        {
            SonGuncelleme = DateTime.Now;
        }

        public int MusteriSayisi { get; set; }
        public int KullaniciSayisi { get; set; }
        public int ZimmetSayisi { get; set; }
        public int LogSayisi { get; set; }

        public DateTime SonGuncelleme { get; set; }
    }
}