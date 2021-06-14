using Negocio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositorio
{
    public class DataAccessClave : IDataAccess<Clave>
    {

        public void Agregar(Clave entity)
        {
            using (var contexto = new AdministradorClavesDBContext())
            {
                contexto.Claves.Add(entity);
                contexto.SaveChanges();
            }
        }

        public void Borrar(Clave entity)
        {
            using (var contexto = new AdministradorClavesDBContext())
            {
                Clave aEliminar = contexto.Claves.FirstOrDefault(t => t.Id == entity.Id);
                contexto.Claves.Remove(aEliminar);
                contexto.SaveChanges();
            }
        }

        public Clave Get(int id)
        {
            using (var contexto = new AdministradorClavesDBContext())
            {
                return contexto.Claves.FirstOrDefault(t => t.Id == id);
            }
        }

        public IEnumerable<Clave> GetTodos()
        {
            using (var contexto = new AdministradorClavesDBContext())
            {
                try
                {
                    return contexto.Claves.ToList();
                }
                catch (Exception) {
                    return new List<Clave>();
                }
            }
        }

        public void Modificar(Clave entity)
        {
            using (var contexto = new AdministradorClavesDBContext())
            {
                Clave aModificar = contexto.Claves.Find(entity.Id);
                aModificar.UsuarioClave = entity.UsuarioClave;
                aModificar.Sitio = entity.Sitio;
                aModificar.Nota = entity.Nota;
                aModificar.EsCompartida = entity.EsCompartida;
                if (aModificar.Codigo != entity.Codigo)
                {
                    aModificar.Codigo = entity.Codigo;
                    aModificar.FechaModificacion = DateTime.Now.Date;
                }
                contexto.SaveChanges();
            }
        }
    }
}
