namespace Repositorio.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class EliminadoDataBreachTypeConfigurationDeModelCreating : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Claves", "DataBreach_Id", "dbo.DataBreaches");
            DropForeignKey("dbo.Filtradas", "DataBreach_Id", "dbo.DataBreaches");
            DropForeignKey("dbo.Tarjetas", "DataBreach_Id", "dbo.DataBreaches");
            DropIndex("dbo.Claves", new[] { "DataBreach_Id" });
            DropIndex("dbo.Filtradas", new[] { "DataBreach_Id" });
            DropIndex("dbo.Tarjetas", new[] { "DataBreach_Id" });
            AlterColumn("dbo.Claves", "DataBreach_Id", c => c.Int());
            AlterColumn("dbo.Filtradas", "DataBreach_Id", c => c.Int());
            AlterColumn("dbo.Tarjetas", "DataBreach_Id", c => c.Int());
            CreateIndex("dbo.Claves", "DataBreach_Id");
            CreateIndex("dbo.Filtradas", "DataBreach_Id");
            CreateIndex("dbo.Tarjetas", "DataBreach_Id");
            AddForeignKey("dbo.Claves", "DataBreach_Id", "dbo.DataBreaches", "Id");
            AddForeignKey("dbo.Filtradas", "DataBreach_Id", "dbo.DataBreaches", "Id");
            AddForeignKey("dbo.Tarjetas", "DataBreach_Id", "dbo.DataBreaches", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Tarjetas", "DataBreach_Id", "dbo.DataBreaches");
            DropForeignKey("dbo.Filtradas", "DataBreach_Id", "dbo.DataBreaches");
            DropForeignKey("dbo.Claves", "DataBreach_Id", "dbo.DataBreaches");
            DropIndex("dbo.Tarjetas", new[] { "DataBreach_Id" });
            DropIndex("dbo.Filtradas", new[] { "DataBreach_Id" });
            DropIndex("dbo.Claves", new[] { "DataBreach_Id" });
            AlterColumn("dbo.Tarjetas", "DataBreach_Id", c => c.Int(nullable: false));
            AlterColumn("dbo.Filtradas", "DataBreach_Id", c => c.Int(nullable: false));
            AlterColumn("dbo.Claves", "DataBreach_Id", c => c.Int(nullable: false));
            CreateIndex("dbo.Tarjetas", "DataBreach_Id");
            CreateIndex("dbo.Filtradas", "DataBreach_Id");
            CreateIndex("dbo.Claves", "DataBreach_Id");
            AddForeignKey("dbo.Tarjetas", "DataBreach_Id", "dbo.DataBreaches", "Id", cascadeDelete: true);
            AddForeignKey("dbo.Filtradas", "DataBreach_Id", "dbo.DataBreaches", "Id", cascadeDelete: true);
            AddForeignKey("dbo.Claves", "DataBreach_Id", "dbo.DataBreaches", "Id", cascadeDelete: true);
        }
    }
}
