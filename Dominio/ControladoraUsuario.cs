using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace LogicaDeNegocio
{
    public class ControladoraUsuario
    {
        private string _nombre;
        private string _claveMaestra;
        private const int _largoNombreYClaveMinimo = 5;
        private const int _largoNombreYClaveMaximo = 25;

        public List<ControladoraCategoria> Categorias { get; set; }

        public ControladoraUsuario()
        {
            this.Categorias = new List<ControladoraCategoria>();
            this.CompartidasConmigo = new List<ClaveCompartida>();
            this.CompartidasPorMi = new List<ClaveCompartida>();
            this.DataBreaches = new List<DataBreach>();
        }

        public int Id { get; set; }

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

        public List<DataBreach> DataBreaches { get; set; }

        public bool ValidarIgualClaveMaestra(string claveMaestraUsuario)
        {
            return claveMaestraUsuario == this.ClaveMaestra;
        }

        public bool EsListaCategoriasVacia()
        {
            bool noAgregoCategorias = (this.Categorias.Count() == 0);
            return noAgregoCategorias;
        }

        public void AgregarCategoria(ControladoraCategoria categoria)
        {
            if (categoria.Nombre == null) throw new ObjetoIncompletoException();
            else 
            {
                if (this.YaExisteCategoria(categoria)) {
                    throw new ObjetoYaExistenteException();
                }
                this.Categorias.Add(categoria);
            }  
        }

        public ControladoraCategoria GetCategoria(ControladoraCategoria aBuscar)
        {
            Predicate<ControladoraCategoria> buscadorCategoria = (ControladoraCategoria categoria) =>
            { return categoria.Equals(aBuscar); };

            ControladoraCategoria retorno = this.Categorias.Find(buscadorCategoria);
            return retorno != null ? retorno : throw new CategoriaInexistenteException();
        }

        public DataBreach GetUltimoDataBreach()
        {
            return this.DataBreaches.LastOrDefault();
        }

        public void agregarDataBreach(List<Filtrada> filtradas, DateTime tiempoBreach)
        {
            ControladoraDataBreach logicaDataBreach = new ControladoraDataBreach();
            DataBreach nuevoBreach = new DataBreach()
            {
                Tarjetas = logicaDataBreach.FiltrarTarjetas(filtradas, this.GetListaTarjetas()),
                Claves = logicaDataBreach.FiltrarClaves(filtradas, this.GetListaClaves()),
                Filtradas = filtradas,
                Fecha = tiempoBreach
            };
            this.DataBreaches.Add(nuevoBreach);
        }

        public override bool Equals(object objeto)
        {
            if (objeto == null) throw new ObjetoIncompletoException();
            if (objeto.GetType() != this.GetType()) throw new ObjetoIncorrectoException();
            ControladoraUsuario aIgualar = (ControladoraUsuario)objeto;
            return aIgualar.Nombre.ToUpper() == this.Nombre.ToUpper();
        }

        public void ModificarNombreCategoria(ControladoraCategoria vieja, ControladoraCategoria nueva)
        {
            if (this.YaExisteCategoria(nueva))
            {
                throw new ObjetoYaExistenteException();
            }
            else {
                ControladoraCategoria aBuscar = this.GetCategoria(vieja);
                aBuscar.Nombre = nueva.Nombre;
            }
        }

        public bool YaExisteCategoria(ControladoraCategoria aBuscar)
        {
            return this.Categorias.Any(buscadora => buscadora.Equals(aBuscar));
        }

        public bool YaExisteClave(ControladoraClave clave)
        {
            return this.Categorias.Any(catBuscadora => catBuscadora.YaExisteClave(clave));
        }

        public void AgregarClave(ControladoraClave clave, ControladoraCategoria buscadora)
        {

            bool noTieneSitio = (clave.VerificarSitio == null),
                 noTieneClave = (clave.Codigo == null),
                 noTieneUsuario = (clave.verificarUsuarioClave == null);

            if (noTieneSitio || noTieneClave || noTieneUsuario) throw new ObjetoIncompletoException();
            
            if(this.YaExisteClave(clave)) throw new ObjetoYaExistenteException();

            this.GetCategoria(buscadora).AgregarClave(clave);
        }

        public bool YaExisteTarjeta(ControladoraTarjeta tarjeta)
        {
            return this.Categorias.Any(catBuscadora => catBuscadora.YaExisteTarjeta(tarjeta));
        }

        public void AgregarTarjeta(ControladoraTarjeta tarjeta, ControladoraCategoria categoria)
        {
            bool noTieneNombre = (tarjeta.Nombre == null),
            noTieneSitio = (tarjeta.Tipo == null),
            noTieneNumero = (tarjeta.Numero == null),
            noTieneCodigo = (tarjeta.Codigo == null);

            if (noTieneNombre || noTieneSitio || noTieneNumero || noTieneCodigo) throw new ObjetoIncompletoException();

            if (this.YaExisteTarjeta(tarjeta)) throw new ObjetoYaExistenteException();

            this.GetCategoria(categoria).AgregarTarjeta(tarjeta);
        }

        public void BorrarClave(ControladoraClave aBorrar)
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

            ControladoraCategoria contieneClaveABorrar = this.Categorias.First(categoria => categoria.YaExisteClave(aBorrar));
            contieneClaveABorrar.BorrarClave(aBorrar);
        }

        public List<ControladoraCategoria> GetListaCategorias()
        {
            return this.Categorias;
        }

        public ControladoraClave GetClave(ControladoraClave claveBuscadora)
        {
            if (!YaExisteClave(claveBuscadora)) throw new ObjetoInexistenteException();

            foreach (ControladoraCategoria categoria in this.Categorias)
            {
                if (categoria.YaExisteClave(claveBuscadora))
                {
                    return categoria.GetClave(claveBuscadora);
                }
               
            }

            throw new ObjetoInexistenteException();

        }

        public ControladoraTarjeta GetTarjeta(ControladoraTarjeta buscadora)
        {
            if (!YaExisteTarjeta(buscadora)) throw new ObjetoInexistenteException();

            foreach (ControladoraCategoria categoria in this.Categorias)
            {
                if (categoria.YaExisteTarjeta(buscadora))
                {
                    return categoria.GetTarjeta(buscadora);
                }

            }

            throw new ObjetoInexistenteException();
        }

        public void BorrarTarjeta(ControladoraTarjeta aBorrar)
        {
            if (this.EsListaCategoriasVacia()) {
                throw new CategoriaInexistenteException();
            }

            if (!this.YaExisteTarjeta(aBorrar)) {
                throw new ObjetoInexistenteException();
            }

            ControladoraCategoria contieneClaveABorrar = this.Categorias.First(categoria => categoria.YaExisteTarjeta(aBorrar));
            contieneClaveABorrar.BorrarTarjeta(aBorrar);
        }

        public void ModificarClave(ClaveAModificar modificar)
        {
            ControladoraClave claveVieja = this.GetClave(modificar.ClaveVieja);
            ControladoraClave claveNueva = modificar.ClaveNueva;

            if (!claveVieja.Equals(claveNueva) && this.YaExisteClave(claveNueva)) {
                throw new ObjetoYaExistenteException();
            }

            ControladoraCategoria categoriaVieja = this.GetCategoria(modificar.CategoriaVieja);
            ControladoraCategoria categoriaNueva = this.GetCategoria(modificar.CategoriaNueva);

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

        public DataBreach GetDataBreach(DateTime tiempoViejo)
        {
            return this.DataBreaches.First(d=> d.Fecha == tiempoViejo);
        }

        public void ModificarTarjeta(TarjetaAModificar modificar)
        {
            ControladoraTarjeta tarjetaVieja = this.GetTarjeta(modificar.TarjetaVieja);
            ControladoraTarjeta tarjetaNueva = modificar.TarjetaNueva;


            bool cambioNumero = tarjetaVieja.Numero != tarjetaNueva.Numero;
            if (cambioNumero && this.YaExisteTarjeta(tarjetaNueva)) throw new ObjetoYaExistenteException();

            ControladoraCategoria categoriaVieja = this.GetCategoria(modificar.CategoriaVieja);
            ControladoraCategoria categoriaNueva = this.GetCategoria(modificar.CategoriaNueva);

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


        public List<ControladoraClave> GetListaClaves()
        {
            List<ControladoraClave> claves = new List<ControladoraClave>();

            foreach(ControladoraCategoria categoria in this.Categorias)
            {
               claves.AddRange(categoria.GetListaClaves());
            }

            return claves;
        }

        public List<ControladoraTarjeta> GetListaTarjetas()
        {
            List<ControladoraCategoria> categorias = this.GetListaCategorias();
            List<ControladoraTarjeta> tarjetasUsuario = new List<ControladoraTarjeta>();
            foreach(ControladoraCategoria categoria in categorias)
            {
                tarjetasUsuario.AddRange(categoria.GetListaTarjetas());
            }
            return tarjetasUsuario;
        }

        public void CompartirClave(ClaveCompartida aCompartir)
        {

            ControladoraUsuario usuarioDestino = aCompartir.Destino;
            ControladoraUsuario usuarioOriginal = aCompartir.Original;
            ControladoraClave claveACompartir = aCompartir.Clave;

            if (this.CompartidasPorMi.Contains(aCompartir)) throw new ObjetoYaExistenteException();

            claveACompartir = this.GetClave(claveACompartir);

            claveACompartir.EsCompartida = true;

            ClaveCompartida guardar = new ClaveCompartida()
            {
                Original = usuarioOriginal,
                Destino = usuarioDestino,
                Clave = claveACompartir
            };

            this.CompartidasPorMi.Add(guardar);

            usuarioDestino.CompartidasConmigo.Add(guardar);
        }

        public int GetCantidadColor(string color)
        {
            return this.GetListaClavesColor(color).Count;
        }


        public void DejarDeCompartir(ClaveCompartida aDejarDeCompartir)
        {
            ControladoraUsuario usuarioOriginal = aDejarDeCompartir.Original;
            ControladoraUsuario usuarioDestino = aDejarDeCompartir.Destino;
            ControladoraClave claveADejarDeCompartir = this.GetClave(aDejarDeCompartir.Clave);

            if (!claveADejarDeCompartir.EsCompartida) throw new ObjetoInexistenteException();

            ClaveCompartida aEliminar = new ClaveCompartida()
            {
                Original = usuarioOriginal,
                Destino = usuarioDestino,
                Clave = claveADejarDeCompartir
            };

            if (!usuarioDestino.CompartidasConmigo.Contains(aEliminar)) throw new ObjetoInexistenteException();

            this.CompartidasPorMi.Remove(aEliminar);

            usuarioDestino.CompartidasConmigo.Remove(aEliminar);

            bool sigueCompartida = this.CompartidasPorMi.Any(buscadora => buscadora.Clave.Equals(claveADejarDeCompartir));
            if (!sigueCompartida) claveADejarDeCompartir.EsCompartida = false;

        }

        public List<ControladoraClave> GetListaClavesColor(string color)
        {
            List<ControladoraClave> todasLasClaves = this.GetListaClaves();
            NivelSeguridad nivelSeguridad = new NivelSeguridad();
            return todasLasClaves.FindAll(buscadora => nivelSeguridad.GetNivelSeguridad(buscadora.Codigo)==color);
        }

        public ControladoraCategoria GetCategoriaTarjeta(ControladoraTarjeta buscadora)
        {
            List<ControladoraCategoria> categorias = this.GetListaCategorias();

            foreach (ControladoraCategoria actual in categorias) {
                if (actual.YaExisteTarjeta(buscadora)) {
                    return actual;
                }
            }

            throw new ObjetoInexistenteException();

        }

        public ControladoraCategoria GetCategoriaClave(ControladoraClave buscadora)
        {
            List<ControladoraCategoria> categorias = this.GetListaCategorias();

            foreach (ControladoraCategoria actual in categorias)
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

        public bool EsClaveRepetida(string aVerificar)
        {
            List<ControladoraClave> clavesUsuario = this.GetListaClaves();
            foreach (ControladoraClave claveAComparar in clavesUsuario)
            {
                if (claveAComparar.Codigo.Equals(aVerificar))
                {
                    return true;
                }
            }

            return false;
        }

        public bool EsClaveSegura(string aVerificar)
        {
            NivelSeguridad nivelSeguridad = new NivelSeguridad();
            ColorNivelSeguridad color = new ColorNivelSeguridad();

            string colorAVerificar = nivelSeguridad.GetNivelSeguridad(aVerificar);
            if (colorAVerificar.Equals(color.VerdeClaro) || colorAVerificar.Equals(color.VerdeOscuro))
            {
                return true;
            }
            return false;
        }

        public void ClaveCumpleRequerimientos(string aVerificar)
        {
            if (this.EsClaveRepetida(aVerificar)) throw new ClaveDuplicadaException();
            if (!this.EsClaveSegura(aVerificar)) throw new ClaveNoSeguraException();
        }
    }
}