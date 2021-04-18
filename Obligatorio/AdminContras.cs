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
            if (u1.Nombre == null) {
                throw new ObjetoIncompletoException();
            }
            else if(this.noAgregoUsuarios){
                this.noAgregoUsuarios = false;
                this.u1 = u1;
            }
        }

        public Usuario getUsuario(string v)
        {
            return this.u1;
        }
    }
}