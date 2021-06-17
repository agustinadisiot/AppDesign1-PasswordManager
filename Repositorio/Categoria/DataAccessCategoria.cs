using Negocio;
using System.Collections.Generic;
using System.Linq;

namespace Repositorio
{
    public class DataAccessCategoria : IDataAccess<Categoria>
    {

        public void Agregar(Categoria entity)
        {
            using (var contexto = new AdministradorClavesDBContext())
            {
                List<Tarjeta> tarjetas = new List<Tarjeta>();
                List<Clave> claves = new List<Clave>();

                for (int i = 0; i < entity.Tarjetas.Count; i++)
                {
                    Tarjeta t = entity.Tarjetas.ElementAt(i);

                    Tarjeta nueva = contexto.Tarjetas.FirstOrDefault(tNueva => tNueva.Id == t.Id);

                    if (nueva != null)
                    {
                        t = nueva;
                        contexto.Tarjetas.Attach(t);
                    }

                    tarjetas.Add(t);
                }


                for (int i = 0; i < entity.Claves.Count; i++)
                {
                    Clave t = entity.Claves.ElementAt(i);

                    Clave nueva = contexto.Claves.FirstOrDefault(tNueva => tNueva.Id == t.Id);

                    if (nueva != null)
                    {
                        t = nueva;
                        contexto.Claves.Attach(t);
                    }
                    claves.Add(t);
                }

                entity.Claves = claves;
                entity.Tarjetas = tarjetas;

                contexto.Categorias.Add(entity);

                contexto.SaveChanges();
            }
        }

        public void Borrar(Categoria entity)
        {
            using (var contexto = new AdministradorClavesDBContext())
            {
                Categoria aEliminar = contexto.Categorias.FirstOrDefault(t => t.Id == entity.Id);
                contexto.Categorias.Remove(aEliminar);
                contexto.SaveChanges();
            }
        }

        public Categoria Get(int id)
        {
            using (var contexto = new AdministradorClavesDBContext())
            {
                return contexto.Categorias.Include("Claves").Include("Tarjetas").FirstOrDefault(t => t.Id == id);
            }
        }

        public IEnumerable<Categoria> GetTodos()
        {
            using (var contexto = new AdministradorClavesDBContext())
            {
                return contexto.Categorias.Include("Claves").Include("Tarjetas").ToList();
            }
        }

        public void Modificar(Categoria entity)
        {
            using (var contexto = new AdministradorClavesDBContext())
            {
                List<Tarjeta> tarjetas = new List<Tarjeta>();
                List<Clave> claves = new List<Clave>();

                for (int i = 0; i < entity.Tarjetas.Count; i++)
                {
                    Tarjeta t = entity.Tarjetas.ElementAt(i);

                    Tarjeta nueva = contexto.Tarjetas.FirstOrDefault(tNueva => tNueva.Id == t.Id);

                    if (nueva != null)
                    {
                        t = nueva;
                        contexto.Tarjetas.Attach(t);
                    }

                    tarjetas.Add(t);
                }


                for (int i = 0; i < entity.Claves.Count; i++)
                {
                    Clave t = entity.Claves.ElementAt(i);

                    Clave nueva = contexto.Claves.FirstOrDefault(tNueva => tNueva.Id == t.Id);

                    if (nueva != null)
                    {
                        t = nueva;
                        contexto.Claves.Attach(t);
                    }
                    claves.Add(t);
                }

                Categoria aModificar = contexto.Categorias
                        .Include("Claves")
                        .Include("Tarjetas")
                        .FirstOrDefault(db => db.Id == entity.Id);

                contexto.Categorias.Attach(aModificar);
                aModificar.Tarjetas = tarjetas;
                aModificar.Claves = claves;
                aModificar.Nombre = entity.Nombre;
                contexto.SaveChanges();
            }
        }
    }
}
