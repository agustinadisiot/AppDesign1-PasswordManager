using LogicaDeNegocio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositorio
{
    public class DataAccessTarjeta : IDataAccess<ControladoraTarjeta>
    {
        public void Agregar(ControladoraTarjeta entity)
        {
            using (var contexto = new AdministradorClavesDBContext())
            {
                contexto.Tarjetas.Add(entity);
                contexto.SaveChanges();
            }
        }

        public void Borrar(ControladoraTarjeta entity)
        {
            using (var contexto = new AdministradorClavesDBContext())
            {
                ControladoraTarjeta aEliminar = contexto.Tarjetas.FirstOrDefault(t => t.Id == entity.Id);
                contexto.Tarjetas.Remove(aEliminar);
                contexto.SaveChanges();
            }
        }

        public ControladoraTarjeta Get(int id)
        {
            using (var contexto = new AdministradorClavesDBContext())
            {
                return contexto.Tarjetas.FirstOrDefault(t => t.Id == id);
            }
        }

        public IEnumerable<ControladoraTarjeta> GetTodos()
        {
            using (var contexto = new AdministradorClavesDBContext())
            {
                return contexto.Tarjetas.ToList();
            }
        }

        public void Modificar(ControladoraTarjeta entity)
        {
            using (var contexto = new AdministradorClavesDBContext())
            {
                ControladoraTarjeta aModificar = contexto.Tarjetas.Find(entity.Id);
                aModificar.Nombre = entity.Nombre;
                aModificar.Numero = entity.Numero;
                aModificar.Tipo = entity.Tipo;
                aModificar.Codigo = entity.Codigo;
                aModificar.Nota = entity.Nota;
                aModificar.Vencimiento = entity.Vencimiento;
                contexto.SaveChanges();
            }
        }
    }
}
