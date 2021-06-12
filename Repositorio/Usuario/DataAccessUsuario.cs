using LogicaDeNegocio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositorio
{
    public class DataAccessUsuario : IDataAccess<ControladoraUsuario>
    {

        public void Agregar(ControladoraUsuario entity)
        {
            using (var contexto = new AdministradorClavesDBContext())
            {
                List<ControladoraCategoria> categorias = new List<ControladoraCategoria>();
                List<DataBreach> dataBreaches = new List<DataBreach>();

                for (int i = 0; i < entity.Categorias.Count; i++)
                {
                    ControladoraCategoria categoria = entity.Categorias.ElementAt(i);

                    ControladoraCategoria nueva = contexto.Categorias.FirstOrDefault(tNueva => tNueva.Id == categoria.Id);

                    if (nueva != null)
                    {
                        categoria = nueva;
                        contexto.Categorias.Attach(categoria);
                    }

                    categorias.Add(categoria);
                }

                for (int i = 0; i < entity.DataBreaches.Count; i++)
                {
                    DataBreach dataBreach = entity.DataBreaches.ElementAt(i);

                    DataBreach nueva = contexto.DataBreaches.FirstOrDefault(tNueva => tNueva.Id == dataBreach.Id);

                    if (nueva != null)
                    {
                        dataBreach = nueva;
                        contexto.DataBreaches.Attach(dataBreach);
                    }
                    dataBreaches.Add(dataBreach);
                }

                entity.DataBreaches = dataBreaches;
                entity.Categorias = categorias;

                contexto.Usuarios.Add(entity);

                contexto.SaveChanges();
            }
        }

        public void Borrar(ControladoraUsuario entity)
        {
            using (var contexto = new AdministradorClavesDBContext())
            {
                ControladoraUsuario aEliminar = contexto.Usuarios.FirstOrDefault(t => t.Id == entity.Id);
                contexto.Usuarios.Remove(aEliminar);
                contexto.SaveChanges();
            }
        }

        public ControladoraUsuario Get(int id)
        {
            using (var contexto = new AdministradorClavesDBContext())
            {
                return contexto.Usuarios
                    .Include("Categorias")
                    .Include("DataBreaches")
                    .Include("CompartidasConmigo")
                    .Include("CompartidasPorMi")
                    .FirstOrDefault(t => t.Id == id);
            }
        }

        public IEnumerable<ControladoraUsuario> GetTodos()
        {
            using (var contexto = new AdministradorClavesDBContext())
            {
                return contexto.Usuarios
                    .Include("Categorias")
                    .Include("DataBreaches")
                    .Include("CompartidasConmigo")
                    .Include("CompartidasPorMi");
            }
        }

        public void Modificar(ControladoraUsuario entity)
        {
            using (var contexto = new AdministradorClavesDBContext())
            {
                List<ControladoraTarjeta> tarjetas = new List<ControladoraTarjeta>();
                List<ControladoraClave> claves = new List<ControladoraClave>();

                List<ControladoraCategoria> categorias = new List<ControladoraCategoria>();
                List<DataBreach> dataBreaches = new List<DataBreach>();

                for (int i = 0; i < entity.Categorias.Count; i++)
                {
                    ControladoraCategoria categoria = entity.Categorias.ElementAt(i);

                    ControladoraCategoria nueva = contexto.Categorias.FirstOrDefault(tNueva => tNueva.Id == categoria.Id);

                    if (nueva != null)
                    {
                        categoria = nueva;
                        contexto.Categorias.Attach(categoria);
                    }

                    categorias.Add(categoria);
                }

                for (int i = 0; i < entity.DataBreaches.Count; i++)
                {
                    DataBreach dataBreach = entity.DataBreaches.ElementAt(i);

                    DataBreach nueva = contexto.DataBreaches.FirstOrDefault(tNueva => tNueva.Id == dataBreach.Id);

                    if (nueva != null)
                    {
                        dataBreach = nueva;
                        contexto.DataBreaches.Attach(dataBreach);
                    }
                    dataBreaches.Add(dataBreach);
                }

                ControladoraUsuario aModificar = contexto.Usuarios
                        .Include("Categorias")
                        .Include("DataBreaches")
                        .Include("CompartidasConmigo")
                        .Include("CompartidasPorMi")
                        .FirstOrDefault(db => db.Id == entity.Id);

                contexto.Usuarios.Attach(aModificar);
                aModificar.Categorias = categorias;
                aModificar.DataBreaches = dataBreaches;
                aModificar.Nombre = entity.Nombre;
                aModificar.ClaveMaestra = entity.ClaveMaestra;
                aModificar.CompartidasConmigo = entity.CompartidasConmigo;
                aModificar.CompartidasPorMi = entity.CompartidasPorMi;
                contexto.SaveChanges();
            }
        }
    }
}
