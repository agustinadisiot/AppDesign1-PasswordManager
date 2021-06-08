using Dominio;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositorio
{
    public class AdministradorClavesDBContext : DbContext
    {
        public DbSet<Tarjeta> Tarjetas { get; set; }
        public DbSet<Clave> Claves { get; set; }
        public AdministradorClavesDBContext() : base("name=ContextoAdministradorClaves") { }
        
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new TarjetaTypeConfiguration());
        }
    }
}
