namespace MyShop.DataAccess.SQL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class OfferType : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.ProductOffers", "Discriminator", c => c.String(nullable: false, maxLength: 128));
        }
        
        public override void Down()
        {
            DropColumn("dbo.ProductOffers", "Discriminator");
        }
    }
}
