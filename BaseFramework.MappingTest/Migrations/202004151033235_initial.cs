namespace BaseFramework.MappingTest.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class initial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.BankAccountTypeBankInformations",
                c => new
                    {
                        BankAccountType_Id = c.Int(nullable: false),
                        BankInformation_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.BankAccountType_Id, t.BankInformation_Id })
                .ForeignKey("dbo.BankAccountTypes", t => t.BankAccountType_Id, cascadeDelete: true)
                .ForeignKey("dbo.BankInformations", t => t.BankInformation_Id, cascadeDelete: true)
                .Index(t => t.BankAccountType_Id)
                .Index(t => t.BankInformation_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.BankAccountTypeBankInformations", "BankInformation_Id", "dbo.BankInformations");
            DropForeignKey("dbo.BankAccountTypeBankInformations", "BankAccountType_Id", "dbo.BankAccountTypes");
            DropIndex("dbo.BankAccountTypeBankInformations", new[] { "BankInformation_Id" });
            DropIndex("dbo.BankAccountTypeBankInformations", new[] { "BankAccountType_Id" });
            DropTable("dbo.BankAccountTypeBankInformations");
        }
    }
}
