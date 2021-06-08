namespace Repositorio.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AgregadoTypeConfigurationTarjeta : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Tarjetas", "Nombre", c => c.String(maxLength: 25));
            AlterColumn("dbo.Tarjetas", "Tipo", c => c.String(maxLength: 25));
            AlterColumn("dbo.Tarjetas", "Numero", c => c.String(nullable: false, maxLength: 16));
            AlterColumn("dbo.Tarjetas", "Codigo", c => c.String(maxLength: 4));
            AlterColumn("dbo.Tarjetas", "Nota", c => c.String(maxLength: 250));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Tarjetas", "Nota", c => c.String());
            AlterColumn("dbo.Tarjetas", "Codigo", c => c.String());
            AlterColumn("dbo.Tarjetas", "Numero", c => c.String());
            AlterColumn("dbo.Tarjetas", "Tipo", c => c.String());
            AlterColumn("dbo.Tarjetas", "Nombre", c => c.String());
        }
    }
}
