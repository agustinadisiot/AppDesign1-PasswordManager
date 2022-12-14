using Negocio;
using System.Data.Entity.ModelConfiguration;

namespace Repositorio
{
    class ClaveTypeConfiguration : EntityTypeConfiguration<Clave>
    {
        public ClaveTypeConfiguration()
        {
            this.HasKey(x => x.Id);
            this.Property(x => x.Sitio).IsRequired();
            this.Property(x => x.Sitio).HasMaxLength(25);
            this.Property(x => x.UsuarioClave).IsRequired();
            this.Property(x => x.UsuarioClave).HasMaxLength(25);
            this.Property(x => x.Codigo).IsRequired();
            this.Property(x => x.Nota).HasMaxLength(250);
            this.Property(x => x.FechaModificacion).IsRequired();
            this.Property(x => x.EsCompartida).IsRequired();
        }
    }
}
