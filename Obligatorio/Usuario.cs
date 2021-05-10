using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace Obligatorio
{
    public class Usuario
    {
        private List<Categoria> _categorias;
        private string _nombre;
        private string _contraMaestra;
        private const int _largoNombreYContraMinimo = 5;
        private const int _largoNombreYContraMaximo = 25;

        public Usuario()
        {
            this._categorias = new List<Categoria>();
            this.CompartidasConmigo = new List<ClaveCompartida>();
            this.CompartidasPorMi = new List<ClaveCompartida>();
        }

        public string Nombre 
        {   get { return _nombre; }
            set { this._nombre = VerificadoraString.VerificarLargoEntreMinimoYMaximo(value, _largoNombreYContraMinimo, _largoNombreYContraMaximo); }
        }

        public string ContraMaestra {
            get { return this._contraMaestra; }
            set { this._contraMaestra = VerificadoraString.VerificarLargoEntreMinimoYMaximo(value, _largoNombreYContraMinimo, _largoNombreYContraMaximo);}
        }

        public List<ClaveCompartida> CompartidasPorMi { get; set; }

        public List<ClaveCompartida> CompartidasConmigo { get; set; }

        public bool ValidarIgualContraMaestra(string contraMaestraUsuario)
        {
            return contraMaestraUsuario == this.ContraMaestra;
        }

        public bool EsListaCategoriasVacia()
        {
            bool noAgregoCategorias = (this._categorias.Count() == 0);
            return noAgregoCategorias;
        }

        public void AgregarCategoria(Categoria categoria)
        {
            if (categoria.Nombre == null) throw new ObjetoIncompletoException();
            else 
            {
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
            return retorno != null ? retorno : throw new CategoriaInexistenteException();
        }

        public override bool Equals(object objeto)
        {
            if (objeto == null) throw new ObjetoIncompletoException();
            if (objeto.GetType() != this.GetType()) throw new ObjetoIncorrectoException();
            Usuario aIgualar = (Usuario)objeto;
            return aIgualar.Nombre.ToUpper() == this.Nombre.ToUpper();
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

        public bool YaExisteContra(Clave contra)
        {
            return this._categorias.Any(catBuscadora => catBuscadora.YaExisteClave(contra));
        }

        public void AgregarContra(Clave contra, Categoria buscadora)
        {

            bool noTieneSitio = (contra.Sitio == null),
                 noTieneClave = (contra.Codigo == null),
                 noTieneUsuario = (contra.UsuarioClave == null);

            if (noTieneSitio || noTieneClave || noTieneUsuario) throw new ObjetoIncompletoException();
            
            if(this.YaExisteContra(contra)) throw new ObjetoYaExistenteException();

            this.GetCategoria(buscadora).AgregarClave(contra);
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

        public void BorrarContra(Clave aBorrar)
        {
            if (this.EsListaCategoriasVacia()) {
                throw new CategoriaInexistenteException();
            }
            if (!this.YaExisteContra(aBorrar))
            {
                throw new ObjetoInexistenteException();
            }

            List<ClaveCompartida> clavesCompartidas = this.CompartidasPorMi.FindAll(buscadora => buscadora.Clave.Equals(aBorrar));
            foreach(ClaveCompartida aDejarDeCompartir in clavesCompartidas)
            {
                this.DejarDeCompartir(aDejarDeCompartir);
            }

            Categoria contieneContraABorrar = this._categorias.First(categoria => categoria.YaExisteClave(aBorrar));
            contieneContraABorrar.BorrarClave(aBorrar);
        }

        public List<Categoria> GetListaCategorias()
        {
            return this._categorias;
        }

        public Clave GetContra(Clave contraBuscadora)
        {
            if (!YaExisteContra(contraBuscadora)) throw new ObjetoInexistenteException();

            foreach (Categoria categoria in this._categorias)
            {
                if (categoria.YaExisteClave(contraBuscadora))
                {
                    return categoria.GetClave(contraBuscadora);
                }
               
            }

            throw new ObjetoInexistenteException();

        }

        public Tarjeta GetTarjeta(Tarjeta buscadora)
        {
            if (!YaExisteTarjeta(buscadora)) throw new ObjetoInexistenteException();

            foreach (Categoria categoria in this._categorias)
            {
                if (categoria.YaExisteTarjeta(buscadora))
                {
                    return categoria.GetTarjeta(buscadora);
                }

            }

            throw new ObjetoInexistenteException();
        }

        public void BorrarTarjeta(Tarjeta aBorrar)
        {
            if (this.EsListaCategoriasVacia()) {
                throw new CategoriaInexistenteException();
            }

            if (!this.YaExisteTarjeta(aBorrar)) {
                throw new ObjetoInexistenteException();
            }

            Categoria contieneContraABorrar = this._categorias.First(categoria => categoria.YaExisteTarjeta(aBorrar));
            contieneContraABorrar.BorrarTarjeta(aBorrar);
        }

        public void ModificarContra(ClaveAModificar modificar)
        {
            Clave contraVieja = this.GetContra(modificar.ClaveVieja);
            Clave contraNueva = modificar.ClaveNueva;

            if (!contraVieja.Equals(contraNueva) && this.YaExisteContra(contraNueva)) {
                throw new ObjetoYaExistenteException();
            }

            Categoria categoriaVieja = this.GetCategoria(modificar.CategoriaVieja);
            Categoria categoriaNueva = this.GetCategoria(modificar.CategoriaNueva);

            if (categoriaVieja.Equals(categoriaNueva))
            {
                categoriaVieja.ModificarClave(contraVieja, contraNueva);
            }
            else {
                categoriaVieja.BorrarClave(contraVieja);

                categoriaNueva.AgregarClave(contraVieja);
                categoriaNueva.ModificarClave(contraVieja, contraNueva);
            }
        }

        public void ModificarTarjeta(TarjetaAModificar modificar)
        {
            Tarjeta tarjetaVieja = this.GetTarjeta(modificar.TarjetaVieja);
            Tarjeta tarjetaNueva = modificar.TarjetaNueva;


            bool cambioNumero = tarjetaVieja.Numero != tarjetaNueva.Numero;
            if (cambioNumero && this.YaExisteTarjeta(tarjetaNueva)) throw new ObjetoYaExistenteException();

            Categoria categoriaVieja = this.GetCategoria(modificar.CategoriaVieja);
            Categoria categoriaNueva = this.GetCategoria(modificar.CategoriaNueva);

            if (categoriaNueva == categoriaVieja)
            {
                categoriaVieja.ModificarTarjeta(tarjetaVieja, tarjetaNueva);
            }
            else {
                categoriaVieja.BorrarTarjeta(tarjetaVieja);

                categoriaNueva.AgregarTarjeta(tarjetaVieja);
                categoriaNueva.ModificarTarjeta(tarjetaVieja, tarjetaNueva);
            }
        }


        public List<Clave> GetListaClaves()
        {
            List<Clave> claves = new List<Clave>();

            foreach(Categoria categoria in this._categorias)
            {
               claves.AddRange(categoria.GetListaClaves());
            }

            return claves;
        }

        public List<Tarjeta> GetListaTarjetas()
        {
            List<Categoria> categorias = this.GetListaCategorias();
            List<Tarjeta> tarjetasUsuario = new List<Tarjeta>();
            foreach(Categoria categoria in categorias)
            {
                tarjetasUsuario.AddRange(categoria.GetListaTarjetas());
            }
            return tarjetasUsuario;
        }

        public void CompartirClave(ClaveCompartida aCompartir)
        {

            Usuario usuarioACompartir = aCompartir.Usuario;
            Clave claveACompartir = aCompartir.Clave;

            if (this.CompartidasPorMi.Contains(aCompartir)) throw new ObjetoYaExistenteException();

            claveACompartir = this.GetContra(claveACompartir);

            claveACompartir.EsCompartida = true;

            ClaveCompartida guardar = new ClaveCompartida()
            {
                Usuario = usuarioACompartir,
                Clave = claveACompartir
            };
            this.CompartidasPorMi.Add(guardar);

            ClaveCompartida enviar = new ClaveCompartida()
            {
                Usuario = this,
                Clave = claveACompartir
            };

            usuarioACompartir.CompartidasConmigo.Add(enviar);
        }

        public int GetCantidadColor(string color)
        {
            return this.GetListaClavesColor(color).Count;
        }

        public List<Clave> GetContrasDataBreach(List<String> dataBreach)
        {
            List<Clave> completa = this.GetListaClaves();
            
            return completa.FindAll(buscadora=> dataBreach.Contains(buscadora.Codigo));
        }

        public List<Tarjeta> GetTarjetasDataBreach(List<string> dataBreach)
        {
            const int largoTarjetaSinEspacios = 16;
            const string regexEspacio = @"\s+";
            const string vacio = "";

            List<string> potencialesTarjetas = new List<string>();

            foreach (string potencial in dataBreach) {
                string sinEspacio = Regex.Replace(potencial, regexEspacio, vacio);
                bool esNumero = sinEspacio.All(caracter => VerificadoraString.EsNumero(caracter));
                bool tieneLargoTarjeta = sinEspacio.Length == largoTarjetaSinEspacios;

                if (esNumero && tieneLargoTarjeta) {
                    potencialesTarjetas.Add(sinEspacio);
                }
            }
            List<Tarjeta> completa = this.GetListaTarjetas();
            return completa.FindAll(buscadora => potencialesTarjetas.Contains(buscadora.Numero));

        }

        public void DejarDeCompartir(ClaveCompartida aDejarDeCompartir)
        {
            Usuario usuarioADejarDeCompartir = aDejarDeCompartir.Usuario;
            Clave claveADejarDeCompartir = this.GetContra(aDejarDeCompartir.Clave);

            if (!claveADejarDeCompartir.EsCompartida) throw new ObjetoInexistenteException();

            ClaveCompartida guardadaAEliminar = new ClaveCompartida()
            {
                Usuario = usuarioADejarDeCompartir,
                Clave = claveADejarDeCompartir
            };

            ClaveCompartida enviadaAEliminar = new ClaveCompartida()
            {
                Usuario = this,
                Clave = claveADejarDeCompartir
            };

            if (!usuarioADejarDeCompartir.CompartidasConmigo.Contains(enviadaAEliminar)) throw new ObjetoInexistenteException();

            this.CompartidasPorMi.Remove(guardadaAEliminar);

            usuarioADejarDeCompartir.CompartidasConmigo.Remove(enviadaAEliminar);

            bool sigueCompartida = this.CompartidasPorMi.Any(buscadora => buscadora.Clave.Equals(claveADejarDeCompartir));
            if (!sigueCompartida) claveADejarDeCompartir.EsCompartida = false;


        }

        public List<Clave> GetListaClavesColor(string color)
        {
            List<Clave> todasLasClaves = this.GetListaClaves();
            return todasLasClaves.FindAll(buscadora => buscadora.GetNivelSeguridad()==color);
        }

        public Categoria GetCategoriaTarjeta(Tarjeta buscadora)
        {
            List<Categoria> categorias = this.GetListaCategorias();

            foreach (Categoria actual in categorias) {
                if (actual.YaExisteTarjeta(buscadora)) {
                    return actual;
                }
            }

            throw new ObjetoInexistenteException();

        }

        public Categoria GetCategoriaClave(Clave buscadora)
        {
            List<Categoria> categorias = this.GetListaCategorias();

            foreach (Categoria actual in categorias)
            {
                if (actual.YaExisteClave(buscadora))
                {
                    return actual;
                }
            }
            throw new ObjetoInexistenteException();
        }

        public ClaveCompartida GetClaveCompartidaPorMi(ClaveCompartida buscadora)
        {
            if (!this.CompartidasPorMi.Contains(buscadora)) throw new ObjetoInexistenteException();
            return this.CompartidasPorMi.First(aBuscar => aBuscar.Equals(buscadora));
        }

        public ClaveCompartida GetClaveCompartidaConmigo(ClaveCompartida buscadora)
        {
            if (!this.CompartidasConmigo.Contains(buscadora)) throw new ObjetoInexistenteException();
            return this.CompartidasConmigo.First(aBuscar => aBuscar.Equals(buscadora));
        }
    }
}