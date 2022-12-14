using Negocio;
using System.Data.Entity;

namespace Repositorio
{
    public class AdministradorClavesDBContext : DbContext
    {
        public DbSet<Tarjeta> Tarjetas { get; set; }
        public DbSet<Clave> Claves { get; set; }
        public DbSet<DataBreach> DataBreaches { get; set; }
        public DbSet<Filtrada> Filtradas { get; set; }
        public DbSet<Categoria> Categorias { get; set; }
        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<ClaveCompartida> ClavesCompartidas { get; set; }
        public DbSet<Encriptador> Encriptadores { get; set; }

        public AdministradorClavesDBContext() : base("name=ContextoAdministradorClaves") { }
        
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {

            modelBuilder.Configurations.Add(new TarjetaTypeConfiguration());
            modelBuilder.Configurations.Add(new ClaveTypeConfiguration());
            modelBuilder.Configurations.Add(new DataBreachTypeConfiguration());
            modelBuilder.Configurations.Add(new FiltradaTypeConfiguration());
            modelBuilder.Configurations.Add(new CategoriaTypeConfiguration());
            modelBuilder.Configurations.Add(new UsuarioTypeConfiguration());
            modelBuilder.Configurations.Add(new ClaveCompartidaTypeConfiguration());
        }
    }
}
