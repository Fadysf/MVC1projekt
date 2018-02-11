namespace Inlamning.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class asusdenandra : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Produkts", "ProduktName", c => c.String(nullable: false));
            AlterColumn("dbo.Produkts", "Pris", c => c.Decimal(nullable: false, precision: 18, scale: 2));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Produkts", "Pris", c => c.Int(nullable: false));
            AlterColumn("dbo.Produkts", "ProduktName", c => c.String());
        }
    }
}
