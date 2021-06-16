using Negocio;
using System.Data.Entity.ModelConfiguration;

namespace Repositorio
{
    class FiltradaTypeConfiguration : EntityTypeConfiguration<Filtrada>
    {
        public FiltradaTypeConfiguration()
        {
            this.HasKey(x => x.Id);
            this.Property(x => x.Texto).IsRequired();
        }
    }
}
