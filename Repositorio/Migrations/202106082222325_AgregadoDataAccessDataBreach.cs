namespace Repositorio.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AgregadoDataAccessDataBreach : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.DataBreaches",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Fecha = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            AddColumn("dbo.Claves", "DataBreach_Id", c => c.Int());
            AddColumn("dbo.Tarjetas", "DataBreach_Id", c => c.Int());
            CreateIndex("dbo.Claves", "DataBreach_Id");
            CreateIndex("dbo.Tarjetas", "DataBreach_Id");
            AddForeignKey("dbo.Claves", "DataBreach_Id", "dbo.DataBreaches", "Id");
            AddForeignKey("dbo.Tarjetas", "DataBreach_Id", "dbo.DataBreaches", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Tarjetas", "DataBreach_Id", "dbo.DataBreaches");
            DropForeignKey("dbo.Claves", "DataBreach_Id", "dbo.DataBreaches");
            DropIndex("dbo.Tarjetas", new[] { "DataBreach_Id" });
            DropIndex("dbo.Claves", new[] { "DataBreach_Id" });
            DropColumn("dbo.Tarjetas", "DataBreach_Id");
            DropColumn("dbo.Claves", "DataBreach_Id");
            DropTable("dbo.DataBreaches");
        }
    }
}
