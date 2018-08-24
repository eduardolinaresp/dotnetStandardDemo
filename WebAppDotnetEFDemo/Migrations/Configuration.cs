namespace WebAppDotnetEFDemo.Migrations
{
    using Microsoft.AspNet.Identity;
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
            var passwordHash = new PasswordHasher();
            string password = passwordHash.HashPassword("Password@123");

            context.Users.AddOrUpdate(usr => usr.UserName, 
                new ApplicationUser
            {
                UserName = "eduardo.linares@correo.com",
                PasswordHash = password,
                PhoneNumber = "12345678911",
                Email = "eduardo.linares@correo.com",
                SecurityStamp= Guid.NewGuid().ToString()

                });



            context.Ordenes.AddOrUpdate(x => x.OrderId,
                     new Order() { Fecha = DateTime.Now },
                     new Order() { Fecha = DateTime.Now },
                     new Order() { Fecha = DateTime.Now }
                     );
            //
        }
    }
}
