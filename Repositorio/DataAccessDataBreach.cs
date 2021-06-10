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
                //Pruebas nuestras
                List<Clave> claves = new List<Clave>();
                List<Tarjeta> tarjetas = new List<Tarjeta>();
                List<Filtrada> filtradas = new List<Filtrada>();
                //contexto.Entry(entity).State = System.Data.Entity.EntityState.Modified;

                foreach (Tarjeta t in entity.Tarjetas)
                {
                    contexto.Tarjetas.Attach(t);
                    tarjetas.Add(t);

                }

                foreach (Clave c in entity.Claves)
                {
                    contexto.Claves.Attach(c);
                    claves.Add(c);
                }

                foreach (Filtrada f1 in entity.Filtradas)
                {
                    Filtrada fNueva = contexto.Filtradas.FirstOrDefault(f2 => f2.Id == f1.Id);

                    if (fNueva != null)
                    {
                        contexto.Filtradas.Attach(fNueva);
                    }
                    filtradas.Add(f1);
                }



                /*DataBreach aModificar = contexto.DataBreaches.FirstOrDefault(db => db.Id == entity.Id);
                contexto.DataBreaches.Attach(aModificar);*/
                //DataBreach aModificar = new DataBreach() { Id = entity.Id };


                /*aModificar.Claves = entity.Claves;
                aModificar.Tarjetas = entity.Tarjetas;
                aModificar.Filtradas = entity.Filtradas;*/

                /*aModificar.Claves = claves;
                aModificar.Tarjetas = tarjetas;
                aModificar.Filtradas = filtradas;
                aModificar.Fecha = entity.Fecha;*/

                /* Metodo Attach veterinaria de mascota
                DataBreach aModificar = contexto.DataBreaches.FirstOrDefault(db => db.Id == entity.Id);
                contexto.DataBreaches.Attach(aModificar);
                aModificar = entity;
                contexto.SaveChanges();*/

                /*Metodo de add una mascota
                contexto.Entry(entity).State = System.Data.Entity.EntityState.Modified;
                contexto.SaveChanges();*/

                /*DataBreach aModificar = contexto.DataBreaches.Find(entity.Id);
                aModificar.Claves = claves;
                aModificar.Tarjetas = tarjetas;
                aModificar.Filtradas = filtradas;
                aModificar.Fecha = entity.Fecha;
                contexto.SaveChanges();*/

                DataBreach aModificar = contexto.DataBreaches.SingleOrDefault(db => db.Id == entity.Id);

                if (aModificar == null) {
                    throw new ObjetoInexistenteException();
                }

                aModificar.Claves = claves;
                aModificar.Tarjetas = tarjetas;
                aModificar.Filtradas = filtradas;
                contexto.SaveChanges();

            }
        }

    }
}
