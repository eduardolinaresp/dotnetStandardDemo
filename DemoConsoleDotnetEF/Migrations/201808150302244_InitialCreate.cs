namespace DemoConsoleDotnetEF.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.orders",
                c => new
                    {
                        OrderId = c.Int(nullable: false, identity: true),
                        Fecha = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.OrderId);
            
            CreateTable(
                "dbo.orders_details",
                c => new
                    {
                        OrderDetailsId = c.Int(nullable: false, identity: true),
                        ItemName = c.String(maxLength: 800),
                        OrderId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.OrderDetailsId)
                .ForeignKey("dbo.orders", t => t.OrderId, cascadeDelete: true)
                .Index(t => t.OrderId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.orders_details", "OrderId", "dbo.orders");
            DropIndex("dbo.orders_details", new[] { "OrderId" });
            DropTable("dbo.orders_details");
            DropTable("dbo.orders");
        }
    }
}
