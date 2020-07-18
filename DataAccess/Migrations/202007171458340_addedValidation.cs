namespace DataAccess.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addedValidation : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Students", "Email", c => c.String(nullable: false));
            AddColumn("dbo.Students", "Password", c => c.String(nullable: false, maxLength: 100));
            AddColumn("dbo.Students", "ConfirmPassword", c => c.String());
            AlterColumn("dbo.Courses", "CourseName", c => c.String(nullable: false));
            AlterColumn("dbo.Courses", "CourseCode", c => c.String(nullable: false));
            AlterColumn("dbo.Students", "FirstName", c => c.String(nullable: false));
            AlterColumn("dbo.Students", "LastName", c => c.String(nullable: false));
            AlterColumn("dbo.Students", "Gender", c => c.String(nullable: false));
            AlterColumn("dbo.Students", "Address", c => c.String(nullable: false));
            AlterColumn("dbo.Students", "RegNo", c => c.String(nullable: false));
            DropColumn("dbo.Students", "EmailAddress");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Students", "EmailAddress", c => c.String());
            AlterColumn("dbo.Students", "RegNo", c => c.String());
            AlterColumn("dbo.Students", "Address", c => c.String());
            AlterColumn("dbo.Students", "Gender", c => c.String());
            AlterColumn("dbo.Students", "LastName", c => c.String());
            AlterColumn("dbo.Students", "FirstName", c => c.String());
            AlterColumn("dbo.Courses", "CourseCode", c => c.String());
            AlterColumn("dbo.Courses", "CourseName", c => c.String());
            DropColumn("dbo.Students", "ConfirmPassword");
            DropColumn("dbo.Students", "Password");
            DropColumn("dbo.Students", "Email");
        }
    }
}
