namespace Repositorio.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CreadoDBContext : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Tarjetas",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Nombre = c.String(),
                        Tipo = c.String(),
                        Numero = c.String(),
                        Codigo = c.String(),
                        Vencimiento = c.DateTime(nullable: false),
                        Nota = c.String(),
                        Categoria_Id = c.Int(),
                        DataBreach_Id = c.Int(),
                        Usuario_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Categorias", t => t.Categoria_Id)
                .ForeignKey("dbo.DataBreaches", t => t.DataBreach_Id)
                .ForeignKey("dbo.Usuarios", t => t.Usuario_Id)
                .Index(t => t.Categoria_Id)
                .Index(t => t.DataBreach_Id)
                .Index(t => t.Usuario_Id);
            
            CreateTable(
                "dbo.Categorias",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Nombre = c.String(),
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
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Claves", t => t.Clave_Id)
                .ForeignKey("dbo.Usuarios", t => t.Destino_Id)
                .ForeignKey("dbo.Usuarios", t => t.Original_Id)
                .ForeignKey("dbo.Usuarios", t => t.Usuario_Id)
                .ForeignKey("dbo.Usuarios", t => t.Usuario_Id1)
                .Index(t => t.Clave_Id)
                .Index(t => t.Destino_Id)
                .Index(t => t.Original_Id)
                .Index(t => t.Usuario_Id)
                .Index(t => t.Usuario_Id1);
            
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
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.DataBreaches", t => t.DataBreach_Id)
                .Index(t => t.DataBreach_Id);
            
            CreateTable(
                "dbo.DataBreaches",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Fecha = c.DateTime(nullable: false),
                        Usuario_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Usuarios", t => t.Usuario_Id)
                .Index(t => t.Usuario_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Tarjetas", "Usuario_Id", "dbo.Usuarios");
            DropForeignKey("dbo.DataBreaches", "Usuario_Id", "dbo.Usuarios");
            DropForeignKey("dbo.Tarjetas", "DataBreach_Id", "dbo.DataBreaches");
            DropForeignKey("dbo.Claves", "DataBreach_Id", "dbo.DataBreaches");
            DropForeignKey("dbo.ClaveCompartidas", "Usuario_Id1", "dbo.Usuarios");
            DropForeignKey("dbo.ClaveCompartidas", "Usuario_Id", "dbo.Usuarios");
            DropForeignKey("dbo.ClaveCompartidas", "Original_Id", "dbo.Usuarios");
            DropForeignKey("dbo.ClaveCompartidas", "Destino_Id", "dbo.Usuarios");
            DropForeignKey("dbo.ClaveCompartidas", "Clave_Id", "dbo.Claves");
            DropForeignKey("dbo.Tarjetas", "Categoria_Id", "dbo.Categorias");
            DropIndex("dbo.DataBreaches", new[] { "Usuario_Id" });
            DropIndex("dbo.Claves", new[] { "DataBreach_Id" });
            DropIndex("dbo.ClaveCompartidas", new[] { "Usuario_Id1" });
            DropIndex("dbo.ClaveCompartidas", new[] { "Usuario_Id" });
            DropIndex("dbo.ClaveCompartidas", new[] { "Original_Id" });
            DropIndex("dbo.ClaveCompartidas", new[] { "Destino_Id" });
            DropIndex("dbo.ClaveCompartidas", new[] { "Clave_Id" });
            DropIndex("dbo.Tarjetas", new[] { "Usuario_Id" });
            DropIndex("dbo.Tarjetas", new[] { "DataBreach_Id" });
            DropIndex("dbo.Tarjetas", new[] { "Categoria_Id" });
            DropTable("dbo.DataBreaches");
            DropTable("dbo.Claves");
            DropTable("dbo.ClaveCompartidas");
            DropTable("dbo.Usuarios");
            DropTable("dbo.Categorias");
            DropTable("dbo.Tarjetas");
        }
    }
}
