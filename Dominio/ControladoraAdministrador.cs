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
    }
}