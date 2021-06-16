using Negocio;
using System.Data.Entity.ModelConfiguration;

namespace Repositorio
{
    class ClaveCompartidaTypeConfiguration : EntityTypeConfiguration<ClaveCompartida>
    {
        public ClaveCompartidaTypeConfiguration()
        {
            this.HasKey(x => x.Id);
            this.HasRequired<Clave>(cc => cc.Clave);
        }
    }
}
