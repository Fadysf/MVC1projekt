namespace Inlamning.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class adderaOrders : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Orders",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Created = c.DateTime(nullable: false),
                        Payed = c.Boolean(nullable: false),
                        Shipping = c.Boolean(nullable: false),
                        Total = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Orders");
        }
    }
}
