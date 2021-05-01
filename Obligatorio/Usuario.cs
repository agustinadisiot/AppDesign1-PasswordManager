﻿using System;
using System.Collections.Generic;
using System.Linq;

namespace Obligatorio
{
    public class Usuario
    {
        private bool _noAgregoCategorias;
        private bool _noAgregoContras;
        private List<Categoria> _categorias;
        private string _nombre;
        private string _contraMaestra;
        private const int _largoNombreYContraMinimo = 5;
        private const int _largoNombreYContraMaximo = 25;

        public Usuario()
        {
            this._noAgregoContras = true;
            this._noAgregoCategorias = true;
            this._categorias = new List<Categoria>();
        }

        public string Nombre 
        {   get { return _nombre; }
            set { this._nombre = VerificadoraString.VerificarLargoEntreMinimoYMaximo(value, _largoNombreYContraMinimo, _largoNombreYContraMaximo); }
        }

        public string ContraMaestra {
            get { return this._contraMaestra; }
            set { this._contraMaestra = VerificadoraString.VerificarLargoEntreMinimoYMaximo(value, _largoNombreYContraMinimo, _largoNombreYContraMaximo);}
        }

        public bool ValidarIgualContraMaestra(string v)
        {
            return v == this.ContraMaestra;
        }

        public bool EsListaCategoriasVacia()
        {
            return this._noAgregoCategorias;
        }

        public void AgregarCategoria(Categoria categoria)
        {
            if (categoria.Nombre == null) throw new ObjetoIncompletoException();
            else 
            {
                this._noAgregoCategorias = false;
                if (this.YaExisteCategoria(categoria)) {
                    throw new ObjetoYaExistenteException();
                }
                this._categorias.Add(categoria);
            }  
        }

        public Categoria GetCategoria(Categoria aBuscar)
        {
            Predicate<Categoria> buscadorCategoria = (Categoria categoria) =>
            { return categoria.Equals(aBuscar); };

            Categoria retorno = this._categorias.Find(buscadorCategoria);
            return retorno != null ? retorno : throw new ObjetoInexistenteException();
        }

        public override bool Equals(object objeto)
        {
            if (objeto == null) throw new ObjetoIncompletoException();
            if (objeto.GetType() != this.GetType()) throw new ObjetoIncorrectoException();
            Usuario aIgualar = (Usuario)objeto;
            return aIgualar.Nombre == this.Nombre;
        }

        public void ModificarNombreCategoria(Categoria vieja, Categoria nueva)
        {
            if (this.YaExisteCategoria(nueva))
            {
                throw new ObjetoYaExistenteException();
            }
            else {
                Categoria aBuscar = this.GetCategoria(vieja);
                aBuscar.Nombre = nueva.Nombre;
            }
        }

        public bool YaExisteCategoria(Categoria aBuscar)
        {
            return this._categorias.Any(buscadora => buscadora.Equals(aBuscar));
        }

        public bool YaExisteContra(Contra contra)
        {
            return this._categorias.Any(catBuscadora => catBuscadora.YaExisteContra(contra));
        }

        public void AgregarContra(Contra contra, Categoria buscadora)
        {

            bool noTieneSitio = (contra.Sitio == null),
                 noTieneClave = (contra.Clave == null),
                 noTieneUsuario = (contra.UsuarioContra == null);

            if (noTieneSitio || noTieneClave || noTieneUsuario) throw new ObjetoIncompletoException();
            
            if(this.YaExisteContra(contra)) throw new ObjetoYaExistenteException();

            this._noAgregoContras = false;

            this.GetCategoria(buscadora).AgregarContra(contra);
        }

        public bool YaExisteTarjeta(Tarjeta tarjeta)
        {
            return this._categorias.Any(catBuscadora => catBuscadora.YaExisteTarjeta(tarjeta));
        }

        public void AgregarTarjeta(Tarjeta tarjeta, Categoria categoria)
        {
            bool noTieneNombre = (tarjeta.Nombre == null),
            noTieneSitio = (tarjeta.Tipo == null),
            noTieneNumero = (tarjeta.Numero == null),
            noTieneCodigo = (tarjeta.Codigo == null);

            if (noTieneNombre || noTieneSitio || noTieneNumero || noTieneCodigo) throw new ObjetoIncompletoException();

            if (this.YaExisteTarjeta(tarjeta)) throw new ObjetoYaExistenteException();

            this.GetCategoria(categoria).AgregarTarjeta(tarjeta);
        }

        public void BorrarContra(Contra aBorrar)
        {
            if (this._noAgregoCategorias) {
                throw new CategoriaInexistenteException();
            }
            if (this._noAgregoContras || !this.YaExisteContra(aBorrar))
            {
                throw new ObjetoInexistenteException();
            }
            Categoria contieneContraABorrar = this._categorias.First(categoria => categoria.YaExisteContra(aBorrar));
            contieneContraABorrar.BorrarContra(aBorrar);
        }

        public List<Categoria> GetListaCategorias()
        {


            if (this.EsListaCategoriasVacia())
            {
                return null;
            }
            else {
                return this._categorias;
            }
        }
    }
}