namespace MyShop.DataAccess.SQL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class BaseOffers : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.OffersModels", "Name", c => c.String());
            AddColumn("dbo.OffersModels", "Description", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.OffersModels", "Description");
            DropColumn("dbo.OffersModels", "Name");
        }
    }
}
