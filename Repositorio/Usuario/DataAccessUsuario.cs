using Negocio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
                Usuario aEliminar = contexto.Usuarios.FirstOrDefault(t => t.Id == entity.Id);
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
                    .Include("DataBreaches")
                    .Include("CompartidasConmigo")
                    .Include("CompartidasPorMi")
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
                List<Tarjeta> tarjetas = new List<Tarjeta>();
                List<Clave> claves = new List<Clave>();

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

                Usuario aModificar = contexto.Usuarios
                        .Include("Categorias")
                        .Include("DataBreaches")
                        .Include("CompartidasConmigo")
                        .Include("CompartidasPorMi")
                        .FirstOrDefault(db => db.Id == entity.Id);

                contexto.Usuarios.Attach(aModificar);
                aModificar.Categorias = categorias;
                aModificar.DataBreaches = dataBreaches;
                aModificar.Nombre = entity.Nombre;
                aModificar.ClaveMaestra = entity.ClaveMaestra;
                aModificar.CompartidasConmigo = entity.CompartidasConmigo;
                aModificar.CompartidasPorMi = entity.CompartidasPorMi;
                contexto.SaveChanges();
            }
        }
    }
}
