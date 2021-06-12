using LogicaDeNegocio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositorio
{
    public class DataAccessCategoria : IDataAccess<ControladoraCategoria>
    {

        public void Agregar(ControladoraCategoria entity)
        {
            using (var contexto = new AdministradorClavesDBContext())
            {
                List<ControladoraTarjeta> tarjetas = new List<ControladoraTarjeta>();
                List<ControladoraClave> claves = new List<ControladoraClave>();

                for (int i = 0; i < entity.Tarjetas.Count; i++)
                {
                    ControladoraTarjeta t = entity.Tarjetas.ElementAt(i);

                    ControladoraTarjeta nueva = contexto.Tarjetas.FirstOrDefault(tNueva => tNueva.Id == t.Id);

                    if (nueva != null)
                    {
                        t = nueva;
                        contexto.Tarjetas.Attach(t);
                    }

                    tarjetas.Add(t);
                }


                for (int i = 0; i < entity.Claves.Count; i++)
                {
                    ControladoraClave t = entity.Claves.ElementAt(i);

                    ControladoraClave nueva = contexto.Claves.FirstOrDefault(tNueva => tNueva.Id == t.Id);

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

        public void Borrar(ControladoraCategoria entity)
        {
            using (var contexto = new AdministradorClavesDBContext())
            {
                ControladoraCategoria aEliminar = contexto.Categorias.FirstOrDefault(t => t.Id == entity.Id);
                contexto.Categorias.Remove(aEliminar);
                contexto.SaveChanges();
            }
        }

        public ControladoraCategoria Get(int id)
        {
            using (var contexto = new AdministradorClavesDBContext())
            {
                return contexto.Categorias.Include("Claves").Include("Tarjetas").FirstOrDefault(t => t.Id == id);
            }
        }

        public IEnumerable<ControladoraCategoria> GetTodos()
        {
            using (var contexto = new AdministradorClavesDBContext())
            {
                return contexto.Categorias.Include("Claves").Include("Tarjetas").ToList();
            }
        }

        public void Modificar(ControladoraCategoria entity)
        {
            using (var contexto = new AdministradorClavesDBContext())
            {
                List<ControladoraTarjeta> tarjetas = new List<ControladoraTarjeta>();
                List<ControladoraClave> claves = new List<ControladoraClave>();

                for (int i = 0; i < entity.Tarjetas.Count; i++)
                {
                    ControladoraTarjeta t = entity.Tarjetas.ElementAt(i);

                    ControladoraTarjeta nueva = contexto.Tarjetas.FirstOrDefault(tNueva => tNueva.Id == t.Id);

                    if (nueva != null)
                    {
                        t = nueva;
                        contexto.Tarjetas.Attach(t);
                    }

                    tarjetas.Add(t);
                }


                for (int i = 0; i < entity.Claves.Count; i++)
                {
                    ControladoraClave t = entity.Claves.ElementAt(i);

                    ControladoraClave nueva = contexto.Claves.FirstOrDefault(tNueva => tNueva.Id == t.Id);

                    if (nueva != null)
                    {
                        t = nueva;
                        contexto.Claves.Attach(t);
                    }
                    claves.Add(t);
                }

                ControladoraCategoria aModificar = contexto.Categorias
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
