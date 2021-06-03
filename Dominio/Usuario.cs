using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace Dominio
{
    public class Usuario
    {
        private List<Categoria> _categorias;
        private string _nombre;
        private string _claveMaestra;
        private const int _largoNombreYClaveMinimo = 5;
        private const int _largoNombreYClaveMaximo = 25;
        private DataBreach _ultimoDataBreach;


        public Usuario()
        {
            this._categorias = new List<Categoria>();
            this.CompartidasConmigo = new List<ClaveCompartida>();
            this.CompartidasPorMi = new List<ClaveCompartida>();
        }

        public string Nombre 
        {   get { return _nombre; }
            set { this._nombre = VerificadoraString.VerificarLargoEntreMinimoYMaximo(value, _largoNombreYClaveMinimo, _largoNombreYClaveMaximo); }
        }

        public string ClaveMaestra {
            get { return this._claveMaestra; }
            set { this._claveMaestra = VerificadoraString.VerificarLargoEntreMinimoYMaximo(value, _largoNombreYClaveMinimo, _largoNombreYClaveMaximo);}
        }

        public List<ClaveCompartida> CompartidasPorMi { get; set; }

        public List<ClaveCompartida> CompartidasConmigo { get; set; }

        public bool ValidarIgualClaveMaestra(string claveMaestraUsuario)
        {
            return claveMaestraUsuario == this.ClaveMaestra;
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

        public DataBreach GetUltimoDataBreach()
        {
            return this._ultimoDataBreach;
        }

        public void agregarDataBreach(List<string> filtradas)
        {
            DataBreach nuevoBreach = new DataBreach()
            {
                Tarjetas = this.GetTarjetasDataBreach(filtradas),
                Claves = this.GetClavesDataBreach(filtradas)
            };
            this._ultimoDataBreach = nuevoBreach;
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

        public bool YaExisteClave(Clave clave)
        {
            return this._categorias.Any(catBuscadora => catBuscadora.YaExisteClave(clave));
        }

        public void AgregarClave(Clave clave, Categoria buscadora)
        {

            bool noTieneSitio = (clave.Sitio == null),
                 noTieneClave = (clave.Codigo == null),
                 noTieneUsuario = (clave.UsuarioClave == null);

            if (noTieneSitio || noTieneClave || noTieneUsuario) throw new ObjetoIncompletoException();
            
            if(this.YaExisteClave(clave)) throw new ObjetoYaExistenteException();

            this.GetCategoria(buscadora).AgregarClave(clave);
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

        public void BorrarClave(Clave aBorrar)
        {
            if (this.EsListaCategoriasVacia()) {
                throw new CategoriaInexistenteException();
            }
            if (!this.YaExisteClave(aBorrar))
            {
                throw new ObjetoInexistenteException();
            }

            List<ClaveCompartida> clavesCompartidas = this.CompartidasPorMi.FindAll(buscadora => buscadora.Clave.Equals(aBorrar));
            foreach(ClaveCompartida aDejarDeCompartir in clavesCompartidas)
            {
                this.DejarDeCompartir(aDejarDeCompartir);
            }

            Categoria contieneClaveABorrar = this._categorias.First(categoria => categoria.YaExisteClave(aBorrar));
            contieneClaveABorrar.BorrarClave(aBorrar);
        }

        public List<Categoria> GetListaCategorias()
        {
            return this._categorias;
        }

        public Clave GetClave(Clave claveBuscadora)
        {
            if (!YaExisteClave(claveBuscadora)) throw new ObjetoInexistenteException();

            foreach (Categoria categoria in this._categorias)
            {
                if (categoria.YaExisteClave(claveBuscadora))
                {
                    return categoria.GetClave(claveBuscadora);
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

            Categoria contieneClaveABorrar = this._categorias.First(categoria => categoria.YaExisteTarjeta(aBorrar));
            contieneClaveABorrar.BorrarTarjeta(aBorrar);
        }

        public void ModificarClave(ClaveAModificar modificar)
        {
            Clave claveVieja = this.GetClave(modificar.ClaveVieja);
            Clave claveNueva = modificar.ClaveNueva;

            if (!claveVieja.Equals(claveNueva) && this.YaExisteClave(claveNueva)) {
                throw new ObjetoYaExistenteException();
            }

            Categoria categoriaVieja = this.GetCategoria(modificar.CategoriaVieja);
            Categoria categoriaNueva = this.GetCategoria(modificar.CategoriaNueva);

            if (categoriaVieja.Equals(categoriaNueva))
            {
                categoriaVieja.ModificarClave(claveVieja, claveNueva);
            }
            else {
                categoriaVieja.BorrarClave(claveVieja);

                categoriaNueva.AgregarClave(claveVieja);
                categoriaNueva.ModificarClave(claveVieja, claveNueva);
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

            claveACompartir = this.GetClave(claveACompartir);

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

        public List<Clave> GetClavesDataBreach(List<String> dataBreach)
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
            Clave claveADejarDeCompartir = this.GetClave(aDejarDeCompartir.Clave);

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