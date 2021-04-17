using System;

namespace Obligatorio
{
    public class Usuario
    {
        private string nombre;
        private string contraMaestra;


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

        public string ContraMaestra {
            get { return this.contraMaestra;}
            set { this.contraMaestra = value;}
        }

        public bool validarContraMaestra(string v)
        {
            return v == this.contraMaestra;
        }
    }
}