using System;

namespace Obligatorio
{
    public class Categoria
    {
        private string nombre;
        private bool noAgregoContra;

        public Categoria()
        {
            noAgregoContra = true;
        }

        public string Nombre
        {
            get { return nombre; }
            set { this.nombre = VerificadoraString.verificarLargoXaY(value, 3, 15); }
        }


        public bool esListaContrasVacia()
        {
            return noAgregoContra;
        }

        public void agregarContra(Contra contra1)
        {
            this.noAgregoContra = false;
        }
    }
}