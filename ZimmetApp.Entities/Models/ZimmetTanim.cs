using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZimmetApp.Entities.Models
{
    public class ZimmetTanim : BaseEntity
    {
        public string Aciklama { get; set; }
        public string Url { get; set; }
        public string KayitKullaniciAdi { get; set; }
        public string KayitTelefonNo { get; set; }
        public string Irtibat1 { get; set; }
        public string Irtibat2 { get; set; }
        public Guid? MusteriId { get; set; }

        public virtual Musteri Musteri { get; set; }
    }
}
