namespace Repositorio.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AgregadoTypeConfigurationClave : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Claves", "EsCompartida", c => c.Boolean(nullable: false));
            AlterColumn("dbo.Claves", "UsuarioClave", c => c.String(nullable: false, maxLength: 25));
            AlterColumn("dbo.Claves", "Codigo", c => c.String(nullable: false, maxLength: 25));
            AlterColumn("dbo.Claves", "Sitio", c => c.String(nullable: false, maxLength: 25));
            AlterColumn("dbo.Claves", "Nota", c => c.String(maxLength: 250));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Claves", "Nota", c => c.String());
            AlterColumn("dbo.Claves", "Sitio", c => c.String());
            AlterColumn("dbo.Claves", "Codigo", c => c.String());
            AlterColumn("dbo.Claves", "UsuarioClave", c => c.String());
            DropColumn("dbo.Claves", "EsCompartida");
        }
    }
}
