using Dominio;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
