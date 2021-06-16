using Negocio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.Entity;

namespace Repositorio
{
    public class DataAccessUsuario : IDataAccess<Usuario>
    {

        public void Agregar(Usuario entity)
        {
            using (var contexto = new AdministradorClavesDBContext())
            {
                List<Categoria> categorias = new List<Categoria>();
                List<DataBreach> dataBreaches = new List<DataBreach>();

                for (int i = 0; i < entity.Categorias.Count; i++)
                {
                    Categoria categoria = entity.Categorias.ElementAt(i);

                    Categoria nueva = contexto.Categorias.FirstOrDefault(tNueva => tNueva.Id == categoria.Id);

                    if (nueva != null)
                    {
                        categoria = nueva;
                        contexto.Categorias.Attach(categoria);
                    }

                    categorias.Add(categoria);
                }

                for (int i = 0; i < entity.DataBreaches.Count; i++)
                {
                    DataBreach dataBreach = entity.DataBreaches.ElementAt(i);

                    DataBreach nueva = contexto.DataBreaches.FirstOrDefault(tNueva => tNueva.Id == dataBreach.Id);

                    if (nueva != null)
                    {
                        dataBreach = nueva;
                        contexto.DataBreaches.Attach(dataBreach);
                    }
                    dataBreaches.Add(dataBreach);
                }

                entity.DataBreaches = dataBreaches;
                entity.Categorias = categorias;

                contexto.Usuarios.Add(entity);

                contexto.SaveChanges();
            }
        }

        public void Borrar(Usuario entity)
        {
            using (var contexto = new AdministradorClavesDBContext())
            {
                Usuario aEliminar = contexto.Usuarios
                    .Include("Categorias")
                    .Include("DataBreaches")
                    .Include("CompartidasConmigo")
                    .Include("CompartidasPorMi")
                    .FirstOrDefault(t => t.Id == entity.Id);
                contexto.Usuarios.Remove(aEliminar);
                contexto.SaveChanges();
            }
        }

        public Usuario Get(int id)
        {
            using (var contexto = new AdministradorClavesDBContext())
            {
                return contexto.Usuarios
                    .Include("Categorias")
                    .Include(u => u.Categorias.Select(c => c.Claves))
                    .Include(u => u.Categorias.Select(c => c.Tarjetas))
                    .Include("DataBreaches")
                    .Include(u => u.DataBreaches.Select(db => db.Claves))
                    .Include(u => u.DataBreaches.Select(db => db.Tarjetas))
                    .Include(u => u.DataBreaches.Select(db => db.Filtradas))
                    .Include("CompartidasConmigo")
                    .Include(u => u.CompartidasConmigo.Select(cc => cc.Clave))
                    .Include(u => u.CompartidasConmigo.Select(cc => cc.Original))
                    .Include(u => u.CompartidasConmigo.Select(cc => cc.Destino))
                    .Include("CompartidasPorMi")
                    .Include(u => u.CompartidasPorMi.Select(pm => pm.Clave))
                    .Include(u => u.CompartidasPorMi.Select(pm => pm.Original))
                    .Include(u => u.CompartidasPorMi.Select(pm => pm.Destino))
                    .FirstOrDefault(t => t.Id == id);
            }
        }

        public IEnumerable<Usuario> GetTodos()
        {
            using (var contexto = new AdministradorClavesDBContext())
            {
                IEnumerable<Usuario> retorno;
                try
                {
                    retorno =  contexto.Usuarios
                        .Include("Categorias")
                        .Include(u=> u.Categorias.Select(c => c.Claves))
                        .Include(u => u.Categorias.Select(c => c.Tarjetas))
                        .Include("DataBreaches")
                        .Include("CompartidasConmigo")
                        .Include("CompartidasPorMi").ToList();
                }
                catch (Exception) {
                    retorno =  new List<Usuario>();
                }
                return retorno;
            }
        }

        public void Modificar(Usuario entity)
        {
            using (var contexto = new AdministradorClavesDBContext())
            {
                List<Categoria> categorias = new List<Categoria>();
                List<DataBreach> dataBreaches = new List<DataBreach>();
                List<ClaveCompartida> compartidasConmigo = new List<ClaveCompartida>();
                List<ClaveCompartida> compartidasPorMi = new List<ClaveCompartida>();

                for (int i = 0; i < entity.Categorias.Count; i++)
                {
                    Categoria categoria = entity.Categorias.ElementAt(i);

                    Categoria nueva = contexto.Categorias
                        .Include("Claves")
                        .Include("Tarjetas")
                        .FirstOrDefault(tNueva => tNueva.Id == categoria.Id);

                    if (nueva != null)
                    {
                        categoria = nueva;
                        contexto.Categorias.Attach(categoria);
                    }

                    categorias.Add(categoria);
                }

                for (int i = 0; i < entity.DataBreaches.Count; i++)
                {
                    DataBreach dataBreach = entity.DataBreaches.ElementAt(i);

                    DataBreach nueva = contexto.DataBreaches
                        .Include("Claves")
                        .Include("Tarjetas")
                        .Include("Filtradas")
                        .FirstOrDefault(tNueva => tNueva.Id == dataBreach.Id);

                    if (nueva != null)
                    {
                        dataBreach = nueva;
                        contexto.DataBreaches.Attach(dataBreach);
                    }
                    dataBreaches.Add(dataBreach);
                }

                for (int i = 0; i < entity.CompartidasConmigo.Count; i++)
                {
                    ClaveCompartida conmigo = entity.CompartidasConmigo.ElementAt(i);

                    ClaveCompartida nueva = contexto.ClavesCompartidas
                        .Include("Clave")
                        .Include("Original")
                        .Include("Destino")
                        .FirstOrDefault(tNueva => tNueva.Id == conmigo.Id);

                    if (nueva != null)
                    {
                        conmigo = nueva;
                        contexto.ClavesCompartidas.Attach(conmigo);
                    }

                    compartidasConmigo.Add(conmigo);
                }

                for (int i = 0; i < entity.CompartidasPorMi.Count; i++)
                {
                    ClaveCompartida porMi = entity.CompartidasPorMi.ElementAt(i);

                    ClaveCompartida nueva = contexto.ClavesCompartidas
                        .Include("Clave")
                        .Include("Original")
                        .Include("Destino")
                        .FirstOrDefault(tNueva => tNueva.Id == porMi.Id);

                    if (nueva != null)
                    {
                        porMi = nueva;
                        contexto.ClavesCompartidas.Attach(porMi);
                    }

                    compartidasPorMi.Add(porMi);
                }

                Usuario aModificar = contexto.Usuarios
                        .Include("Categorias")
                        .Include(u => u.Categorias.Select(c => c.Claves))
                        .Include(u => u.Categorias.Select(c => c.Tarjetas))
                        .Include("DataBreaches")
                        .Include("CompartidasConmigo")
                        .Include(u => u.CompartidasConmigo.Select(cc => cc.Clave))
                        .Include(u => u.CompartidasConmigo.Select(cc => cc.Original))
                        .Include(u => u.CompartidasConmigo.Select(cc => cc.Destino))
                        .Include("CompartidasPorMi")
                        .Include(u => u.CompartidasPorMi.Select(pm => pm.Clave))
                        .Include(u => u.CompartidasPorMi.Select(pm => pm.Original))
                        .Include(u => u.CompartidasPorMi.Select(pm => pm.Destino))
                        .FirstOrDefault(db => db.Id == entity.Id);

                contexto.Usuarios.Attach(aModificar);
                aModificar.Categorias = categorias;
                aModificar.DataBreaches = dataBreaches;
                aModificar.Nombre = entity.Nombre;
                aModificar.ClaveMaestra = entity.ClaveMaestra;
                aModificar.CompartidasConmigo = compartidasConmigo;
                aModificar.CompartidasPorMi = compartidasPorMi;
                contexto.SaveChanges();
            }
        }
    }
}
