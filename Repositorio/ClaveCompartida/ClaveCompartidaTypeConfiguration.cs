using Negocio;
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
        //.HasOne(u => u.User).WithMany(u => u.AnEventUsers).IsRequired().OnDelete(DeleteBehavior.Restrict);
        public ClaveCompartidaTypeConfiguration()
        {
            this.HasKey(x => x.Id);
            this.HasRequired<Usuario>(cc => cc.Original)
                .WithMany(u => u.CompartidasPorMi)
                .HasForeignKey(cc => cc.OriginalId).WillCascadeOnDelete(false);
            this.HasRequired<Usuario>(cc => cc.Destino)
                .WithMany(u => u.CompartidasConmigo)
                .HasForeignKey(cc => cc.DestinoId).WillCascadeOnDelete(false);
            this.HasRequired<Clave>(cc => cc.Clave);
        }
    }
}
