namespace Inlamning.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addint : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Produkts", "Pris", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Produkts", "Pris", c => c.Decimal(nullable: false, precision: 18, scale: 2));
        }
    }
}
