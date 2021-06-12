using LogicaDeNegocio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositorio
{
    public class DataAccessClave : IDataAccess<ControladoraClave>
    {

        public void Agregar(ControladoraClave entity)
        {
            using (var contexto = new AdministradorClavesDBContext())
            {
                contexto.Claves.Add(entity);
                contexto.SaveChanges();
            }
        }

        public void Borrar(ControladoraClave entity)
        {
            using (var contexto = new AdministradorClavesDBContext())
            {
                ControladoraClave aEliminar = contexto.Claves.FirstOrDefault(t => t.Id == entity.Id);
                contexto.Claves.Remove(aEliminar);
                contexto.SaveChanges();
            }
        }

        public ControladoraClave Get(int id)
        {
            using (var contexto = new AdministradorClavesDBContext())
            {
                return contexto.Claves.FirstOrDefault(t => t.Id == id);
            }
        }

        public IEnumerable<ControladoraClave> GetTodos()
        {
            using (var contexto = new AdministradorClavesDBContext())
            {
                return contexto.Claves.ToList();
            }
        }

        public void Modificar(ControladoraClave entity)
        {
            using (var contexto = new AdministradorClavesDBContext())
            {
                ControladoraClave aModificar = contexto.Claves.Find(entity.Id);
                aModificar.verificarUsuarioClave = entity.verificarUsuarioClave;
                aModificar.VerificarSitio = entity.VerificarSitio;
                aModificar.VerificarNota = entity.VerificarNota;
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
