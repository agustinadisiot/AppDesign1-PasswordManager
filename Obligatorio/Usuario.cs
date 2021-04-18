using System;

namespace Obligatorio
{
    public class Usuario
    {
        private string nombre;
        private string contraMaestra;
        private bool noAgregoCategorias;

        public Usuario()
        {
            noAgregoCategorias = true;
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

        public bool esListaContrasVacia()
        {
            return true;
        }

        public bool esListaCategoriasVacia()
        {
            return this.noAgregoCategorias;
        }

        public void agregarCategoria(Categoria c1)
        {
            this.noAgregoCategorias=false;
        }
    }
}