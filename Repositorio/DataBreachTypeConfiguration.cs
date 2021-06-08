using Dominio;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositorio
{
    class DataBreachTypeConfiguration : EntityTypeConfiguration<DataBreach>
    {
        public DataBreachTypeConfiguration()
        {
            this.HasKey(x => x.Id);
            this.HasMany(x => x.Tarjetas).WithRequired();
            this.HasMany(x => x.Claves).WithRequired();
            this.HasMany(x => x.Filtradas).WithRequired();
            this.Property(x => x.Fecha).IsRequired();
        }
    }
}
