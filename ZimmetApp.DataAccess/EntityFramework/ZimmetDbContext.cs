using System;
using System.Data.Entity;
using System.Linq;
using ZimmetApp.Entities.Helper;
using ZimmetApp.Entities.Models;

namespace ZimmetApp.DataAccess.EntityFramework
{
    public class ZimmetDbContext : DbContext
    {
        public ZimmetDbContext()
            : base(@"data source=(LocalDb)\MSSQLLocalDB;initial catalog=ZimmetAppDB;integrated security=True;MultipleActiveResultSets=True;App=EntityFramework")
        {
            Database.SetInitializer(new ZimmetInitializer());
        }

        public virtual DbSet<User> Users { get; set; }
        public virtual DbSet<Musteri> Musteris { get; set; }
        public virtual DbSet<ZimmetTanim> ZimmetTanims { get; set; }
        public virtual DbSet<ZimmetLog> ZimmetLogs { get; set; }
    }

    public class ZimmetInitializer : CreateDatabaseIfNotExists<ZimmetDbContext>
    {
        protected override void Seed(ZimmetDbContext db)
        {
            db.Users.Add(new User
            {
                FirstName = "Yavuz",
                LastName = "Gedik",
                IsAdmin = true,
                UserCode = "001",
                UserPassword = "100",
            });


            //User _user = new User();

            db.SaveChanges();
        }
    }
}