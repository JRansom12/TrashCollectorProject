namespace TrashCollector.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PickupConfMigration : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Customers", "PickupConfirmation", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Customers", "PickupConfirmation");
        }
    }
}
