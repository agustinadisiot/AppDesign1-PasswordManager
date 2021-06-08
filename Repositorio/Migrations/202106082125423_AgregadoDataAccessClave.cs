namespace Repositorio.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AgregadoDataAccessClave : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Claves",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UsuarioClave = c.String(),
                        Codigo = c.String(),
                        Sitio = c.String(),
                        Nota = c.String(),
                        FechaModificacion = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Claves");
        }
    }
}
