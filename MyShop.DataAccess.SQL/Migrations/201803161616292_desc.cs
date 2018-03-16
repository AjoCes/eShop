namespace MyShop.DataAccess.SQL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class desc : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.BaseDescriptions",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        CreatedAt = c.DateTimeOffset(nullable: false, precision: 7),
                    })
                .PrimaryKey(t => t.Id);
            
            AddColumn("dbo.ProductOffers", "Descr_Id", c => c.String(maxLength: 128));
            CreateIndex("dbo.ProductOffers", "Descr_Id");
            AddForeignKey("dbo.ProductOffers", "Descr_Id", "dbo.BaseDescriptions", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.ProductOffers", "Descr_Id", "dbo.BaseDescriptions");
            DropIndex("dbo.ProductOffers", new[] { "Descr_Id" });
            DropColumn("dbo.ProductOffers", "Descr_Id");
            DropTable("dbo.BaseDescriptions");
        }
    }
}
