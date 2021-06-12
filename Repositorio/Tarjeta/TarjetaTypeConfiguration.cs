using Negocio;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositorio
{
    class TarjetaTypeConfiguration : EntityTypeConfiguration<Tarjeta>
    {
        public TarjetaTypeConfiguration() {
            this.HasKey(x => x.Id);
            this.Property(x => x.Numero).IsRequired();
            this.Property(x => x.Numero).HasMaxLength(16);
            this.Property(x => x.Nombre).HasMaxLength(25);
            this.Property(x => x.Tipo).HasMaxLength(25);
            this.Property(x => x.Codigo).HasMaxLength(4);
            this.Property(x => x.Nota).HasMaxLength(250);
        }
    }
}
