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

            Categoria contieneContraABorrar = this._categorias.First(categoria => categoria.YaExisteContra(aBorrar));
            contieneContraABorrar.BorrarContra(aBorrar);
        }

        public List<Categoria> GetListaCategorias()
        {
            return this._categorias;
        }

        public Contra GetContra(Contra contraBuscadora)
        {
            if (!YaExisteContra(contraBuscadora)) throw new ObjetoInexistenteException();

            foreach (Categoria categoria in this._categorias)
            {
                if (categoria.YaExisteContra(contraBuscadora))
                {
                    return categoria.GetContra(contraBuscadora);
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

        public void ModificarContra(Contra contraVieja, Contra contraNueva)
        {
            if (!this.YaExisteContra(contraVieja)) throw new ObjetoInexistenteException();
            if (this.YaExisteContra(contraNueva)) throw new ObjetoYaExistenteException();
            Contra aModificar = this.GetContra(contraVieja);
            aModificar.UsuarioContra = contraNueva.UsuarioContra;
            aModificar.Clave = contraNueva.Clave;
            aModificar.Sitio = contraNueva.Sitio;
            aModificar.Nota = contraNueva.Nota;
        }

        public void ModificarTarjeta(Tarjeta tarjetaVieja, Tarjeta tarjetaNueva)
        {
            if (this.YaExisteTarjeta(tarjetaNueva)) throw new ObjetoYaExistenteException();
            Tarjeta aModificar = this.GetTarjeta(tarjetaVieja);
            aModificar.Nombre = tarjetaNueva.Nombre;
            aModificar.Numero = tarjetaNueva.Numero;
            aModificar.Tipo = tarjetaNueva.Tipo;
            aModificar.Codigo = tarjetaNueva.Codigo;
            aModificar.Nota = tarjetaNueva.Nota;
            aModificar.Vencimiento = tarjetaNueva.Vencimiento;
        }

        public List<Contra> GetListaClaves()
        {
            List<Contra> claves = new List<Contra>();

            foreach(Categoria categoria in this._categorias)
            {
               claves.AddRange(categoria.GetListaContras());
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
            Contra claveACompartir = aCompartir.Clave;

            if (!this.YaExisteContra(claveACompartir)) throw new ObjetoInexistenteException();

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
            List<Contra> clavesUsuario = this.GetListaClaves();
            int cantidadColor = 0;
            foreach(Contra clave in clavesUsuario)
            {
                if (clave.GetNivelSeguridad() == color) cantidadColor++;
            }
            return cantidadColor;
        }

        public List<Contra> GetContrasDataBreach(List<String> dataBreach)
        {
            List<Contra> completa = this.GetListaClaves();
            
            return completa.FindAll(buscadora=> dataBreach.Contains(buscadora.Clave));
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
            Contra claveADejarDeCompartir = this.GetContra(aDejarDeCompartir.Clave);

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

        public List<Contra> GetListaClavesColor(string color)
        {
            List<Contra> todasLasClaves = this.GetListaClaves();
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

        public Categoria GetCategoriaClave(Contra buscadora)
        {
            List<Categoria> categorias = this.GetListaCategorias();

            foreach (Categoria actual in categorias)
            {
                if (actual.YaExisteContra(buscadora))
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
    }
}