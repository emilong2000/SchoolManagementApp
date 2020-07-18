namespace DataAccess.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RemoveConfirmPassword : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Students", "ConfirmPassword");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Students", "ConfirmPassword", c => c.String());
        }
    }
}
