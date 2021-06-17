using Negocio;
using System.Data.Entity.ModelConfiguration;

namespace Repositorio
{
    class UsuarioTypeConfiguration : EntityTypeConfiguration<Usuario>
    {
        public UsuarioTypeConfiguration()
        {
            this.HasKey(x => x.Id);
            this.Property(x => x.Nombre).IsRequired();
            this.Property(x => x.ClaveMaestra).IsRequired();
            this.HasMany<Categoria>(usuario => usuario.Categorias);
            this.HasMany<DataBreach>(usuario => usuario.DataBreaches);
            this.HasMany<ClaveCompartida>(usuario => usuario.CompartidasConmigo)
                .WithRequired(cc => cc.Destino)
                .WillCascadeOnDelete(false);
            this.HasMany<ClaveCompartida>(usuario => usuario.CompartidasPorMi)
                .WithRequired(cc => cc.Original)
                .WillCascadeOnDelete(false);
        }
    }
}
