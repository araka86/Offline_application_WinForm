namespace CartrigeAltstar.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class initNewTable : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Cartrigelolocations",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Data = c.DateTime(),
                        Cartrige = c.String(),
                        Article = c.String(),
                        Weight = c.Double(nullable: false),
                        Status = c.String(),
                        Department = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Cartriges",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ModelCartrige = c.String(),
                        ArticleCartrige = c.String(),
                        purchase_date = c.DateTime(),
                        IsService = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Compatibilities",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        SubdivisionId = c.Int(),
                        CartrigeId = c.Int(),
                    })
                .PrimaryKey(t => t.id)
                .ForeignKey("dbo.Cartriges", t => t.CartrigeId)
                .ForeignKey("dbo.Subdivisions", t => t.SubdivisionId)
                .Index(t => t.SubdivisionId)
                .Index(t => t.CartrigeId);
            
            CreateTable(
                "dbo.Subdivisions",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Address = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Printers",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        DateTimes = c.DateTime(),
                        ModelPrinter = c.String(),
                        Article = c.String(),
                        SubdivisionId = c.Int(),
                        CartrigeId = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Cartriges", t => t.CartrigeId)
                .ForeignKey("dbo.Subdivisions", t => t.SubdivisionId)
                .Index(t => t.SubdivisionId)
                .Index(t => t.CartrigeId);
            
            CreateTable(
                "dbo.Currents",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        Дата = c.DateTime(),
                        Картридж = c.String(),
                        Вес = c.Double(nullable: false),
                        Заметки = c.String(),
                        Подразделения = c.String(),
                    })
                .PrimaryKey(t => t.id);
            
            CreateTable(
                "dbo.Users",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        FirstName = c.String(),
                        LasttName = c.String(),
                        LoginId = c.String(),
                        Role = c.String(),
                        UniqId = c.Int(nullable: false),
                        Password = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Printers", "SubdivisionId", "dbo.Subdivisions");
            DropForeignKey("dbo.Printers", "CartrigeId", "dbo.Cartriges");
            DropForeignKey("dbo.Compatibilities", "SubdivisionId", "dbo.Subdivisions");
            DropForeignKey("dbo.Compatibilities", "CartrigeId", "dbo.Cartriges");
            DropIndex("dbo.Printers", new[] { "CartrigeId" });
            DropIndex("dbo.Printers", new[] { "SubdivisionId" });
            DropIndex("dbo.Compatibilities", new[] { "CartrigeId" });
            DropIndex("dbo.Compatibilities", new[] { "SubdivisionId" });
            DropTable("dbo.Users");
            DropTable("dbo.Currents");
            DropTable("dbo.Printers");
            DropTable("dbo.Subdivisions");
            DropTable("dbo.Compatibilities");
            DropTable("dbo.Cartriges");
            DropTable("dbo.Cartrigelolocations");
        }
    }
}
