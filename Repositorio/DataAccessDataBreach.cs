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
                DataBreach aModificar = contexto.DataBreaches.Find(entity.Id);
                aModificar.Claves = entity.Claves;
                aModificar.Tarjetas = entity.Tarjetas;
                aModificar.Filtradas = entity.Filtradas;
                aModificar.Fecha = entity.Fecha;
                contexto.SaveChanges();
            }
        }

    }
}
