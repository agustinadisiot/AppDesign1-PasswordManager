namespace Repositorio.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CreadoDataAccessUsuario : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Usuarios",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Nombre = c.String(nullable: false),
                        ClaveMaestra = c.String(nullable: false),
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
            
            AddColumn("dbo.Categorias", "Usuario_Id", c => c.Int());
            AddColumn("dbo.DataBreaches", "Usuario_Id", c => c.Int());
            CreateIndex("dbo.Categorias", "Usuario_Id");
            CreateIndex("dbo.DataBreaches", "Usuario_Id");
            AddForeignKey("dbo.Categorias", "Usuario_Id", "dbo.Usuarios", "Id");
            AddForeignKey("dbo.DataBreaches", "Usuario_Id", "dbo.Usuarios", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.DataBreaches", "Usuario_Id", "dbo.Usuarios");
            DropForeignKey("dbo.ClaveCompartidas", "Usuario_Id1", "dbo.Usuarios");
            DropForeignKey("dbo.ClaveCompartidas", "Usuario_Id", "dbo.Usuarios");
            DropForeignKey("dbo.ClaveCompartidas", "Original_Id", "dbo.Usuarios");
            DropForeignKey("dbo.ClaveCompartidas", "Destino_Id", "dbo.Usuarios");
            DropForeignKey("dbo.ClaveCompartidas", "Clave_Id", "dbo.Claves");
            DropForeignKey("dbo.Categorias", "Usuario_Id", "dbo.Usuarios");
            DropIndex("dbo.ClaveCompartidas", new[] { "Usuario_Id1" });
            DropIndex("dbo.ClaveCompartidas", new[] { "Usuario_Id" });
            DropIndex("dbo.ClaveCompartidas", new[] { "Original_Id" });
            DropIndex("dbo.ClaveCompartidas", new[] { "Destino_Id" });
            DropIndex("dbo.ClaveCompartidas", new[] { "Clave_Id" });
            DropIndex("dbo.DataBreaches", new[] { "Usuario_Id" });
            DropIndex("dbo.Categorias", new[] { "Usuario_Id" });
            DropColumn("dbo.DataBreaches", "Usuario_Id");
            DropColumn("dbo.Categorias", "Usuario_Id");
            DropTable("dbo.ClaveCompartidas");
            DropTable("dbo.Usuarios");
        }
    }
}
