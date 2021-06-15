using Negocio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositorio
{
    public class DataAccessEncriptador : IDataAccess<Encriptador>
    {
        public void Agregar(Encriptador entity)
        {
            using (var contexto = new AdministradorClavesDBContext())
            {
                contexto.Encriptadores.Add(entity);

                contexto.SaveChanges();
            }
        }

        public void Borrar(Encriptador entity)
        {
            using (var contexto = new AdministradorClavesDBContext())
            {
                Encriptador aEliminar = contexto.Encriptadores.FirstOrDefault(buscadora => buscadora.Id == entity.Id);
                contexto.Encriptadores.Remove(aEliminar);
                contexto.SaveChanges();
            }
        }

        public Encriptador Get(int id)
        {
            using (var contexto = new AdministradorClavesDBContext())
            {
                return contexto.Encriptadores
                    .FirstOrDefault(buscadora => buscadora.Id == id);
            }
        }

        public IEnumerable<Encriptador> GetTodos()
        {
            using (var contexto = new AdministradorClavesDBContext())
            {
                return contexto.Encriptadores
                    .ToList();
            }
        }

        public void Modificar(Encriptador entity)
        {
            throw new NotImplementedException();
        }
    }
}
