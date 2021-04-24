using System;
using System.Collections.Generic;

namespace Obligatorio
{
    public class Usuario
    {
        private string nombre;
        private string contraMaestra;
        private bool noAgregoCategorias;
        private List<Categoria> listaCategorias;


        public Usuario()
        {
            noAgregoCategorias = true;
            this.listaCategorias = new List<Categoria>();
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
            else 
            {
                this.noAgregoCategorias = false;
                this.listaCategorias.Add(c1);
            }
           
        }

        public Categoria getCategoria(string nombreCat)
        {
            //Predicate se utiliza en conjunto con una clase, se le da una condicion que retorne true para ser buscado en una List con un List.Find
            Predicate<Categoria> buscadorCategoria = (Categoria c) => { return c.Nombre == nombreCat; };

            Categoria retorno = this.listaCategorias.Find(buscadorCategoria);
            return retorno != null ? retorno : throw new ObjetoInexistenteException();
        }

        public override bool Equals(object obj)
        {
            return true;
        }
    }
}