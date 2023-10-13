using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations.Model;
using System.Linq;
using System.Web;

namespace ZimmetApp.WebUI.Models.ViewModels
{
    public class DepartmanVM
    {
        public Guid DepartmanId { get; set; }
        public string DepartmanAdi { get; set; }
    }
}