using System;

namespace Obligatorio
{
    public class Usuario
    {
        private string nombre;
        public Usuario()
        {
        }

        public string Nombre 
        {   get { return nombre;}
            set {
                if (value.Length < 5 || value.Length > 25)
                {
                    throw new LargoIncorrectoException();
                } else {
                    this.nombre = value;
                }
            }
        }

        public string ContraMaestra { get; set; }

        public bool validarContraMestra()
        {
            return true;
        }
    }
}