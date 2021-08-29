namespace NS804_Demo.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class QuoteModel : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Quotes",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        Text = c.String(),
                        Author = c.String(),
                        CreationDate = c.DateTime(nullable: false),
                        LastUpdate = c.DateTime(nullable: false),
                        CreatorId = c.String(maxLength: 128),
                        LastEditorId = c.String(maxLength: 128),
                        IsActive = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetUsers", t => t.CreatorId)
                .ForeignKey("dbo.AspNetUsers", t => t.LastEditorId)
                .Index(t => t.CreatorId)
                .Index(t => t.LastEditorId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Quotes", "LastEditorId", "dbo.AspNetUsers");
            DropForeignKey("dbo.Quotes", "CreatorId", "dbo.AspNetUsers");
            DropIndex("dbo.Quotes", new[] { "LastEditorId" });
            DropIndex("dbo.Quotes", new[] { "CreatorId" });
            DropTable("dbo.Quotes");
        }
    }
}
