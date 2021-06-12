using System;
using System.Collections.Generic;
using System.Linq;

namespace LogicaDeNegocio
{
    public class Administrador
    {
        private List<Usuario> _usuarios;

        public Administrador() {
            this._usuarios = new List<Usuario>();
        }

        public bool EsListaUsuariosVacia()
        {
            return this._usuarios.Count() == 0;
        }

        public void AgregarUsuario(Usuario usuario)
        {
            if (usuario.Nombre == null)  throw new ObjetoIncompletoException();
            if (this.YaExisteUsuario(usuario)) throw new ObjetoYaExistenteException();
            this._usuarios.Add(usuario);
            
        }

        public Usuario GetUsuario(Usuario aBuscar)
        {
            if (!this.YaExisteUsuario(aBuscar)) throw new ObjetoInexistenteException();
            return this._usuarios.First(aBuscar.Equals);
        }

        public bool YaExisteUsuario(Usuario buscador)
        {
            return this._usuarios.Contains(buscador);
        }

        public List<Usuario> GetListaUsuarios()
        {
            if(this.EsListaUsuariosVacia()) return null;
            else { 
                return this._usuarios;
            }
        }
    }
}