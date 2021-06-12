using Negocio;
using Repositorio;
using System;
using System.Collections.Generic;
using System.Linq;

namespace LogicaDeNegocio
{
    public class ControladoraAdministrador
    {

        public bool EsListaUsuariosVacia()
        {
            DataAccessUsuario acceso = new DataAccessUsuario();
            List<Usuario> usuarios = (List<Usuario>)acceso.GetTodos();
            return usuarios.Count() == 0;
        }

        public void AgregarUsuario(Usuario usuario)
        {
            ControladoraUsuario controladoraUsuario = new ControladoraUsuario();
            controladoraUsuario.Verificar(usuario);

            if (this.YaExisteUsuario(usuario)) throw new ObjetoYaExistenteException();
            DataAccessUsuario acceso = new DataAccessUsuario();
            acceso.Agregar(usuario);
        }

        public Usuario GetUsuario(Usuario aBuscar)
        {
            DataAccessUsuario acceso = new DataAccessUsuario();
            List<Usuario> usuarios = (List<Usuario>)acceso.GetTodos();
            return usuarios.First(aBuscar.Equals);
        }

        public bool YaExisteUsuario(Usuario buscador)
        {
            DataAccessUsuario acceso = new DataAccessUsuario();
            List<Usuario> usuarios = (List<Usuario>)acceso.GetTodos();
            return usuarios.Contains(buscador);
        }

        public List<Usuario> GetListaUsuarios()
        {
            DataAccessUsuario acceso = new DataAccessUsuario();
            List<Usuario> usuarios = (List<Usuario>)acceso.GetTodos();
            return usuarios;
        }


        public void CompartirClave(ClaveCompartida aCompartir)
        {
            DataAccessUsuario acceso = new DataAccessUsuario();
            ControladoraUsuario controladoraUsuario = new ControladoraUsuario();

            Usuario usuarioOriginal = acceso.Get(aCompartir.Original.Id);
            Usuario usuarioDestino = acceso.Get(aCompartir.Destino.Id);
            Clave claveACompartir = controladoraUsuario.GetClave(aCompartir.Clave, usuarioOriginal);

            if (usuarioOriginal == null || usuarioDestino == null) {
                throw new UsuarioInexistenteException();
            }

            if (claveACompartir == null) {
                throw new ObjetoInexistenteException();
            }

            if (usuarioOriginal.CompartidasPorMi.Contains(aCompartir)) throw new ObjetoYaExistenteException();


            claveACompartir.EsCompartida = true;

            ClaveCompartida guardar = new ClaveCompartida()
            {
                Original = usuarioOriginal,
                Destino = usuarioDestino,
                Clave = claveACompartir
            };

            usuarioOriginal.CompartidasPorMi.Add(guardar);
            acceso.Modificar(usuarioOriginal);

            usuarioDestino.CompartidasConmigo.Add(guardar);
            acceso.Modificar(usuarioDestino);
        }


        public void DejarDeCompartir(ClaveCompartida aDejarCompartir)
        {
            DataAccessUsuario acceso = new DataAccessUsuario();
            ControladoraUsuario controladoraUsuario = new ControladoraUsuario();
            ControladoraClave controladoraClave = new ControladoraClave();

            Usuario usuarioOriginal = acceso.Get(aDejarCompartir.Original.Id);
            Usuario usuarioDestino = acceso.Get(aDejarCompartir.Destino.Id);
            Clave claveADejarDeCompartir = controladoraUsuario.GetClave(aDejarCompartir.Clave, usuarioOriginal);

            if (!claveADejarDeCompartir.EsCompartida) throw new ObjetoInexistenteException();

            ClaveCompartida aEliminar = new ClaveCompartida()
            {
                Original = usuarioOriginal,
                Destino = usuarioDestino,
                Clave = claveADejarDeCompartir
            };

            if (!usuarioDestino.CompartidasConmigo.Contains(aEliminar)) throw new ObjetoInexistenteException();

            usuarioOriginal.CompartidasPorMi.Remove(aEliminar);
            acceso.Modificar(usuarioOriginal);
            usuarioDestino.CompartidasConmigo.Remove(aEliminar);
            acceso.Modificar(usuarioDestino);
       
            bool sigueCompartida = usuarioOriginal.CompartidasPorMi.Any(buscadora => buscadora.Clave.Equals(claveADejarDeCompartir));
            if (!sigueCompartida) {
                claveADejarDeCompartir.EsCompartida = false;
                controladoraClave.Modificar(claveADejarDeCompartir);
            }

        }
    }
}