using System;
using System.Collections.Generic;
using System.Linq;

namespace LogicaDeNegocio
{
    public class ControladoraAdministrador
    {
        private List<ControladoraUsuario> _usuarios;

        public ControladoraAdministrador() {
            this._usuarios = new List<ControladoraUsuario>();
        }

        public bool EsListaUsuariosVacia()
        {
            return this._usuarios.Count() == 0;
        }

        public void AgregarUsuario(ControladoraUsuario usuario)
        {
            if (usuario.VerificarNombre == null)  throw new ObjetoIncompletoException();
            if (this.YaExisteUsuario(usuario)) throw new ObjetoYaExistenteException();
            this._usuarios.Add(usuario);
            
        }

        public ControladoraUsuario GetUsuario(ControladoraUsuario aBuscar)
        {
            if (!this.YaExisteUsuario(aBuscar)) throw new ObjetoInexistenteException();
            return this._usuarios.First(aBuscar.Equals);
        }

        public bool YaExisteUsuario(ControladoraUsuario buscador)
        {
            return this._usuarios.Contains(buscador);
        }

        public List<ControladoraUsuario> GetListaUsuarios()
        {
            if(this.EsListaUsuariosVacia()) return null;
            else { 
                return this._usuarios;
            }
        }


        /*public void CompartirClave(ClaveCompartida aCompartir)
        {
            ControladoraUsuario usuarioDestino = aCompartir.Destino;
            ControladoraUsuario usuarioOriginal = aCompartir.Original;
            Clave claveACompartir = aCompartir.Clave;

            if (this.CompartidasPorMi.Contains(aCompartir)) throw new ObjetoYaExistenteException();

            claveACompartir = this.GetClave(claveACompartir);

            claveACompartir.EsCompartida = true;

            Negocio.ClaveCompartida guardar = new Negocio.ClaveCompartida()
            {
                Original = usuarioOriginal,
                Destino = usuarioDestino,
                Clave = claveACompartir
            };

            this.CompartidasPorMi.Add(guardar);

            usuarioDestino.CompartidasConmigo.Add(guardar);
        }*/


        /*public void DejarDeCompartir(ClaveCompartida aDejarDeCompartir, Usuario contenedor)
        {
            ControladoraUsuario usuarioOriginal = aDejarDeCompartir.Original;
            ControladoraUsuario usuarioDestino = aDejarDeCompartir.Destino;
            Clave claveADejarDeCompartir = this.GetClave(aDejarDeCompartir.Clave);

            if (!claveADejarDeCompartir.EsCompartida) throw new ObjetoInexistenteException();

            Negocio.ClaveCompartida aEliminar = new Negocio.ClaveCompartida()
            {
                Original = usuarioOriginal,
                Destino = usuarioDestino,
                Clave = claveADejarDeCompartir
            };

            if (!usuarioDestino.CompartidasConmigo.Contains(aEliminar)) throw new ObjetoInexistenteException();

            this.CompartidasPorMi.Remove(aEliminar);

            usuarioDestino.CompartidasConmigo.Remove(aEliminar);

            bool sigueCompartida = this.CompartidasPorMi.Any(buscadora => buscadora.Clave.Equals(claveADejarDeCompartir));
            if (!sigueCompartida) claveADejarDeCompartir.EsCompartida = false;

        }*/
    }
}