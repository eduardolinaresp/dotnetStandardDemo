namespace DemoConsoleDotnetEF.Migrations
{
    using DemoConsoleDotnetEF.Models;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<DemoConsoleDotnetEFContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;

            var dataDirPath = AppDomain.CurrentDomain.BaseDirectory;

            AppDomain.CurrentDomain.SetData("DataDirectory", dataDirPath);

        }

        protected override void Seed(DemoConsoleDotnetEFContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data.

            context.Ordenes.AddOrUpdate(x => x.OrderId,
              new Order() { Fecha = DateTime.Now },
              new Order() { Fecha = DateTime.Now },
              new Order() { Fecha = DateTime.Now }
              );


            context.OrdersDetails.AddOrUpdate(x => x.OrderDetailsId,
               new OrderDetail()
               {
                   ItemName = "Product1",
                   OrderId = 1

               },
                new OrderDetail()
                {
                    ItemName = "Product2",
                    OrderId = 1

                },
                 new OrderDetail()
                 {
                     ItemName = "Product3",
                     OrderId = 1

                 },
                new OrderDetail()
                {
                    ItemName = "Product4",
                    OrderId = 2
                }
                );
        }
    }
}
