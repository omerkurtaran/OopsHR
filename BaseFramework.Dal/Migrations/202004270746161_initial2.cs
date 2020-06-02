namespace BaseFramework.Dal.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class initial2 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.EmployeeOtherInfoes", "CompanyID", "dbo.CompanyBranches");
            DropForeignKey("dbo.EmployeeOtherInfoes", "CompanyDepartmentId", "dbo.CompanyDepartments");
            DropForeignKey("dbo.EmployeeOtherInfoes", "CompanyTitleId", "dbo.CompanyTitles");
            DropIndex("dbo.EmployeeOtherInfoes", new[] { "CompanyID" });
            DropIndex("dbo.EmployeeOtherInfoes", new[] { "CompanyTitleId" });
            DropIndex("dbo.EmployeeOtherInfoes", new[] { "CompanyDepartmentId" });
            AddColumn("dbo.Employees", "CompanyID", c => c.Int());
            AddColumn("dbo.Employees", "CompanyTitleId", c => c.Int());
            AddColumn("dbo.Employees", "CompanyDepartmentId", c => c.Int());
            CreateIndex("dbo.Employees", "CompanyID");
            CreateIndex("dbo.Employees", "CompanyTitleId");
            CreateIndex("dbo.Employees", "CompanyDepartmentId");
            AddForeignKey("dbo.Employees", "CompanyID", "dbo.CompanyBranches", "Id");
            AddForeignKey("dbo.Employees", "CompanyDepartmentId", "dbo.CompanyDepartments", "Id");
            AddForeignKey("dbo.Employees", "CompanyTitleId", "dbo.CompanyTitles", "Id");
            DropColumn("dbo.EmployeeOtherInfoes", "CompanyID");
            DropColumn("dbo.EmployeeOtherInfoes", "CompanyTitleId");
            DropColumn("dbo.EmployeeOtherInfoes", "CompanyDepartmentId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.EmployeeOtherInfoes", "CompanyDepartmentId", c => c.Int());
            AddColumn("dbo.EmployeeOtherInfoes", "CompanyTitleId", c => c.Int());
            AddColumn("dbo.EmployeeOtherInfoes", "CompanyID", c => c.Int());
            DropForeignKey("dbo.Employees", "CompanyTitleId", "dbo.CompanyTitles");
            DropForeignKey("dbo.Employees", "CompanyDepartmentId", "dbo.CompanyDepartments");
            DropForeignKey("dbo.Employees", "CompanyID", "dbo.CompanyBranches");
            DropIndex("dbo.Employees", new[] { "CompanyDepartmentId" });
            DropIndex("dbo.Employees", new[] { "CompanyTitleId" });
            DropIndex("dbo.Employees", new[] { "CompanyID" });
            DropColumn("dbo.Employees", "CompanyDepartmentId");
            DropColumn("dbo.Employees", "CompanyTitleId");
            DropColumn("dbo.Employees", "CompanyID");
            CreateIndex("dbo.EmployeeOtherInfoes", "CompanyDepartmentId");
            CreateIndex("dbo.EmployeeOtherInfoes", "CompanyTitleId");
            CreateIndex("dbo.EmployeeOtherInfoes", "CompanyID");
            AddForeignKey("dbo.EmployeeOtherInfoes", "CompanyTitleId", "dbo.CompanyTitles", "Id");
            AddForeignKey("dbo.EmployeeOtherInfoes", "CompanyDepartmentId", "dbo.CompanyDepartments", "Id");
            AddForeignKey("dbo.EmployeeOtherInfoes", "CompanyID", "dbo.CompanyBranches", "Id");
        }
    }
}
