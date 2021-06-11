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

                foreach (Tarjeta tarjetaNueva in entity.Tarjetas)
                {
                    try
                    {
                        contexto.Tarjetas.Attach(tarjetaNueva);
                    }
                    catch (Exception){};
                }

                foreach (Clave claveNueva in entity.Claves)
                {
                    try
                    {
                        contexto.Claves.Attach(claveNueva);
                    }
                    catch (Exception){};
                }

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

                /* DataBreach modificar = contexto.DataBreaches.Include("Tarjetas").FirstOrDefault(db => db.Id == entity.Id);
                 modificar = entity;

                 for (int i = 0; i < modificar.Tarjetas.Count; i++)
                 {
                     Tarjeta t = modificar.Tarjetas.ElementAt(i);

                     Tarjeta nueva = contexto.Tarjetas.FirstOrDefault(tNueva => tNueva.Id == t.Id);

                     if (nueva != null)
                     {
                         t = nueva;
                     }
                 }


                 contexto.SaveChanges();*/

                /*foreach (Tarjeta tarjetaNueva in entity.Tarjetas)
                {
                    try
                    {
                        contexto.Tarjetas.Attach(tarjetaNueva);
                    }
                    catch (Exception) { };
                }

                foreach (Clave claveNueva in entity.Claves)
                {
                    try
                    {
                        contexto.Claves.Attach(claveNueva);
                    }
                    catch (Exception) { };
                }*/

                List<Tarjeta> tarjetas = new List<Tarjeta>();
                List<Clave> claves = new List<Clave>();
                List<Filtrada> filtradas = new List<Filtrada>();

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

                for (int i = 0; i < entity.Filtradas.Count; i++)
                {
                    Filtrada t = entity.Filtradas.ElementAt(i);

                    Filtrada nueva = contexto.Filtradas.FirstOrDefault(tNueva => tNueva.Id == t.Id);

                    if (nueva != null)
                    {
                        t = nueva;
                        contexto.Filtradas.Attach(t);
                    }
                    filtradas.Add(t);
                }

                //DataBreach aModificar = contexto.DataBreaches.Find(entity.Id);
                DataBreach aModificar = contexto.DataBreaches
                        .Include("Claves")
                        .Include("Filtradas")
                        .Include("Tarjetas")
                        .FirstOrDefault(db => db.Id == entity.Id);

                contexto.DataBreaches.Attach(aModificar);
                aModificar.Fecha = entity.Fecha;
                aModificar.Tarjetas = tarjetas;
                /*aModificar.Claves = claves;
                aModificar.Filtradas = filtradas;*/
                contexto.SaveChanges();
            }
        }

    }
}
