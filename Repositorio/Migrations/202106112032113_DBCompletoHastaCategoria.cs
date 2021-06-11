namespace Repositorio.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class DBCompletoHastaCategoria : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Categorias",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Nombre = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Claves",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        CategoriaId = c.Int(nullable: false),
                        UsuarioClave = c.String(nullable: false, maxLength: 25),
                        Codigo = c.String(nullable: false, maxLength: 25),
                        EsCompartida = c.Boolean(nullable: false),
                        Sitio = c.String(nullable: false, maxLength: 25),
                        Nota = c.String(maxLength: 250),
                        FechaModificacion = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Categorias", t => t.CategoriaId, cascadeDelete: true)
                .Index(t => t.CategoriaId);
            
            CreateTable(
                "dbo.DataBreaches",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Fecha = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Filtradas",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Texto = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Tarjetas",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        CategoriaId = c.Int(nullable: false),
                        Nombre = c.String(maxLength: 25),
                        Tipo = c.String(maxLength: 25),
                        Numero = c.String(nullable: false, maxLength: 16),
                        Codigo = c.String(maxLength: 4),
                        Vencimiento = c.DateTime(nullable: false),
                        Nota = c.String(maxLength: 250),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Categorias", t => t.CategoriaId, cascadeDelete: true)
                .Index(t => t.CategoriaId);
            
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
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Tarjetas", "CategoriaId", "dbo.Categorias");
            DropForeignKey("dbo.Claves", "CategoriaId", "dbo.Categorias");
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
            DropIndex("dbo.Tarjetas", new[] { "CategoriaId" });
            DropIndex("dbo.Claves", new[] { "CategoriaId" });
            DropTable("dbo.DataBreachTarjetas");
            DropTable("dbo.DataBreachFiltradas");
            DropTable("dbo.DataBreachClaves");
            DropTable("dbo.Tarjetas");
            DropTable("dbo.Filtradas");
            DropTable("dbo.DataBreaches");
            DropTable("dbo.Claves");
            DropTable("dbo.Categorias");
        }
    }
}
