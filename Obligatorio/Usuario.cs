using System;
using System.Collections.Generic;
using System.Linq;

namespace Obligatorio
{
    public class Usuario
    {
        private bool noAgregoCategorias;
        private bool noAgregoContras;
        private List<Categoria> listaCategorias;
        private string _nombre;
        private string _contraMaestra;

        public Usuario()
        {
            this.noAgregoContras = true;
            this.noAgregoCategorias = true;
            this.listaCategorias = new List<Categoria>();
        }

        public string Nombre 
        {   get { return _nombre; }
            set { this._nombre = VerificadoraString.VerificarLargoXaY(value, 5, 25); }
        }

        public string ContraMaestra {
            get { return this._contraMaestra; }
            set { this._contraMaestra = VerificadoraString.VerificarLargoXaY(value,5,25);}
        }


        public bool ValidarIgualContraMaestra(string v)
        {
            return v == this.ContraMaestra;
        }

        public bool EsListaCategoriasVacia()
        {
            return this.noAgregoCategorias;
        }

        public void AgregarCategoria(Categoria c1)
        {
            if (c1.Nombre == null) throw new ObjetoIncompletoException();
            else 
            {
                this.noAgregoCategorias = false;
                if (this.YaExisteCategoria(c1)) {
                    throw new ObjetoYaExistenteException();
                }
                this.listaCategorias.Add(c1);
            }  
        }

        public Categoria GetCategoria(string nombreCat)
        {
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

        public void ModificarNombreCategoria(string nombreViejo, string nombreNuevo)
        {
            Categoria buscadora = new Categoria(){ Nombre = nombreNuevo };

            if (this.YaExisteCategoria(buscadora))
            {
                throw new ObjetoYaExistenteException();
            }
            else {
                Categoria aBuscar = this.GetCategoria(nombreViejo);
                aBuscar.Nombre = nombreNuevo;
            }
        }

        public bool YaExisteCategoria(Categoria aBuscar)
        {
            return this.listaCategorias.Any(buscadora => buscadora.Equals(aBuscar));
        }

        public bool YaExisteContra(Contra contra)
        {
            return this.listaCategorias.Any(catBuscadora => catBuscadora.YaExisteContra(contra));
        }

        public void AgregarContra(Contra contra, string categoria)
        {
            bool noTieneSitio = (contra.Sitio == null),
                 noTieneClave = (contra.Clave == null),
                 noTieneUsuario = (contra.UsuarioContra == null);


            if (noTieneSitio || noTieneClave || noTieneUsuario) throw new ObjetoIncompletoException();
            
            if(this.YaExisteContra(contra)) throw new ObjetoYaExistenteException();

            this.noAgregoContras = false;

            this.GetCategoria(categoria).AgregarContra(contra);
        }

        public bool YaExisteTarjeta(Tarjeta tarjeta)
        {
            return this.listaCategorias.Any(catBuscadora => catBuscadora.YaExisteTarjeta(tarjeta));
        }

        public void AgregarTarjeta(Tarjeta tarjeta, string categoria)
        {
            bool noTieneNombre = (tarjeta.Nombre == null),
            noTieneSitio = (tarjeta.Tipo == null),
            noTieneNumero = (tarjeta.Numero == null),
            noTieneCodigo = (tarjeta.Codigo == null);

            if (noTieneNombre || noTieneSitio || noTieneNumero || noTieneCodigo) throw new ObjetoIncompletoException();

            if (this.YaExisteTarjeta(tarjeta)) throw new ObjetoYaExistenteException();

            this.GetCategoria(categoria).AgregarTarjeta(tarjeta);
        }

        public void BorrarContra(string paginaContra, string usuarioContra)
        {
            Contra aBorrar = new Contra() 
            {
                Sitio = paginaContra,
                UsuarioContra = usuarioContra
            };

            if (this.noAgregoCategorias) {
                throw new CategoriaInexistenteException();
            }
            if (this.noAgregoContras || !this.YaExisteContra(aBorrar))
            {
                throw new ObjetoInexistenteException();
            }
            Categoria contieneContraABorrar = this.listaCategorias.First(categoria => categoria.YaExisteContra(aBorrar));
            contieneContraABorrar.BorrarContra(paginaContra,usuarioContra);
        }
    }
}