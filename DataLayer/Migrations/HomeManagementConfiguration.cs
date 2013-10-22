namespace HomeManagement.DataLayer.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    public class HomeManagementConfiguration : DbMigrationsConfiguration<HomeManagement.DataLayer.HomeManagementContext>
    {
        public HomeManagementConfiguration()
        {
            AutomaticMigrationsEnabled = true;
        }

        protected override void Seed(HomeManagement.DataLayer.HomeManagementContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data. E.g.
            //
            //    context.People.AddOrUpdate(
            //      p => p.FullName,
            //      new Person { FullName = "Andrew Peters" },
            //      new Person { FullName = "Brice Lambson" },
            //      new Person { FullName = "Rowan Miller" }
            //    );
            //
        }
    }
}
