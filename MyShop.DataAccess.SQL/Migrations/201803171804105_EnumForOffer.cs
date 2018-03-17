namespace MyShop.DataAccess.SQL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class EnumForOffer : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.OffersModels",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Offers = c.Int(nullable: false),
                        CreatedAt = c.DateTimeOffset(nullable: false, precision: 7),
                    })
                .PrimaryKey(t => t.Id);
            
            DropColumn("dbo.ProductOffers", "Discriminator");
        }
        
        public override void Down()
        {
            AddColumn("dbo.ProductOffers", "Discriminator", c => c.String(nullable: false, maxLength: 128));
            DropTable("dbo.OffersModels");
        }
    }
}
