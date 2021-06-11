namespace Repositorio.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AgregadoFiltradasYDataBreachADB : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Claves", "DataBreach_Id", "dbo.DataBreaches");
            DropForeignKey("dbo.Tarjetas", "DataBreach_Id", "dbo.DataBreaches");
            DropIndex("dbo.Claves", new[] { "DataBreach_Id" });
            DropIndex("dbo.Tarjetas", new[] { "DataBreach_Id" });
            CreateTable(
                "dbo.Filtradas",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Texto = c.String(nullable: false),
                        DataBreach_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.DataBreaches", t => t.DataBreach_Id, cascadeDelete: true)
                .Index(t => t.DataBreach_Id);
            
            AlterColumn("dbo.Claves", "DataBreach_Id", c => c.Int(nullable: false));
            AlterColumn("dbo.Tarjetas", "DataBreach_Id", c => c.Int(nullable: false));
            CreateIndex("dbo.Claves", "DataBreach_Id");
            CreateIndex("dbo.Tarjetas", "DataBreach_Id");
            AddForeignKey("dbo.Claves", "DataBreach_Id", "dbo.DataBreaches", "Id", cascadeDelete: true);
            AddForeignKey("dbo.Tarjetas", "DataBreach_Id", "dbo.DataBreaches", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Tarjetas", "DataBreach_Id", "dbo.DataBreaches");
            DropForeignKey("dbo.Claves", "DataBreach_Id", "dbo.DataBreaches");
            DropForeignKey("dbo.Filtradas", "DataBreach_Id", "dbo.DataBreaches");
            DropIndex("dbo.Tarjetas", new[] { "DataBreach_Id" });
            DropIndex("dbo.Filtradas", new[] { "DataBreach_Id" });
            DropIndex("dbo.Claves", new[] { "DataBreach_Id" });
            AlterColumn("dbo.Tarjetas", "DataBreach_Id", c => c.Int());
            AlterColumn("dbo.Claves", "DataBreach_Id", c => c.Int());
            DropTable("dbo.Filtradas");
            CreateIndex("dbo.Tarjetas", "DataBreach_Id");
            CreateIndex("dbo.Claves", "DataBreach_Id");
            AddForeignKey("dbo.Tarjetas", "DataBreach_Id", "dbo.DataBreaches", "Id");
            AddForeignKey("dbo.Claves", "DataBreach_Id", "dbo.DataBreaches", "Id");
        }
    }
}
