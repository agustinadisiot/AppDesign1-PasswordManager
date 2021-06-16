using Negocio;
using System.Data.Entity.ModelConfiguration;

namespace Repositorio
{
    class EncriptadorTypeConfiguration : EntityTypeConfiguration<Encriptador>
    {
        public EncriptadorTypeConfiguration()
        {
            this.HasKey(x => x.Id);
            this.Property(x => x.Key).IsRequired();
            this.Property(x => x.IV).IsRequired();
        }
    }
}
