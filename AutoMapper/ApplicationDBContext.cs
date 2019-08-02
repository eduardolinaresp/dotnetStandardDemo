using AutoMapper.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoMapper
{
    public class ApplicationDBContext : DbContext
    {

        public ApplicationDBContext() : base("AplicattionDBcontext")
        {
            this.Configuration.AutoDetectChangesEnabled = false;
            // Database.SetInitializer(new MigrateDatabaseToLatestVersion<ApplicationDBContext, EF6Console.Migrations.Configuration>());

        }

        public DbSet<CorporateRatesInfo> CorporateRatesInfo { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {

            modelBuilder.Entity<CorporateRatesInfo>()
                        .ToTable("CorporateRatesInfo");


            base.OnModelCreating(modelBuilder);
        }


    }
}
