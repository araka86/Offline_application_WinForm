namespace CartrigeAltstar.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class initNewTable2 : DbMigration
    {
        public override void Up()
        {
            RenameTable(name: "dbo.Subdivisions", newName: "Departments");
            DropForeignKey("dbo.Compatibilities", "SubdivisionId", "dbo.Subdivisions");
            DropForeignKey("dbo.Printers", "SubdivisionId", "dbo.Subdivisions");
            DropIndex("dbo.Compatibilities", new[] { "SubdivisionId" });
            DropIndex("dbo.Printers", new[] { "SubdivisionId" });
            AddColumn("dbo.Compatibilities", "SubdivisionPK_Id", c => c.Int());
            AddColumn("dbo.Printers", "SubdivisioPK_Id", c => c.Int());
            CreateIndex("dbo.Compatibilities", "SubdivisionPK_Id");
            CreateIndex("dbo.Printers", "SubdivisioPK_Id");
            AddForeignKey("dbo.Compatibilities", "SubdivisionPK_Id", "dbo.Departments", "Id");
            AddForeignKey("dbo.Printers", "SubdivisioPK_Id", "dbo.Departments", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Printers", "SubdivisioPK_Id", "dbo.Departments");
            DropForeignKey("dbo.Compatibilities", "SubdivisionPK_Id", "dbo.Departments");
            DropIndex("dbo.Printers", new[] { "SubdivisioPK_Id" });
            DropIndex("dbo.Compatibilities", new[] { "SubdivisionPK_Id" });
            DropColumn("dbo.Printers", "SubdivisioPK_Id");
            DropColumn("dbo.Compatibilities", "SubdivisionPK_Id");
            CreateIndex("dbo.Printers", "SubdivisionId");
            CreateIndex("dbo.Compatibilities", "SubdivisionId");
            AddForeignKey("dbo.Printers", "SubdivisionId", "dbo.Subdivisions", "Id");
            AddForeignKey("dbo.Compatibilities", "SubdivisionId", "dbo.Subdivisions", "Id");
            RenameTable(name: "dbo.Departments", newName: "Subdivisions");
        }
    }
}
