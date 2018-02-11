namespace Inlamning.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class produktasus : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Produkts",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ProduktName = c.String(),
                        Beskrvning = c.String(),
                        Pris = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Produkts");
        }
    }
}
