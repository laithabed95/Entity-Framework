namespace Order.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Addresses",
                c => new
                    {
                        AddressID = c.Int(nullable: false, identity: true),
                        Street = c.String(),
                        City = c.String(),
                        Country = c.String(),
                    })
                .PrimaryKey(t => t.AddressID);
            
            CreateTable(
                "dbo.Customers",
                c => new
                    {
                        CustomerID = c.Int(nullable: false, identity: true),
                        FirstName = c.String(),
                        LastName = c.String(nullable: false, maxLength: 30),
                        Company = c.String(nullable: false, maxLength: 30),
                        Email = c.String(),
                        Phone = c.String(),
                        Created = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.CustomerID);
            
            CreateTable(
                "dbo.Orders",
                c => new
                    {
                        OrderID = c.Int(nullable: false, identity: true),
                        OrderDate = c.DateTime(nullable: false),
                        ShipDate = c.DateTime(nullable: false),
                        TotalOrder = c.Decimal(nullable: false, precision: 18, scale: 2),
                        PruductCount = c.Int(nullable: false),
                        CustomerID = c.Int(nullable: false),
                        BillToAdress_AddressID = c.Int(),
                        ShipToAddress_AddressID = c.Int(),
                    })
                .PrimaryKey(t => t.OrderID)
                .ForeignKey("dbo.Addresses", t => t.BillToAdress_AddressID)
                .ForeignKey("dbo.Customers", t => t.CustomerID, cascadeDelete: true)
                .ForeignKey("dbo.Addresses", t => t.ShipToAddress_AddressID)
                .Index(t => t.CustomerID)
                .Index(t => t.BillToAdress_AddressID)
                .Index(t => t.ShipToAddress_AddressID);
            
            CreateTable(
                "dbo.CustomerAddresses",
                c => new
                    {
                        Customer_CustomerID = c.Int(nullable: false),
                        Address_AddressID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Customer_CustomerID, t.Address_AddressID })
                .ForeignKey("dbo.Customers", t => t.Customer_CustomerID, cascadeDelete: true)
                .ForeignKey("dbo.Addresses", t => t.Address_AddressID, cascadeDelete: true)
                .Index(t => t.Customer_CustomerID)
                .Index(t => t.Address_AddressID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Orders", "ShipToAddress_AddressID", "dbo.Addresses");
            DropForeignKey("dbo.Orders", "CustomerID", "dbo.Customers");
            DropForeignKey("dbo.Orders", "BillToAdress_AddressID", "dbo.Addresses");
            DropForeignKey("dbo.CustomerAddresses", "Address_AddressID", "dbo.Addresses");
            DropForeignKey("dbo.CustomerAddresses", "Customer_CustomerID", "dbo.Customers");
            DropIndex("dbo.CustomerAddresses", new[] { "Address_AddressID" });
            DropIndex("dbo.CustomerAddresses", new[] { "Customer_CustomerID" });
            DropIndex("dbo.Orders", new[] { "ShipToAddress_AddressID" });
            DropIndex("dbo.Orders", new[] { "BillToAdress_AddressID" });
            DropIndex("dbo.Orders", new[] { "CustomerID" });
            DropTable("dbo.CustomerAddresses");
            DropTable("dbo.Orders");
            DropTable("dbo.Customers");
            DropTable("dbo.Addresses");
        }
    }
}
