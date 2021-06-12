using LogicaDeNegocio;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositorio
{
    class ClaveTypeConfiguration : EntityTypeConfiguration<ControladoraClave>
    {
        public ClaveTypeConfiguration()
        {
            this.HasKey(x => x.Id);
            this.Property(x => x.VerificarSitio).IsRequired();
            this.Property(x => x.VerificarSitio).HasMaxLength(25);
            this.Property(x => x.verificarUsuarioClave).IsRequired();
            this.Property(x => x.verificarUsuarioClave).HasMaxLength(25);
            this.Property(x => x.Codigo).IsRequired();
            this.Property(x => x.Codigo).HasMaxLength(25);
            this.Property(x => x.VerificarNota).HasMaxLength(250);
            this.Property(x => x.FechaModificacion).IsRequired();
            this.Property(x => x.EsCompartida).IsRequired();
        }
    }
}
