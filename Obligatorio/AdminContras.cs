using System;
using System.Collections.Generic;

namespace Obligatorio
{
    public class AdminContras
    {
        private bool noAgregoUsuarios;
        private List<Usuario> listaUsuarios;

        public AdminContras() {
            this.noAgregoUsuarios = true;
            this.listaUsuarios = new List<Usuario>();
        }

        public bool EsListaUsuariosVacia()
        {
            return this.noAgregoUsuarios;
        }

        public void AgregarUsuario(Usuario usuario)
        {
            if (usuario.Nombre == null) {
                throw new ObjetoIncompletoException();
            }
            else {
                this.noAgregoUsuarios = false;
                this.listaUsuarios.Add(usuario);
            }
        }

        public Usuario GetUsuario(string nombre)
        {
            Predicate<Usuario> buscadorNombre = (Usuario u) => { return u.Nombre == nombre; };
            
            Usuario retorno = this.listaUsuarios.Find(buscadorNombre);
            return retorno != null ? retorno : throw new ObjetoInexistenteException();
        }
    }
}