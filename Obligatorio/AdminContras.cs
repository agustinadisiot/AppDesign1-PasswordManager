using System;

namespace Obligatorio
{
    public class AdminContras
    {
        private bool noAgregoUsuarios;

        public AdminContras() {
            this.noAgregoUsuarios = true;
        }

        public bool noHayUsuarios()
        {
            return this.noAgregoUsuarios;
        }

        public void agregarUsuario(Usuario u1)
        {
            this.noAgregoUsuarios = false;
        }
    }
}