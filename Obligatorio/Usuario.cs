using System;

namespace Obligatorio
{
    public class Usuario
    {
        private string nombre;
        private string contraMaestra;
        private bool noAgregoCategorias;
        private Categoria categoria;

        public Usuario()
        {
            noAgregoCategorias = true;
        }

        public string Nombre 
        {   get { return nombre;}
            set { this.nombre = VerificadoraString.verificarLargoXaY(value, 5, 25); }
        }

        public string ContraMaestra {
            get { return this.contraMaestra;}
            set { this.contraMaestra = VerificadoraString.verificarLargoXaY(value,5,25);}
        }


        public bool validarIgualContraMaestra(string v)
        {
            return v == this.contraMaestra;
        }

        public bool esListaCategoriasVacia()
        {
            return this.noAgregoCategorias;
        }

        public void agregarCategoria(Categoria c1)
        {
            if (c1.Nombre == null) throw new ObjetoIncompletoException();
            this.noAgregoCategorias=false;
            this.categoria = c1;
        }

        public Categoria getCategoria(string v)
        {
            return this.categoria;
        }
    }
}