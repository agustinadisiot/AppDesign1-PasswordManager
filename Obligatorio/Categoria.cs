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
            set
            {
                if (value.Length < 3 || value.Length > 15)
                {
                    throw new LargoIncorrectoException();
                }
                else
                {
                    this.nombre = value;
                }
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