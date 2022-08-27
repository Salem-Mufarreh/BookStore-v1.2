namespace BookStore.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class init : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Books",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Title = c.String(nullable: false),
                        Author = c.String(),
                        Description = c.String(),
                        Quantity = c.Int(nullable: false),
                        Status = c.String(),
                        Price = c.Double(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Carts",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        BookId = c.Int(nullable: false),
                        UserId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Cart_Item",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Sessionid = c.Int(nullable: false),
                        BooksId = c.Int(nullable: false),
                        Created = c.DateTime(nullable: false),
                        LastUpdated = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Books", t => t.BooksId, cascadeDelete: true)
                .ForeignKey("dbo.Shoping_Session", t => t.Sessionid, cascadeDelete: true)
                .Index(t => t.Sessionid)
                .Index(t => t.BooksId);
            
            CreateTable(
                "dbo.Shoping_Session",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UsersId = c.Int(nullable: false),
                        Total = c.Decimal(nullable: false, precision: 18, scale: 2),
                        CreatedDate = c.DateTime(nullable: false),
                        UpdatedDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Users", t => t.UsersId, cascadeDelete: true)
                .Index(t => t.UsersId);
            
            CreateTable(
                "dbo.Users",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                        Email = c.String(),
                        Address = c.String(),
                        PhoneNumber = c.String(),
                        Role = c.String(),
                        password = c.String(),
                        Active = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.OrderDetails",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Booksid = c.Int(nullable: false),
                        Usersid = c.Int(nullable: false),
                        Total = c.Int(nullable: false),
                        Created = c.DateTime(nullable: false),
                        Status = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Books", t => t.Booksid, cascadeDelete: true)
                .ForeignKey("dbo.Users", t => t.Usersid, cascadeDelete: true)
                .Index(t => t.Booksid)
                .Index(t => t.Usersid);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.OrderDetails", "Usersid", "dbo.Users");
            DropForeignKey("dbo.OrderDetails", "Booksid", "dbo.Books");
            DropForeignKey("dbo.Cart_Item", "Sessionid", "dbo.Shoping_Session");
            DropForeignKey("dbo.Shoping_Session", "UsersId", "dbo.Users");
            DropForeignKey("dbo.Cart_Item", "BooksId", "dbo.Books");
            DropIndex("dbo.OrderDetails", new[] { "Usersid" });
            DropIndex("dbo.OrderDetails", new[] { "Booksid" });
            DropIndex("dbo.Shoping_Session", new[] { "UsersId" });
            DropIndex("dbo.Cart_Item", new[] { "BooksId" });
            DropIndex("dbo.Cart_Item", new[] { "Sessionid" });
            DropTable("dbo.OrderDetails");
            DropTable("dbo.Users");
            DropTable("dbo.Shoping_Session");
            DropTable("dbo.Cart_Item");
            DropTable("dbo.Carts");
            DropTable("dbo.Books");
        }
    }
}
