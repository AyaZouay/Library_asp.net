namespace Library.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class init5 : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.News", "PublishDate");
        }
        
        public override void Down()
        {
            AddColumn("dbo.News", "PublishDate", c => c.DateTime(nullable: false));
        }
    }
}
