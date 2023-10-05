using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZimmetApp.DataAccess.EntityFramework;

namespace ZimmetApp.TestConsoleApp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //using (var db = new ZimmetDbContext())
            //{
            //    //var result = db.Users.ToList();
            //}

            var sehiler = new List<string>();

            sehiler.Add("Bursa");
            sehiler.Add("Yalova");
            sehiler.Add("İzmir");
            sehiler.Add("Manisa");

        }
    }
}
