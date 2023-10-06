using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Web;

namespace ZimmetApp.WebUI.Models.ViewModels
{
    public class MusteriVM
    {
        public Guid Id { get; set; }
        public string MusteriAdi { get; set; }
        public string MusteriKodu { get; set; }
        public int ZimmetSayisi { get; set; }
        public bool IsDeleted { get; set; }
    }
}