namespace Martec.Infrastruture.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialMigrations : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Categories",
                c => new
                    {
                        CategoryId = c.Int(nullable: false, identity: true),
                        CategoryName = c.String(),
                        CreatedDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.CategoryId);
            
            CreateTable(
                "dbo.Products",
                c => new
                    {
                        ProductId = c.Int(nullable: false, identity: true),
                        CategoryId = c.Int(nullable: false),
                        ProductName = c.String(),
                        Size = c.String(),
                        UnitPrice = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Image = c.String(),
                        CreatedDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.ProductId)
                .ForeignKey("dbo.Categories", t => t.CategoryId, cascadeDelete: true)
                .Index(t => t.CategoryId);
            
            CreateTable(
                "dbo.Images",
                c => new
                    {
                        ImageId = c.Int(nullable: false, identity: true),
                        ProductId = c.Int(nullable: false),
                        URL = c.String(),
                    })
                .PrimaryKey(t => t.ImageId)
                .ForeignKey("dbo.Products", t => t.ProductId, cascadeDelete: true)
                .Index(t => t.ProductId);
            
            CreateTable(
                "dbo.Items",
                c => new
                    {
                        ItemId = c.Int(nullable: false, identity: true),
                        OrderId = c.Int(nullable: false),
                        ProductId = c.Int(nullable: false),
                        UnitPrice = c.Decimal(nullable: false, precision: 18, scale: 2),
                        PRoductName = c.String(),
                        Quantity = c.Int(nullable: false),
                        Size = c.String(),
                        CreatedDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.ItemId)
                .ForeignKey("dbo.Orders", t => t.OrderId, cascadeDelete: true)
                .ForeignKey("dbo.Products", t => t.ProductId, cascadeDelete: true)
                .Index(t => t.OrderId)
                .Index(t => t.ProductId);
            
            CreateTable(
                "dbo.Orders",
                c => new
                    {
                        OrderId = c.Int(nullable: false, identity: true),
                        UserId = c.Int(nullable: false),
                        CreatedDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.OrderId)
                .ForeignKey("dbo.Users", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.OrderDeliveries",
                c => new
                    {
                        OrderDeliveryId = c.Int(nullable: false, identity: true),
                        OrderId = c.Int(nullable: false),
                        FullName = c.String(),
                        DeliveryAddress = c.String(),
                        PhoneNumber = c.String(),
                        CreatedDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.OrderDeliveryId)
                .ForeignKey("dbo.Orders", t => t.OrderId, cascadeDelete: true)
                .Index(t => t.OrderId);
            
            CreateTable(
                "dbo.Payments",
                c => new
                    {
                        PaymentId = c.Int(nullable: false, identity: true),
                        OrderId = c.Int(nullable: false),
                        Amount = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Reference = c.String(),
                        ReceiptNo = c.String(),
                        PaymentDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.PaymentId)
                .ForeignKey("dbo.Orders", t => t.OrderId, cascadeDelete: true)
                .Index(t => t.OrderId);
            
            CreateTable(
                "dbo.Users",
                c => new
                    {
                        UserId = c.Int(nullable: false, identity: true),
                        Email = c.String(),
                        PasswordHash = c.String(),
                        FirstName = c.String(),
                        LastName = c.String(),
                        CreatedDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.UserId);
            
            CreateTable(
                "dbo.Employees",
                c => new
                    {
                        UserId = c.Int(nullable: false),
                        CreatedDate = c.DateTime(nullable: false),
                        Address = c.String(),
                        Phone = c.String(),
                    })
                .PrimaryKey(t => t.UserId)
                .ForeignKey("dbo.Users", t => t.UserId)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.UserRoles",
                c => new
                    {
                        UserRoleId = c.Int(nullable: false, identity: true),
                        UserId = c.Int(nullable: false),
                        RoleId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.UserRoleId)
                .ForeignKey("dbo.Roles", t => t.RoleId, cascadeDelete: true)
                .ForeignKey("dbo.Users", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId)
                .Index(t => t.RoleId);
            
            CreateTable(
                "dbo.Roles",
                c => new
                    {
                        RoleId = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.RoleId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Items", "ProductId", "dbo.Products");
            DropForeignKey("dbo.UserRoles", "UserId", "dbo.Users");
            DropForeignKey("dbo.UserRoles", "RoleId", "dbo.Roles");
            DropForeignKey("dbo.Orders", "UserId", "dbo.Users");
            DropForeignKey("dbo.Employees", "UserId", "dbo.Users");
            DropForeignKey("dbo.Payments", "OrderId", "dbo.Orders");
            DropForeignKey("dbo.OrderDeliveries", "OrderId", "dbo.Orders");
            DropForeignKey("dbo.Items", "OrderId", "dbo.Orders");
            DropForeignKey("dbo.Images", "ProductId", "dbo.Products");
            DropForeignKey("dbo.Products", "CategoryId", "dbo.Categories");
            DropIndex("dbo.UserRoles", new[] { "RoleId" });
            DropIndex("dbo.UserRoles", new[] { "UserId" });
            DropIndex("dbo.Employees", new[] { "UserId" });
            DropIndex("dbo.Payments", new[] { "OrderId" });
            DropIndex("dbo.OrderDeliveries", new[] { "OrderId" });
            DropIndex("dbo.Orders", new[] { "UserId" });
            DropIndex("dbo.Items", new[] { "ProductId" });
            DropIndex("dbo.Items", new[] { "OrderId" });
            DropIndex("dbo.Images", new[] { "ProductId" });
            DropIndex("dbo.Products", new[] { "CategoryId" });
            DropTable("dbo.Roles");
            DropTable("dbo.UserRoles");
            DropTable("dbo.Employees");
            DropTable("dbo.Users");
            DropTable("dbo.Payments");
            DropTable("dbo.OrderDeliveries");
            DropTable("dbo.Orders");
            DropTable("dbo.Items");
            DropTable("dbo.Images");
            DropTable("dbo.Products");
            DropTable("dbo.Categories");
        }
    }
}
