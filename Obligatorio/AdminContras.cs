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

        public bool esListaUsuariosVacia()
        {
            return this.noAgregoUsuarios;
        }

        public void agregarUsuario(Usuario u1)
        {
            if (u1.Nombre == null) {
                throw new ObjetoIncompletoException();
            }
            else {
                this.noAgregoUsuarios = false;
                this.listaUsuarios.Add(u1);
            }
        }

        public Usuario getUsuario(string nombre)
        {
            //Predicate se utiliza en conjunto con una clase, se le da una condicion que retorne true para ser buscado en una List con un List.Find
            Predicate<Usuario> buscadorNombre = (Usuario u) => { return u.Nombre == nombre; };
            
            Usuario retorno = this.listaUsuarios.Find(buscadorNombre);
            return retorno != null ? retorno : throw new ObjetoInexistenteException();
        }
    }
}