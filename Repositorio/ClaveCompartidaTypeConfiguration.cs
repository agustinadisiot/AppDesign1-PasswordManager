using Dominio;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositorio
{
    class ClaveCompartidaTypeConfiguration : EntityTypeConfiguration<ClaveCompartida>
    {
        public ClaveCompartidaTypeConfiguration()
        {
            this.HasKey(x => x.Id);
            this.HasRequired<Usuario>(cc => cc.Original);
            this.HasRequired<Usuario>(cc => cc.Destino);
            this.HasRequired<Clave>(cc => cc.Clave);
        }
    }
}
