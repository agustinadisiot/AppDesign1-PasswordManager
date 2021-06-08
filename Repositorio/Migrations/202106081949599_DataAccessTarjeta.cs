namespace Repositorio.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class DataAccessTarjeta : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Tarjetas", "Categoria_Id", "dbo.Categorias");
            DropForeignKey("dbo.ClaveCompartidas", "Clave_Id", "dbo.Claves");
            DropForeignKey("dbo.ClaveCompartidas", "Destino_Id", "dbo.Usuarios");
            DropForeignKey("dbo.ClaveCompartidas", "Original_Id", "dbo.Usuarios");
            DropForeignKey("dbo.ClaveCompartidas", "Usuario_Id", "dbo.Usuarios");
            DropForeignKey("dbo.ClaveCompartidas", "Usuario_Id1", "dbo.Usuarios");
            DropForeignKey("dbo.Claves", "DataBreach_Id", "dbo.DataBreaches");
            DropForeignKey("dbo.Tarjetas", "DataBreach_Id", "dbo.DataBreaches");
            DropForeignKey("dbo.DataBreaches", "Usuario_Id", "dbo.Usuarios");
            DropForeignKey("dbo.Tarjetas", "Usuario_Id", "dbo.Usuarios");
            DropIndex("dbo.Tarjetas", new[] { "Categoria_Id" });
            DropIndex("dbo.Tarjetas", new[] { "DataBreach_Id" });
            DropIndex("dbo.Tarjetas", new[] { "Usuario_Id" });
            DropIndex("dbo.ClaveCompartidas", new[] { "Clave_Id" });
            DropIndex("dbo.ClaveCompartidas", new[] { "Destino_Id" });
            DropIndex("dbo.ClaveCompartidas", new[] { "Original_Id" });
            DropIndex("dbo.ClaveCompartidas", new[] { "Usuario_Id" });
            DropIndex("dbo.ClaveCompartidas", new[] { "Usuario_Id1" });
            DropIndex("dbo.Claves", new[] { "DataBreach_Id" });
            DropIndex("dbo.DataBreaches", new[] { "Usuario_Id" });
            DropColumn("dbo.Tarjetas", "Categoria_Id");
            DropColumn("dbo.Tarjetas", "DataBreach_Id");
            DropColumn("dbo.Tarjetas", "Usuario_Id");
            DropTable("dbo.Categorias");
            DropTable("dbo.Usuarios");
            DropTable("dbo.ClaveCompartidas");
            DropTable("dbo.Claves");
            DropTable("dbo.DataBreaches");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.DataBreaches",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Fecha = c.DateTime(nullable: false),
                        Usuario_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id);
            
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
                        DataBreach_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.ClaveCompartidas",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Clave_Id = c.Int(),
                        Destino_Id = c.Int(),
                        Original_Id = c.Int(),
                        Usuario_Id = c.Int(),
                        Usuario_Id1 = c.Int(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Usuarios",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Nombre = c.String(),
                        ClaveMaestra = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Categorias",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Nombre = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            AddColumn("dbo.Tarjetas", "Usuario_Id", c => c.Int());
            AddColumn("dbo.Tarjetas", "DataBreach_Id", c => c.Int());
            AddColumn("dbo.Tarjetas", "Categoria_Id", c => c.Int());
            CreateIndex("dbo.DataBreaches", "Usuario_Id");
            CreateIndex("dbo.Claves", "DataBreach_Id");
            CreateIndex("dbo.ClaveCompartidas", "Usuario_Id1");
            CreateIndex("dbo.ClaveCompartidas", "Usuario_Id");
            CreateIndex("dbo.ClaveCompartidas", "Original_Id");
            CreateIndex("dbo.ClaveCompartidas", "Destino_Id");
            CreateIndex("dbo.ClaveCompartidas", "Clave_Id");
            CreateIndex("dbo.Tarjetas", "Usuario_Id");
            CreateIndex("dbo.Tarjetas", "DataBreach_Id");
            CreateIndex("dbo.Tarjetas", "Categoria_Id");
            AddForeignKey("dbo.Tarjetas", "Usuario_Id", "dbo.Usuarios", "Id");
            AddForeignKey("dbo.DataBreaches", "Usuario_Id", "dbo.Usuarios", "Id");
            AddForeignKey("dbo.Tarjetas", "DataBreach_Id", "dbo.DataBreaches", "Id");
            AddForeignKey("dbo.Claves", "DataBreach_Id", "dbo.DataBreaches", "Id");
            AddForeignKey("dbo.ClaveCompartidas", "Usuario_Id1", "dbo.Usuarios", "Id");
            AddForeignKey("dbo.ClaveCompartidas", "Usuario_Id", "dbo.Usuarios", "Id");
            AddForeignKey("dbo.ClaveCompartidas", "Original_Id", "dbo.Usuarios", "Id");
            AddForeignKey("dbo.ClaveCompartidas", "Destino_Id", "dbo.Usuarios", "Id");
            AddForeignKey("dbo.ClaveCompartidas", "Clave_Id", "dbo.Claves", "Id");
            AddForeignKey("dbo.Tarjetas", "Categoria_Id", "dbo.Categorias", "Id");
        }
    }
}
