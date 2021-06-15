using Negocio;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
