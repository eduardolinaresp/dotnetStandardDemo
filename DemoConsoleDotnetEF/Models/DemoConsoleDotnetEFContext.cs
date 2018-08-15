using DemoConsoleDotnetEF.Models;
using DemoConsoleDotnetEF.Configurations;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoConsoleDotnetEF.Models
{
    public class DemoConsoleDotnetEFContext : DbContext
    {

        public DemoConsoleDotnetEFContext() : base("name=DemoConsoleDotnetEF")
        {

            this.Configuration.AutoDetectChangesEnabled = false;

        }

        public DbSet<Order> Ordenes { get; set; }
        public DbSet<OrderDetail> OrdersDetails { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            
            modelBuilder.Configurations.Add(new OrderConfiguration());
            modelBuilder.Configurations.Add(new OrderDetailConfiguration());

            base.OnModelCreating(modelBuilder);
        }

    }
}
