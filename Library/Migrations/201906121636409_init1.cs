namespace Library.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class init1 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Carts",
                c => new
                    {
                        CartID = c.Int(nullable: false, identity: true),
                        BookID = c.Int(nullable: false),
                        BorrowingDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.CartID)
                .ForeignKey("dbo.Books", t => t.BookID, cascadeDelete: true)
                .Index(t => t.BookID);
            
            CreateTable(
                "dbo.News",
                c => new
                    {
                        NewID = c.Int(nullable: false, identity: true),
                        Title = c.String(nullable: false, maxLength: 50),
                        Description = c.String(nullable: false, maxLength: 3000),
                        PublishDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.NewID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Carts", "BookID", "dbo.Books");
            DropIndex("dbo.Carts", new[] { "BookID" });
            DropTable("dbo.News");
            DropTable("dbo.Carts");
        }
    }
}
