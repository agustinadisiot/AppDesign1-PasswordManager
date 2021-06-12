using Negocio;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
