﻿using System;
using System.Collections.Generic;
using System.Linq;

namespace Obligatorio
{
    public class Usuario
    {
        private string nombre;
        private string contraMaestra;
        private bool noAgregoCategorias;
        private List<Categoria> listaCategorias;
        private bool contraAgregada;


        public Usuario()
        {
            noAgregoCategorias = true;
            contraAgregada = false;
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
                if (this.yaExisteCategoria(c1)) {
                    throw new ObjetoYaExistenteException();
                }
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
            if (obj == null) throw new ObjetoIncompletoException();
            if (obj.GetType() != this.GetType()) throw new ObjetoIncorrectoException();
            Usuario aIgualar = (Usuario)obj;
            return aIgualar.Nombre == this.Nombre;
        }

        public void modificarNombreCategoria(string nombreViejo, string nombreNuevo)
        {
            Categoria buscadora = new Categoria(){ Nombre = nombreNuevo };

            if (this.yaExisteCategoria(buscadora))
            {
                throw new ObjetoYaExistenteException();
            }
            else {
                //.getCategoria tira una Excepcion de OBjetoInexistenteException si no existe la categoria buscada.
                Categoria aBuscar = this.getCategoria(nombreViejo);
                aBuscar.Nombre = nombreNuevo;
            }


            
        }

        public bool yaExisteCategoria(Categoria aBuscar)
        {
            return this.listaCategorias.Any(buscadora => buscadora.Equals(aBuscar));
        }

        public bool yaExisteContra(Contra contraIgual)
        {
            if (this.contraAgregada) return true;
            else
            {
                return this.listaCategorias.Any(catBuscadora => catBuscadora.yaExisteContra(contraIgual));
            }
        }

        public void agregarContra(Contra contra)
        {
            bool noTieneSitio = (contra.Sitio == null),
                 noTieneClave = (contra.Clave == null);

            if (noTieneSitio || noTieneClave ) throw new ObjetoIncompletoException();
            this.contraAgregada = true;
        }
    }
}