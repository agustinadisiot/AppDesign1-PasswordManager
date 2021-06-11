namespace Repositorio.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RelacionNaNDataBreach : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Claves", "DataBreach_Id", "dbo.DataBreaches");
            DropForeignKey("dbo.Filtradas", "DataBreach_Id", "dbo.DataBreaches");
            DropForeignKey("dbo.Tarjetas", "DataBreach_Id", "dbo.DataBreaches");
            DropIndex("dbo.Claves", new[] { "DataBreach_Id" });
            DropIndex("dbo.Filtradas", new[] { "DataBreach_Id" });
            DropIndex("dbo.Tarjetas", new[] { "DataBreach_Id" });
            CreateTable(
                "dbo.DataBreachClaves",
                c => new
                    {
                        DataBreachesRefId = c.Int(nullable: false),
                        ClavesRefId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.DataBreachesRefId, t.ClavesRefId })
                .ForeignKey("dbo.DataBreaches", t => t.DataBreachesRefId, cascadeDelete: true)
                .ForeignKey("dbo.Claves", t => t.ClavesRefId, cascadeDelete: true)
                .Index(t => t.DataBreachesRefId)
                .Index(t => t.ClavesRefId);
            
            CreateTable(
                "dbo.DataBreachFiltradas",
                c => new
                    {
                        DataBreachesRefId = c.Int(nullable: false),
                        FiltradasRefId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.DataBreachesRefId, t.FiltradasRefId })
                .ForeignKey("dbo.DataBreaches", t => t.DataBreachesRefId, cascadeDelete: true)
                .ForeignKey("dbo.Filtradas", t => t.FiltradasRefId, cascadeDelete: true)
                .Index(t => t.DataBreachesRefId)
                .Index(t => t.FiltradasRefId);
            
            CreateTable(
                "dbo.DataBreachTarjetas",
                c => new
                    {
                        DataBreachesRefId = c.Int(nullable: false),
                        TarjetasRefId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.DataBreachesRefId, t.TarjetasRefId })
                .ForeignKey("dbo.DataBreaches", t => t.DataBreachesRefId, cascadeDelete: true)
                .ForeignKey("dbo.Tarjetas", t => t.TarjetasRefId, cascadeDelete: true)
                .Index(t => t.DataBreachesRefId)
                .Index(t => t.TarjetasRefId);
            
            DropColumn("dbo.Claves", "DataBreach_Id");
            DropColumn("dbo.Filtradas", "DataBreach_Id");
            DropColumn("dbo.Tarjetas", "DataBreach_Id");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Tarjetas", "DataBreach_Id", c => c.Int());
            AddColumn("dbo.Filtradas", "DataBreach_Id", c => c.Int());
            AddColumn("dbo.Claves", "DataBreach_Id", c => c.Int());
            DropForeignKey("dbo.DataBreachTarjetas", "TarjetasRefId", "dbo.Tarjetas");
            DropForeignKey("dbo.DataBreachTarjetas", "DataBreachesRefId", "dbo.DataBreaches");
            DropForeignKey("dbo.DataBreachFiltradas", "FiltradasRefId", "dbo.Filtradas");
            DropForeignKey("dbo.DataBreachFiltradas", "DataBreachesRefId", "dbo.DataBreaches");
            DropForeignKey("dbo.DataBreachClaves", "ClavesRefId", "dbo.Claves");
            DropForeignKey("dbo.DataBreachClaves", "DataBreachesRefId", "dbo.DataBreaches");
            DropIndex("dbo.DataBreachTarjetas", new[] { "TarjetasRefId" });
            DropIndex("dbo.DataBreachTarjetas", new[] { "DataBreachesRefId" });
            DropIndex("dbo.DataBreachFiltradas", new[] { "FiltradasRefId" });
            DropIndex("dbo.DataBreachFiltradas", new[] { "DataBreachesRefId" });
            DropIndex("dbo.DataBreachClaves", new[] { "ClavesRefId" });
            DropIndex("dbo.DataBreachClaves", new[] { "DataBreachesRefId" });
            DropTable("dbo.DataBreachTarjetas");
            DropTable("dbo.DataBreachFiltradas");
            DropTable("dbo.DataBreachClaves");
            CreateIndex("dbo.Tarjetas", "DataBreach_Id");
            CreateIndex("dbo.Filtradas", "DataBreach_Id");
            CreateIndex("dbo.Claves", "DataBreach_Id");
            AddForeignKey("dbo.Tarjetas", "DataBreach_Id", "dbo.DataBreaches", "Id");
            AddForeignKey("dbo.Filtradas", "DataBreach_Id", "dbo.DataBreaches", "Id");
            AddForeignKey("dbo.Claves", "DataBreach_Id", "dbo.DataBreaches", "Id");
        }
    }
}
