using System;
using System.Collections.Generic;
using System.Linq;

namespace Obligatorio
{
    public class AdminContras
    {
        private List<Usuario> _usuarios;

        public AdminContras() {
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
            Predicate<Usuario> buscadorNombre = (Usuario usuario) => { return usuario.Nombre == aBuscar.Nombre; };
            
            Usuario retorno = this._usuarios.Find(buscadorNombre);
            return retorno != null ? retorno : throw new ObjetoInexistenteException();
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