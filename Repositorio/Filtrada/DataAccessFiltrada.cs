using LogicaDeNegocio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositorio
{
    public class DataAccessFiltrada : IDataAccess<Filtrada>
    {

        public void Agregar(Filtrada entity)
        {
            using (var contexto = new AdministradorClavesDBContext())
            {
                contexto.Filtradas.Add(entity);
                contexto.SaveChanges();
            }
        }

        public void Borrar(Filtrada entity)
        {
            using (var contexto = new AdministradorClavesDBContext())
            {
                Filtrada aEliminar = contexto.Filtradas.FirstOrDefault(t => t.Id == entity.Id);
                contexto.Filtradas.Remove(aEliminar);
                contexto.SaveChanges();
            }
        }

        public Filtrada Get(int id)
        {
            using (var contexto = new AdministradorClavesDBContext())
            {
                return contexto.Filtradas.FirstOrDefault(t => t.Id == id);
            }
        }

        public IEnumerable<Filtrada> GetTodos()
        {
            using (var contexto = new AdministradorClavesDBContext())
            {
                return contexto.Filtradas.ToList();
            }
        }

        public void Modificar(Filtrada entity)
        {
            using (var contexto = new AdministradorClavesDBContext())
            {
                Filtrada aModificar = contexto.Filtradas.Find(entity.Id);
                aModificar.Texto = entity.Texto;
                contexto.SaveChanges();
            }
        }

    }
}
