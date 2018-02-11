namespace Inlamning.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AderaEnBild : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Produkts", "bild", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Produkts", "bild");
        }
    }
}
