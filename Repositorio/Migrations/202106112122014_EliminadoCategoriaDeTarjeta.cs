namespace Repositorio.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class EliminadoCategoriaDeTarjeta : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Tarjetas", "CategoriaId", "dbo.Categorias");
            DropIndex("dbo.Tarjetas", new[] { "CategoriaId" });
            RenameColumn(table: "dbo.Tarjetas", name: "CategoriaId", newName: "Categoria_Id");
            AlterColumn("dbo.Tarjetas", "Categoria_Id", c => c.Int());
            CreateIndex("dbo.Tarjetas", "Categoria_Id");
            AddForeignKey("dbo.Tarjetas", "Categoria_Id", "dbo.Categorias", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Tarjetas", "Categoria_Id", "dbo.Categorias");
            DropIndex("dbo.Tarjetas", new[] { "Categoria_Id" });
            AlterColumn("dbo.Tarjetas", "Categoria_Id", c => c.Int(nullable: false));
            RenameColumn(table: "dbo.Tarjetas", name: "Categoria_Id", newName: "CategoriaId");
            CreateIndex("dbo.Tarjetas", "CategoriaId");
            AddForeignKey("dbo.Tarjetas", "CategoriaId", "dbo.Categorias", "Id", cascadeDelete: true);
        }
    }
}
