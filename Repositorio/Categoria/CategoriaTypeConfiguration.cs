using Negocio;
using System.Data.Entity.ModelConfiguration;

namespace Repositorio
{
    class CategoriaTypeConfiguration: EntityTypeConfiguration<Categoria>
    {
        public CategoriaTypeConfiguration()
        {
            this.HasKey(x => x.Id);
            this.Property(x => x.Nombre).IsRequired();
            this.HasMany<Tarjeta>(ca => ca.Tarjetas);
            this.HasMany<Clave>(ca => ca.Claves);
        }
    }
}
