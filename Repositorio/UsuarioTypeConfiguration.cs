using Dominio;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositorio
{
    class UsuarioTypeConfiguration : EntityTypeConfiguration<Usuario>
    {
        /*aModificar.CompartidasConmigo = entity.CompartidasConmigo;
          aModificar.CompartidasPorMi = entity.CompartidasPorMi;*/
        public UsuarioTypeConfiguration()
        {
            this.HasKey(x => x.Id);
            this.Property(x => x.Nombre).IsRequired();
            this.Property(x => x.ClaveMaestra).IsRequired();
            this.HasMany<Categoria>(usuario => usuario.Categorias);
            this.HasMany<DataBreach>(usuario => usuario.DataBreaches);

            //this.HasMany<Clave>(ca => ca.Claves);
        }
    }
}
