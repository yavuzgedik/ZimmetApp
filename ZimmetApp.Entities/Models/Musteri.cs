using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZimmetApp.Entities.Models
{
    public class Musteri : BaseEntity
    {
        public string MusteriKod { get; set; }
        public string MusteriAdi { get; set; }

        public virtual List<ZimmetTanim> ZimmetTanims { get; set; }
    }
}
