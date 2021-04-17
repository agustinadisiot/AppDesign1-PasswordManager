using System;

namespace Obligatorio
{
    public class AdminContras
    {
        private Usuario u1;
        private bool noAgregoUsuarios;

        public AdminContras() {
            this.noAgregoUsuarios = true;
            this.u1 = null;
        }

        public bool esListaUsuariosVacia()
        {
            return this.noAgregoUsuarios;
        }

        public void agregarUsuario(Usuario u1)
        {
            this.noAgregoUsuarios = false;
            this.u1 = u1;
        }

        public Usuario getUsuario()
        {
            return this.u1;
        }
    }
}