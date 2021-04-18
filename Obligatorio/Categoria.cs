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
            set { this.nombre = verificarLargo5a25(value); }
        }

        private string verificarLargo5a25(string dato)
        {
            if (dato.Length < 3 || dato.Length > 15)
            {
                throw new LargoIncorrectoException();
            }
            else
            {
                return dato;
            }
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