using System;
using System.Collections.Generic;

namespace Obligatorio
{
    public class AdminContras
    {
        private bool _noAgregoUsuarios;
        private List<Usuario> _usuarios;

        public AdminContras() {
            this._noAgregoUsuarios = true;
            this._usuarios = new List<Usuario>();
        }

        public bool EsListaUsuariosVacia()
        {
            return this._noAgregoUsuarios;
        }

        public void AgregarUsuario(Usuario usuario)
        {
            if (usuario.Nombre == null) {
                throw new ObjetoIncompletoException();
            }
            else {
                this._noAgregoUsuarios = false;
                this._usuarios.Add(usuario);
            }
        }

        public Usuario GetUsuario(string nombre)
        {
            Predicate<Usuario> buscadorNombre = (Usuario usuario) => { return usuario.Nombre == nombre; };
            
            Usuario retorno = this._usuarios.Find(buscadorNombre);
            return retorno != null ? retorno : throw new ObjetoInexistenteException();
        }

        public bool YaExisteUsuario(Usuario buscador)
        {
            return !this.EsListaUsuariosVacia();
        }
    }
}