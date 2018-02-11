namespace Inlamning.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class lärareändring : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Produkts",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ProduktName = c.String(nullable: false),
                        Beskrvning = c.String(),
                        Pris = c.Decimal(nullable: false, precision: 18, scale: 2),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Produkts");
        }
    }
}
