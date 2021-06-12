using LogicaDeNegocio;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositorio
{
    class CategoriaTypeConfiguration: EntityTypeConfiguration<ControladoraCategoria>
    {
        public CategoriaTypeConfiguration()
        {
            this.HasKey(x => x.Id);
            this.Property(x => x.Nombre).IsRequired();
            this.HasMany<ControladoraTarjeta>(ca => ca.Tarjetas);
            this.HasMany<ControladoraClave>(ca => ca.Claves);
        }
    }
}
