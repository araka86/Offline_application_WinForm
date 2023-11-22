namespace CartrigeAltstar.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate3 : DbMigration
    {
        public override void Up()
        {
            DropTable("dbo.Dispatches");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.Dispatches",
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
