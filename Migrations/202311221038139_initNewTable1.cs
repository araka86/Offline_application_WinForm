namespace CartrigeAltstar.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class initNewTable1 : DbMigration
    {
        public override void Up()
        {
            DropTable("dbo.Currents");
        }
        
        public override void Down()
        {
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
            
        }
    }
}
