using Negocio;
using Repositorio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace LogicaDeNegocio
{
    public class ControladoraUsuario: IControladora<Usuario>
    {
        private const int _largoNombreYClaveMinimo = 5;
        private const int _largoNombreYClaveMaximo = 25;

        public void Verificar(Usuario aVerificar)
        {
            this.VerificarNombre(aVerificar);
            this.VerificarClaveMaestra(aVerificar);
        }

        public void Modificar(Usuario nueva)
        {
            this.Verificar(nueva);
            DataAccessUsuario acceso = new DataAccessUsuario();
            acceso.Modificar(nueva);
        }

        public void VerificarNombre(Usuario aVerificar)
        {   
            VerificadoraString.VerificarLargoEntreMinimoYMaximo(aVerificar.Nombre, _largoNombreYClaveMinimo, _largoNombreYClaveMaximo);
        }

        public void VerificarClaveMaestra(Usuario aVerificar)
        {
            VerificadoraString.VerificarLargoEntreMinimoYMaximo(aVerificar.ClaveMaestra, _largoNombreYClaveMinimo, _largoNombreYClaveMaximo);
        }

        public bool EsIgualClaveMaestra(Usuario usuario1, Usuario usuario2)
        {
            return usuario1.ClaveMaestra == usuario2.ClaveMaestra;
        }

        public bool EsListaCategoriasVacia(Usuario contenedor)
        {
            bool noAgregoCategorias = (contenedor.Categorias.Count() == 0);
            return noAgregoCategorias;
        }

        public void AgregarCategoria(Categoria categoria, Usuario contenedor)
        {
            ControladoraCategoria controladoraCategoria = new ControladoraCategoria();
            controladoraCategoria.Verificar(categoria);
             if (this.YaExisteCategoria(categoria, contenedor))
            {
                throw new ObjetoYaExistenteException();
            }
             contenedor.Categorias.Add(categoria);

            DataAccessUsuario acceso = new DataAccessUsuario();
            acceso.Modificar(contenedor);
        }

        public Categoria GetCategoria(Categoria aBuscar, Usuario contenedor)
        {
            Categoria retorno = contenedor.Categorias.Find(buscadora => buscadora.Equals(aBuscar));
            return retorno != null ? retorno : throw new CategoriaInexistenteException();
        }

        public DataBreach GetUltimoDataBreach(Usuario contenedor)
        {
            return contenedor.DataBreaches.LastOrDefault();
        }

        public void ModificarNombreCategoria(Categoria vieja, Categoria nueva, Usuario contenedor)
        {
            if (this.YaExisteCategoria(nueva, contenedor))
            {
                throw new ObjetoYaExistenteException();
            }
            else
            {
                Categoria aBuscar = this.GetCategoria(vieja, contenedor);
                aBuscar.Nombre = nueva.Nombre;
                ControladoraCategoria controladoraCategoria = new ControladoraCategoria();
                controladoraCategoria.Modificar(aBuscar);
            }
        }

        public bool YaExisteCategoria(Categoria aBuscar, Usuario contenedor)
        {
            return contenedor.Categorias.Any(buscadora => buscadora.Equals(aBuscar));
        }

        public bool YaExisteClave(Clave clave, Usuario contenedor)
        {
            ControladoraCategoria controladora = new ControladoraCategoria();
            return contenedor.Categorias.Any(categoria => controladora.YaExisteClave(clave, categoria));
        }

        public void AgregarClave(Clave clave, Categoria categoria, Usuario contenedor)
        {
            ControladoraClave controladoraClave = new ControladoraClave();
            controladoraClave.Verificar(clave);

            
            if (this.YaExisteClave(clave,contenedor)) throw new ObjetoYaExistenteException();
            if (!this.YaExisteCategoria(categoria, contenedor)) throw new CategoriaInexistenteException();

            Categoria dondeAgregar = this.GetCategoria(categoria,contenedor);

            ControladoraCategoria controladoraCategoria = new ControladoraCategoria();
            controladoraCategoria.Verificar(dondeAgregar);

            controladoraCategoria.AgregarClave(clave, dondeAgregar);

            DataAccessUsuario acceso = new DataAccessUsuario();
            acceso.Modificar(contenedor);
        }

        public bool YaExisteTarjeta(Tarjeta tarjeta, Usuario contenedor)
        {
            ControladoraCategoria controladora = new ControladoraCategoria();
            return contenedor.Categorias.Any(categoria => controladora.YaExisteTarjeta(tarjeta,categoria));
        }

        public void AgregarTarjeta(Tarjeta tarjeta, Categoria categoria, Usuario contenedor)
        {
            ControladoraTarjeta controladoraTarjeta = new ControladoraTarjeta();
            controladoraTarjeta.Verificar(tarjeta);

            if (this.YaExisteTarjeta(tarjeta, contenedor)) throw new ObjetoYaExistenteException();
            if (!this.YaExisteCategoria(categoria, contenedor)) throw new CategoriaInexistenteException();

            ControladoraCategoria controladoraCategoria = new ControladoraCategoria();
            controladoraCategoria.Verificar(categoria);

            Categoria aAgregar = this.GetCategoria(categoria, contenedor);

            controladoraCategoria.AgregarTarjeta(tarjeta, aAgregar);

            DataAccessUsuario acceso = new DataAccessUsuario();
            acceso.Modificar(contenedor);
        }

        public void BorrarClave(Clave ingreso, Usuario contenedor)
        {
            if (this.EsListaCategoriasVacia(contenedor)) {
                throw new CategoriaInexistenteException();
            }
            if (!this.YaExisteClave(ingreso, contenedor))
            {
                throw new ObjetoInexistenteException();
            }

            Clave aBorrar = this.GetClave(ingreso, contenedor);

            List<ClaveCompartida> clavesCompartidas = contenedor.CompartidasPorMi.FindAll(buscadora => aBorrar.Equals(buscadora.Clave));

            foreach(ClaveCompartida aDejarDeCompartir in clavesCompartidas)
            {
                aDejarDeCompartir.Original = contenedor;
                ControladoraAdministrador controladoraAdministrador = new ControladoraAdministrador();
                controladoraAdministrador.DejarDeCompartir(aDejarDeCompartir);
                contenedor.CompartidasPorMi.Remove(aDejarDeCompartir);
            }

            ControladoraCategoria controladoraCategoria = new ControladoraCategoria();

            Categoria contieneClaveABorrar = this.GetCategoriaClave(aBorrar, contenedor);
            controladoraCategoria.BorrarClave(aBorrar, contieneClaveABorrar);

            DataAccessUsuario acceso = new DataAccessUsuario();
            acceso.Modificar(contenedor);
        }

        public List<Categoria> GetListaCategorias(Usuario contenedor)
        {
            return contenedor.Categorias;
        }

        public Clave GetClave(Clave claveBuscadora, Usuario contenedor)
        {
            if (!this.YaExisteClave(claveBuscadora, contenedor)) throw new ObjetoInexistenteException();


            Categoria categoria = this.GetCategoriaClave(claveBuscadora, contenedor);

            ControladoraCategoria controladora = new ControladoraCategoria();

            return controladora.GetClave(claveBuscadora, categoria);
        }

        public Tarjeta GetTarjeta(Tarjeta tarjetaBuscadora, Usuario contenedor)
        {
            if (!this.YaExisteTarjeta(tarjetaBuscadora, contenedor)) throw new ObjetoInexistenteException();


            Categoria categoria = this.GetCategoriaTarjeta(tarjetaBuscadora, contenedor);

            ControladoraCategoria controladora = new ControladoraCategoria();

            return controladora.GetTarjeta(tarjetaBuscadora, categoria);
        }

        public void BorrarTarjeta(Tarjeta aBorrar, Usuario contenedor)
        {
            if (this.EsListaCategoriasVacia(contenedor))
            {
                throw new CategoriaInexistenteException();
            }
            if (!this.YaExisteTarjeta(aBorrar, contenedor))
            {
                throw new ObjetoInexistenteException();
            }

            ControladoraCategoria controladoraCategoria = new ControladoraCategoria();

            Categoria contieneTarjetaABorrar = this.GetCategoriaTarjeta(aBorrar, contenedor);
            controladoraCategoria.BorrarTarjeta(aBorrar, contieneTarjetaABorrar);

            DataAccessUsuario acceso = new DataAccessUsuario();
            acceso.Modificar(contenedor);
        }

        public void ModificarClave(ClaveAModificar modificar, Usuario contenedor)
        {
            Clave claveVieja = this.GetClave(modificar.ClaveVieja, contenedor);
            Clave claveNueva = modificar.ClaveNueva;

            if (!claveVieja.Equals(claveNueva) && this.YaExisteClave(claveNueva, contenedor)) {
                throw new ObjetoYaExistenteException();
            }

            Categoria categoriaVieja = this.GetCategoria(modificar.CategoriaVieja, contenedor);
            Categoria categoriaNueva = this.GetCategoria(modificar.CategoriaNueva, contenedor);

            ControladoraCategoria controladoraCategoria = new ControladoraCategoria();

            if (categoriaVieja.Equals(categoriaNueva))
            {
                controladoraCategoria.ModificarClave(claveVieja, claveNueva, categoriaVieja);
            }
            else {
                categoriaVieja.Claves.Remove(claveVieja);
                controladoraCategoria.Modificar(categoriaVieja);
                controladoraCategoria.AgregarClave(claveVieja,categoriaNueva);
                controladoraCategoria.ModificarClave(claveVieja, claveNueva, categoriaNueva);
            }
            DataAccessUsuario acceso = new DataAccessUsuario();
            acceso.Modificar(contenedor);
        }

        public DataBreach GetDataBreach(DateTime tiempoViejo, Usuario contenedor)
        {

            string formatoFecha = "yyyy'/'MMM'/'dd' 'HH':'mm':'ss";
            foreach (DataBreach actual in contenedor.DataBreaches) {
                DateTime fecha = actual.Fecha;

                string fechaActual = fecha.ToString(formatoFecha);
                string fechaTiempoViejo = tiempoViejo.ToString(formatoFecha);

                if (fechaActual == fechaTiempoViejo) {
                    return actual;
                }

            }
            throw new ObjetoInexistenteException();
        }

        public void ModificarTarjeta(TarjetaAModificar modificar, Usuario contenedor)
        {
            Tarjeta tarjetaVieja = this.GetTarjeta(modificar.TarjetaVieja, contenedor);
            Tarjeta tarjetaNueva = modificar.TarjetaNueva;


            bool cambioNumero = tarjetaVieja.Numero != tarjetaNueva.Numero;
            if (cambioNumero && this.YaExisteTarjeta(tarjetaNueva, contenedor)) throw new ObjetoYaExistenteException();

            Categoria categoriaVieja = this.GetCategoria(modificar.CategoriaVieja, contenedor);
            Categoria categoriaNueva = this.GetCategoria(modificar.CategoriaNueva, contenedor);

            ControladoraCategoria controladoraCategoria = new ControladoraCategoria();

            if (categoriaNueva == categoriaVieja)
            {
                controladoraCategoria.ModificarTarjeta(tarjetaVieja, tarjetaNueva, categoriaVieja);
            }
            else {
                categoriaVieja.Tarjetas.Remove(tarjetaVieja);
                controladoraCategoria.Modificar(categoriaVieja);
                controladoraCategoria.AgregarTarjeta(tarjetaVieja,categoriaNueva);
                controladoraCategoria.ModificarTarjeta(tarjetaVieja, tarjetaNueva,categoriaNueva);
            }
        }

        public List<Clave> GetListaClaves(Usuario contenedor)
        {
            List<Clave> claves = new List<Clave>();
            List<Categoria> categorias = this.GetListaCategorias(contenedor);
            ControladoraCategoria controladoraCategoria = new ControladoraCategoria();
            foreach(Categoria categoria in categorias)
            {
               claves.AddRange(controladoraCategoria.GetListaClaves(categoria));
            }

            return claves;
        }

        public List<Tarjeta> GetListaTarjetas(Usuario contenedor)
        {
            List<Tarjeta> tarjetas = new List<Tarjeta>();
            List<Categoria> categorias = this.GetListaCategorias(contenedor);
            ControladoraCategoria controladoraCategoria = new ControladoraCategoria();
            foreach (Categoria categoria in categorias)
            {
                tarjetas.AddRange(controladoraCategoria.GetListaTarjetas(categoria));
            }
            return tarjetas;
        }

        public int GetCantidadColor(string color, Usuario contenedor)
        {
            return this.GetListaClavesColor(color, contenedor).Count;
        }

        public List<Clave> GetListaClavesColor(string color, Usuario contenedor)
        {
            List<Clave> todasLasClaves = this.GetListaClaves(contenedor);
            NivelSeguridad nivelSeguridad = new NivelSeguridad();
            return todasLasClaves.FindAll(buscadora => nivelSeguridad.GetNivelSeguridad(buscadora.Codigo)==color);
        }

        public Categoria GetCategoriaTarjeta(Tarjeta buscadora, Usuario contenedor)
        {
            List<Categoria> categorias = this.GetListaCategorias(contenedor);

            ControladoraCategoria controladoraCategoria = new ControladoraCategoria();

            foreach (Categoria actual in categorias) {
                if (controladoraCategoria.YaExisteTarjeta(buscadora, actual)) {
                    return actual;
                }
            }

            throw new ObjetoInexistenteException();
        }

        public Categoria GetCategoriaClave(Clave buscadora, Usuario contenedor)
        {
            List<Categoria> categorias = this.GetListaCategorias(contenedor);
            ControladoraCategoria controladoraCategoria = new ControladoraCategoria();
            foreach (Categoria actual in categorias)
            {
                if (controladoraCategoria.YaExisteClave(buscadora, actual))
                {
                    return actual;
                }
            }
            throw new ObjetoInexistenteException();
        }

        public ClaveCompartida GetClaveCompartidaPorMi(ClaveCompartida buscadora, Usuario contenedor)
        {
            bool encontro = false;
            foreach (ClaveCompartida porMi in contenedor.CompartidasPorMi) {
                try
                {
                    if (porMi.Destino != null) {
                        if (buscadora.Equals(porMi)) {
                            return porMi;
                        }
                    }
                }
                catch (Exception e) { };
            }

            if (!encontro) {
                throw new ObjetoInexistenteException();
            }
            return contenedor.CompartidasPorMi.First(aBuscar => aBuscar.Equals(buscadora));
        }

        public ClaveCompartida GetClaveCompartidaConmigo(ClaveCompartida buscadora, Usuario contenedor)
        {
            if (!contenedor.CompartidasConmigo.Contains(buscadora)) throw new ObjetoInexistenteException();
            return contenedor.CompartidasConmigo.First(aBuscar => aBuscar.Equals(buscadora));
        }
    }
}