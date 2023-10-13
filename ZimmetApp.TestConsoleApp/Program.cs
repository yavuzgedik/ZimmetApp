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
            #region Liste
            //var sehiler = new List<string>();

            //sehiler.Add("Bursa");
            //sehiler.Add("Yalova");
            //sehiler.Add("İzmir");
            //sehiler.Add("Manisa");
            #endregion

            #region TarihKontrol
            //var OneDate = new DateTime(2023, 10, 1);
            //var TwoDate = DateTime.Now;

            //var fark = TwoDate - OneDate;
            //var ticks = fark.Ticks;
            #endregion

            #region RandomZimmetOluşturma
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
            #endregion

            #region SubeVeDepartmanOlusturma

            //using (var db = new ZimmetDbContext())
            //{
            //    db.Subes.Add(new Sube()
            //    {
            //        SubeAdi = "Bursa",
            //        Departmens = new List<Departman>()
            //        {
            //            new Departman()
            //            {
            //                DepartmanAdi = "Bursa IT",
            //            },
            //            new Departman()
            //            {
            //                DepartmanAdi = "Bursa Finans",
            //            }
            //        },
            //    });

            //    db.SaveChanges();
            //}

            #endregion


            #region VeriGuncelleme
            //using (var db = new ZimmetDbContext())
            //{
            //    var result = db.ZimmetTanims.ToList();

            //    var count = 0;
            //    foreach (var item in result)
            //    {
            //        count++;
            //        if (count % 10 == 3)
            //        {
            //            item.CreatedAt = item.CreatedAt.AddMonths(3);
            //        }
            //    }

            //    db.SaveChanges();
            //}

            #endregion

        }
    }
}
