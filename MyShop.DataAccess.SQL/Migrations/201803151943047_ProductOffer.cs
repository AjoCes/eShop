namespace MyShop.DataAccess.SQL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ProductOffer : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Products", "Offer", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Products", "Offer");
        }
    }
}
