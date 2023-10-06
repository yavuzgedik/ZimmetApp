using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZimmetApp.Entities.Enums;

namespace ZimmetApp.Entities.Models
{
    public class ZimmetLog : BaseEntity
    {
        public string IpAdres { get; set; }
        public string BilgisayarAdi { get; set; }
        public string DCAdi { get; set; }
        public string Detay { get; set; }
        public LogTip LogTip { get; set; }


        public Guid? UserId { get; set; }
        public virtual User User { get; set; }
    }
}
