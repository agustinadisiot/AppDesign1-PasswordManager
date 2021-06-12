using Dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositorio
{
    class DataAccessClaveCompartida : IDataAccess<ClaveCompartida>
    {
        public void Agregar(ClaveCompartida entity)
        {
            using (var contexto = new AdministradorClavesDBContext())
            {
                
                Usuario original = contexto.Usuarios.FirstOrDefault(buscador => buscador.Id == entity.Original.Id);
                Usuario destino = contexto.Usuarios.FirstOrDefault(buscador => buscador.Id == entity.Destino.Id);
                Clave claveCompartida = contexto.Claves.FirstOrDefault(buscador => buscador.Id == entity.Clave.Id);

                if (original != null )
                { 
                    contexto.Usuarios.Attach(original);
                    entity.Original = original;
                }

                if (destino != null)
                {
                    contexto.Usuarios.Attach(destino);
                    entity.Destino = destino;
                }

                if (claveCompartida != null)
                {
                    contexto.Usuarios.Attach(original);
                    entity.Clave = claveCompartida;
                }

                contexto.ClavesCompartidas.Add(entity);
                contexto.SaveChanges();
            }
        }

        public void Borrar(ClaveCompartida entity)
        {
            using (var contexto = new AdministradorClavesDBContext())
            {
                ClaveCompartida aEliminar = contexto.ClavesCompartidas.FirstOrDefault(buscadora => buscadora.Id == entity.Id);
                contexto.ClavesCompartidas.Remove(aEliminar);
                contexto.SaveChanges();
            }
        }

        public ClaveCompartida Get(int id)
        {
            using (var contexto = new AdministradorClavesDBContext())
            {
                return contexto.ClavesCompartidas
                    .Include("Original")
                    .Include("Destino")
                    .Include("Clave")
                    .FirstOrDefault(buscadora => buscadora.Id == id);
            }
        }

        public IEnumerable<ClaveCompartida> GetTodos()
        {
            using (var contexto = new AdministradorClavesDBContext())
            {
                return contexto.ClavesCompartidas
                    .Include("Original")
                    .Include("Destino")
                    .Include("Clave")
                    .ToList();
            }
        }

        public void Modificar(ClaveCompartida entity)
        {
            using (var contexto = new AdministradorClavesDBContext())
            {
                Usuario original = contexto.Usuarios.FirstOrDefault(buscador => buscador.Id == entity.Original.Id);
                Usuario destino = contexto.Usuarios.FirstOrDefault(buscador => buscador.Id == entity.Destino.Id);
                Clave claveCompartida = contexto.Claves.FirstOrDefault(buscador => buscador.Id == entity.Clave.Id);

                if (original != null)
                {
                    contexto.Usuarios.Attach(original);
                    entity.Original = original;
                }

                if (destino != null)
                {
                    contexto.Usuarios.Attach(destino);
                    entity.Destino = destino;
                }

                if (claveCompartida != null)
                {
                    contexto.Usuarios.Attach(original);
                    entity.Clave = claveCompartida;
                }

                ClaveCompartida aModificar = contexto.ClavesCompartidas
                    .Include("Original")
                    .Include("Destino")
                    .Include("Clave")
                    .FirstOrDefault(buscador => buscador.Id == entity.Id); ;
                contexto.ClavesCompartidas.Attach(aModificar);

                aModificar.Original = entity.Original;
                aModificar.Destino = entity.Destino;
                aModificar.Clave = entity.Clave;

                contexto.SaveChanges();
            }
        }
    }
}
