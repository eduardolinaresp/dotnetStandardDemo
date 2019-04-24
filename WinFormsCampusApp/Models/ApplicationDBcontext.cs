namespace WinFormsCampusApp
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public  class ApplicationDBcontext : DbContext
    {
        public ApplicationDBcontext()
            : base("name=AplicattionDBcontext")
        {
            this.Configuration.AutoDetectChangesEnabled = false;
        }

        public  DbSet<cliente> Clientes { get; set; }
        public  DbSet<role_user> Role_user { get; set; }
        public  DbSet<role> Roles { get; set; }
        public DbSet<user> Users { get; set; }
        public DbSet<password_resets> Password_resets { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
        }
    }
}
