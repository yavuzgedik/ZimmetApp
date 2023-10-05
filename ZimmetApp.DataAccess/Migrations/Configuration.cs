namespace ZimmetApp.DataAccess.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<ZimmetApp.DataAccess.EntityFramework.ZimmetDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
            ContextKey = "ZimmetApp.DataAccess.EntityFramework.ZimmetDbContext";
        }

        protected override void Seed(ZimmetApp.DataAccess.EntityFramework.ZimmetDbContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method
            //  to avoid creating duplicate seed data.
        }
    }
}
