using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZimmetApp.DataAccess.EntityFramework;
using ZimmetApp.Entities.Models;

namespace ZimmetApp.TestConsoleApp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //var sehiler = new List<string>();

            //sehiler.Add("Bursa");
            //sehiler.Add("Yalova");
            //sehiler.Add("İzmir");
            //sehiler.Add("Manisa");

            var OneDate = new DateTime(2023, 10, 1);
            var TwoDate = DateTime.Now;

            var fark = TwoDate - OneDate;
            var ticks = fark.Ticks;


            //using (var db = new ZimmetDbContext())
            //{
            //    var musteriler = db.Musteris.Where(x=> !x.IsDeleted).ToList();
            //    var musteriSayisi = musteriler.Count();

            //    var rnd = new Random();

            //    var eklenecekZimmetList = new List<ZimmetTanim>();
            //    for (int i = 1; i <= 1000; i++)
            //    {
            //        var randomMusteri = rnd.Next(0, musteriSayisi - 1);

            //        var deger = i.ToString();
            //        eklenecekZimmetList.Add(new ZimmetTanim()
            //        {
            //            Aciklama = "Aciklama " + Guid.NewGuid().ToString().ToUpper().Substring(0, 6),
            //            Irtibat1 = "1. İrtibat " + deger,
            //            Irtibat2 = "2. İrtibat " + deger,
            //            KayitKullaniciAdi = "Kullanici Adi " + deger,
            //            KayitTelefonNo = "Telefon " + deger,
            //            Url = Guid.NewGuid().ToString().ToUpper().Substring(0, 6),
            //            MusteriId = musteriler[randomMusteri].Id,
            //        });
            //    }

            //    db.ZimmetTanims.AddRange(eklenecekZimmetList);
            //    db.SaveChanges();
            //}



        }
    }
}
