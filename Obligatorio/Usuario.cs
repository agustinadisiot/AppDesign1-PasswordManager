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
        private bool noAgregoContras;
        private List<Categoria> listaCategorias;


        public Usuario()
        {
            this.noAgregoContras = true;
            this.noAgregoCategorias = true;
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

        public Categoria getCategoria(Categoria aBuscar)
        {
            //Predicate se utiliza en conjunto con una clase, se le da una condicion que retorne true para ser buscado en una List con un List.Find
            Predicate<Categoria> buscadorCategoria = (Categoria categoria) =>
            { return categoria.Equals(aBuscar); };

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

        public void modificarNombreCategoria(Categoria vieja, Categoria nueva)
        {
            if (this.yaExisteCategoria(nueva))
            {
                throw new ObjetoYaExistenteException();
            }
            else {
                Categoria aBuscar = this.getCategoria(vieja);
                aBuscar.Nombre = nueva.Nombre;
            }
        }

        public bool yaExisteCategoria(Categoria aBuscar)
        {
            return this.listaCategorias.Any(buscadora => buscadora.Equals(aBuscar));
        }

        public bool yaExisteContra(Contra contra)
        {
            return this.listaCategorias.Any(catBuscadora => catBuscadora.yaExisteContra(contra));
        }

        public void agregarContra(Contra contra, Categoria buscadora)
        {
            bool noTieneSitio = (contra.Sitio == null),
                 noTieneClave = (contra.Clave == null),
                 noTieneUsuario = (contra.UsuarioContra == null);


            if (noTieneSitio || noTieneClave || noTieneUsuario) throw new ObjetoIncompletoException();
            
            if(this.yaExisteContra(contra)) throw new ObjetoYaExistenteException();

            this.noAgregoContras = false;

            this.getCategoria(buscadora).agregarContra(contra);
        }

        public bool yaExisteTarjeta(Tarjeta tarjeta)
        {
            return this.listaCategorias.Any(catBuscadora => catBuscadora.yaExisteTarjeta(tarjeta));
        }

        public void agregarTarjeta(Tarjeta tarjeta, Categoria categoria)
        {
            bool noTieneNombre = (tarjeta.Nombre == null),
            noTieneSitio = (tarjeta.Tipo == null),
            noTieneNumero = (tarjeta.Numero == null),
            noTieneCodigo = (tarjeta.Codigo == null);

            if (noTieneNombre || noTieneSitio || noTieneNumero || noTieneCodigo) throw new ObjetoIncompletoException();

            if (this.yaExisteTarjeta(tarjeta)) throw new ObjetoYaExistenteException();

            this.getCategoria(categoria).agregarTarjeta(tarjeta);
        }

        public void borrarContra(Contra aBorrar)
        {
            if (this.noAgregoCategorias) {
                throw new CategoriaInexistenteException();
            }
            if (this.noAgregoContras || !this.yaExisteContra(aBorrar))
            {
                throw new ObjetoInexistenteException();
            }
            Categoria contieneContraABorrar = this.listaCategorias.First(categoria => categoria.yaExisteContra(aBorrar));
            contieneContraABorrar.borrarContra(aBorrar);
        }
    }
}