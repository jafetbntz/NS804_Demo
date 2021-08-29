namespace NS804_Demo.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class FixOtography : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.AspNetUsers", "AddressLine1", c => c.String());
            AddColumn("dbo.AspNetUsers", "AddressLine2", c => c.String());
            DropColumn("dbo.AspNetUsers", "AddresLine1");
            DropColumn("dbo.AspNetUsers", "AddresLine2");
        }
        
        public override void Down()
        {
            AddColumn("dbo.AspNetUsers", "AddresLine2", c => c.String());
            AddColumn("dbo.AspNetUsers", "AddresLine1", c => c.String());
            DropColumn("dbo.AspNetUsers", "AddressLine2");
            DropColumn("dbo.AspNetUsers", "AddressLine1");
        }
    }
}
