namespace BaseFramework.Dal.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class initial3 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Users", "EmployeeId", c => c.Int());
            CreateIndex("dbo.Users", "EmployeeId");
            AddForeignKey("dbo.Users", "EmployeeId", "dbo.Employees", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Users", "EmployeeId", "dbo.Employees");
            DropIndex("dbo.Users", new[] { "EmployeeId" });
            DropColumn("dbo.Users", "EmployeeId");
        }
    }
}
