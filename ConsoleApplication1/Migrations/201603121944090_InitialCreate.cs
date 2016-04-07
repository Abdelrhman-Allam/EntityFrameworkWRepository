namespace ConsoleApplication1.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Companies",
                c => new
                    {
                        CompanyId = c.Int(nullable: false, identity: true),
                        CompanyName = c.String(),
                        Street = c.String(nullable: false, maxLength: 40),
                        Address_City = c.String(),
                        Address_State = c.String(),
                        Address_Zip = c.String(),
                    })
                .PrimaryKey(t => t.CompanyId);
            
            CreateTable(
                "dbo.PersonBlob",
                c => new
                    {
                        PersonId = c.Int(nullable: false, identity: true),
                        Photo = c.Binary(maxLength: 4000),
                        FamilyPicture = c.Binary(),
                    })
                .PrimaryKey(t => t.PersonId);
            
            CreateTable(
                "dbo.TypeOfPerson",
                c => new
                    {
                        PersonTypeId = c.Int(nullable: false, identity: true),
                        TypeName = c.String(),
                    })
                .PrimaryKey(t => t.PersonTypeId);
            
            CreateTable(
                "dbo.Phones",
                c => new
                    {
                        PhoneId = c.Int(nullable: false, identity: true),
                        PhoneNumber = c.String(),
                        Person_PersonId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.PhoneId)
                .ForeignKey("dbo.PersonBlob", t => t.Person_PersonId)
                .Index(t => t.Person_PersonId);
            
            CreateTable(
                "dbo.Students",
                c => new
                    {
                        PersonId = c.Int(nullable: false),
                        CollageName = c.String(nullable: false, maxLength: 50),
                        EnrollmentDate = c.DateTime(),
                    })
                .PrimaryKey(t => t.PersonId)
                .ForeignKey("dbo.PersonBlob", t => t.PersonId)
                .Index(t => t.PersonId);
            
            CreateTable(
                "dbo.PersonCompanies",
                c => new
                    {
                        PersonId = c.Int(nullable: false),
                        CompanyId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.PersonId, t.CompanyId })
                .ForeignKey("dbo.PersonBlob", t => t.PersonId, cascadeDelete: true)
                .ForeignKey("dbo.Companies", t => t.CompanyId, cascadeDelete: true)
                .Index(t => t.PersonId)
                .Index(t => t.CompanyId);
            
            CreateTable(
                "dbo.Person",
                c => new
                    {
                        PersonId = c.Int(nullable: false),
                        FirstName = c.String(maxLength: 30),
                        LastName = c.String(maxLength: 30),
                        MiddleName = c.String(maxLength: 1, fixedLength: true, unicode: false),
                        BirthDate = c.DateTime(),
                        HeighInFeet = c.Decimal(nullable: false, precision: 4, scale: 2),
                        IsActive = c.Boolean(nullable: false),
                        NumberOfCars = c.Int(nullable: false),
                        PersonTypeId = c.Int(),
                        Street = c.String(nullable: false, maxLength: 40),
                        Address_City = c.String(),
                        Address_State = c.String(),
                        Address_Zip = c.String(),
                        PersonState = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.PersonId)
                .ForeignKey("dbo.TypeOfPerson", t => t.PersonTypeId)
                .ForeignKey("dbo.PersonBlob", t => t.PersonId)
                .Index(t => t.PersonId)
                .Index(t => t.PersonTypeId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Person", "PersonId", "dbo.PersonBlob");
            DropForeignKey("dbo.Person", "PersonTypeId", "dbo.TypeOfPerson");
            DropForeignKey("dbo.Students", "PersonId", "dbo.PersonBlob");
            DropForeignKey("dbo.Phones", "Person_PersonId", "dbo.PersonBlob");
            DropForeignKey("dbo.PersonCompanies", "CompanyId", "dbo.Companies");
            DropForeignKey("dbo.PersonCompanies", "PersonId", "dbo.PersonBlob");
            DropIndex("dbo.Person", new[] { "PersonTypeId" });
            DropIndex("dbo.Person", new[] { "PersonId" });
            DropIndex("dbo.PersonCompanies", new[] { "CompanyId" });
            DropIndex("dbo.PersonCompanies", new[] { "PersonId" });
            DropIndex("dbo.Students", new[] { "PersonId" });
            DropIndex("dbo.Phones", new[] { "Person_PersonId" });
            DropTable("dbo.Person");
            DropTable("dbo.PersonCompanies");
            DropTable("dbo.Students");
            DropTable("dbo.Phones");
            DropTable("dbo.TypeOfPerson");
            DropTable("dbo.PersonBlob");
            DropTable("dbo.Companies");
        }
    }
}
