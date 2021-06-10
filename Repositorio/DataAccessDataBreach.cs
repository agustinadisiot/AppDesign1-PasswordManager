using Dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositorio
{
    public class DataAccessDataBreach : IDataAccess<DataBreach>
    {

        public void Agregar(DataBreach entity)
        {
            using (var contexto = new AdministradorClavesDBContext())
            {
                /*
                List<Tarjeta> tarjetas = new List<Tarjeta>();

                foreach (Tarjeta t in entity.Tarjetas) {
                    Tarjeta tNueva = contexto.Tarjetas.FirstOrDefault(t2 => t2.Id == t.Id);

                    if (tNueva != null) {
                        contexto.Tarjetas.Attach(tNueva);
                        tarjetas.Add(tNueva);
                    }

                }
                entity.Tarjetas = tarjetas;
                */

                foreach (Tarjeta t in entity.Tarjetas)
                {
                    try
                    {
                        contexto.Tarjetas.Attach(t);
                    }
                    catch (Exception){};
                }

                foreach (Clave c in entity.Claves)
                {
                    try
                    {
                        contexto.Claves.Attach(c);
                    }
                    catch (Exception){};
                }

                /*foreach (Filtrada f in entity.Filtradas)
                {
                    try
                    {
                        contexto.Filtradas.Attach(f);
                    }
                    catch (Exception){};
                }*/


                contexto.DataBreaches.Add(entity);


                
                contexto.SaveChanges();
            }
        }

        public void Borrar(DataBreach entity)
        {
            using (var contexto = new AdministradorClavesDBContext())
            {
                DataBreach aEliminar = contexto.DataBreaches.FirstOrDefault(t => t.Id == entity.Id);
                contexto.DataBreaches.Remove(aEliminar);
                contexto.SaveChanges();
            }
        }

        public DataBreach Get(int id)
        {
            using (var contexto = new AdministradorClavesDBContext())
            {
                return contexto.DataBreaches.Include("Claves").Include("Filtradas").Include("Tarjetas").FirstOrDefault(t => t.Id == id);
            }
        }

        public IEnumerable<DataBreach> GetTodos()
        {
            using (var contexto = new AdministradorClavesDBContext())
            {
                return contexto.DataBreaches.Include("Claves").Include("Filtradas").Include("Tarjetas").ToList();
            }
        }

        public void Modificar(DataBreach entity)
        {
            using (var contexto = new AdministradorClavesDBContext())
            {
                List<Clave> claves = new List<Clave>();
                List<Tarjeta> tarjetas = new List<Tarjeta>();
                List<Filtrada> filtradas = new List<Filtrada>();

                foreach (Tarjeta t in entity.Tarjetas) {
                    contexto.Tarjetas.Attach(t);
                }

                foreach (Clave c in entity.Claves) {
                    contexto.Claves.Attach(c);
                }

                foreach (Filtrada f in entity.Filtradas) {
                    contexto.Filtradas.Attach(f);
                }

                DataBreach aModificar = contexto.DataBreaches.Find(entity.Id);
                contexto.DataBreaches.Attach(aModificar);
                aModificar.Claves = entity.Claves;
                aModificar.Tarjetas = entity.Tarjetas;
                aModificar.Filtradas = entity.Filtradas;
                aModificar.Fecha = entity.Fecha;
                contexto.SaveChanges();
            }
        }

    }
}
