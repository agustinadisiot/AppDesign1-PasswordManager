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
            set { this.nombre = verificarLargo5a25(value);}
        }

        public string ContraMaestra {
            get { return this.contraMaestra;}
            set { this.contraMaestra = verificarLargo5a25(value);}
        }

        private string verificarLargo5a25(string dato) 
        {
            if (dato.Length < 5 || dato.Length > 25)
            {
                throw new LargoIncorrectoException();
            }
            else
            {
                return dato;
            }
        }

        public bool validarIgualContraMaestra(string v)
        {
            return v == this.contraMaestra;
        }
    }
}