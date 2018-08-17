namespace DemoConsoleDotnetEF.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "APP.orders",
                c => new
                    {
                        OrderId = c.Decimal(nullable: false, precision: 10, scale: 0, identity: true),
                        Fecha = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.OrderId);
            
            CreateTable(
                "APP.orders_details",
                c => new
                    {
                        OrderDetailsId = c.Decimal(nullable: false, precision: 10, scale: 0, identity: true),
                        ItemName = c.String(maxLength: 800),
                        OrderId = c.Decimal(nullable: false, precision: 10, scale: 0),
                    })
                .PrimaryKey(t => t.OrderDetailsId)
                .ForeignKey("APP.orders", t => t.OrderId, cascadeDelete: true)
                .Index(t => t.OrderId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("APP.orders_details", "OrderId", "APP.orders");
            DropIndex("APP.orders_details", new[] { "OrderId" });
            DropTable("APP.orders_details");
            DropTable("APP.orders");
        }
    }
}
