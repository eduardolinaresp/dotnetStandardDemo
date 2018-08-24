namespace WebAppDotnetEFDemo.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using WebAppDotnetEFDemo.Models;

    internal sealed class Configuration : DbMigrationsConfiguration<WebAppDotnetEFDemo.Models.ApplicationDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(WebAppDotnetEFDemo.Models.ApplicationDbContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data. E.g.
            //
            context.Ordenes.AddOrUpdate(x => x.OrderId,
                     new Order() { Fecha = DateTime.Now },
                     new Order() { Fecha = DateTime.Now },
                     new Order() { Fecha = DateTime.Now }
                     );
            //
        }
    }
}
