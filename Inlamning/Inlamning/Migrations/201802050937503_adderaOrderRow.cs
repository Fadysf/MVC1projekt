namespace Inlamning.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class adderaOrderRow : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.OrderRows",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        OrderId = c.Int(nullable: false),
                        ProduktId = c.Int(nullable: false),
                        Amount = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Produkts", t => t.ProduktId, cascadeDelete: true)
                .Index(t => t.ProduktId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.OrderRows", "ProduktId", "dbo.Produkts");
            DropIndex("dbo.OrderRows", new[] { "ProduktId" });
            DropTable("dbo.OrderRows");
        }
    }
}
