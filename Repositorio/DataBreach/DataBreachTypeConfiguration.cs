using Negocio;
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
            this.Property(x => x.Fecha).IsRequired();
            this.HasMany<Tarjeta>(db => db.Tarjetas)
                .WithMany(t => t.DataBreaches)
                .Map(t =>
                {
                    t.MapLeftKey("DataBreachesRefId");
                    t.MapRightKey("TarjetasRefId");
                    t.ToTable("DataBreachTarjetas");
                });
            this.HasMany<Clave>(db => db.Claves)
                .WithMany(c => c.DataBreaches)
                .Map(c =>
                {
                    c.MapLeftKey("DataBreachesRefId");
                    c.MapRightKey("ClavesRefId");
                    c.ToTable("DataBreachClaves");
                });
            this.HasMany<Filtrada>(db => db.Filtradas)
                .WithMany(f => f.DataBreaches)
                .Map(f =>
                {
                    f.MapLeftKey("DataBreachesRefId");
                    f.MapRightKey("FiltradasRefId");
                    f.ToTable("DataBreachFiltradas");
                });
        }
    }
}
