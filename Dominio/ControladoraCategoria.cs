using System;
using System.Collections.Generic;

namespace LogicaDeNegocio
{
    public class ControladoraCategoria
    {
       // private List<Clave> _claves;
        //private List<Tarjeta> _tarjetas;
        private string _nombre;
        private const int _largoNombreMinimo = 3;
        private const int _largoNombreMaximo = 15;

        public ControladoraCategoria()
        {
            this.Claves = new List<ControladoraClave>();
            this.Tarjetas = new List<ControladoraTarjeta>();
        }

        public string Nombre
        {
            get { return _nombre; }
            set { this._nombre = VerificadoraString.VerificarLargoEntreMinimoYMaximo(value, _largoNombreMinimo, _largoNombreMaximo); }
        }

        public int Id { get; set; }

        public List<ControladoraClave> Claves { get; set; }
        public List<ControladoraTarjeta> Tarjetas { get; set; }

        public bool EsListaClavesVacia()
        {
            bool noHayClaves = (this.Claves.Count == 0);
            return noHayClaves;
        }

        public void AgregarClave(ControladoraClave claveIngresada)
        {
            bool noTieneSitio = (claveIngresada.VerificarSitio == null),
                 noTieneClave = (claveIngresada.Codigo == null),
                 noTieneUsuario = (claveIngresada.verificarUsuarioClave == null);


            if (noTieneSitio || noTieneClave || noTieneUsuario ) throw new ObjetoIncompletoException();
            if (this.YaExisteClave(claveIngresada)) throw new ObjetoYaExistenteException();
            this.Claves.Add(claveIngresada);
        }

        public void BorrarClave(ControladoraClave claveABorrar)
        {
            if (this.EsListaClavesVacia()) {
                throw new ObjetoInexistenteException();
            }
            if (!this.YaExisteClave(claveABorrar)) {
                throw new ObjetoInexistenteException();
            }
            this.Claves.Remove(claveABorrar);
        }

        public ControladoraClave GetClave(ControladoraClave aBuscar)
        {
            if (this.EsListaClavesVacia()) {
                throw new ObjetoInexistenteException();
            }

            Predicate<ControladoraClave> buscadorClave = (ControladoraClave clave) => 
            {
                return clave.Equals(aBuscar);
            };

            ControladoraClave retorno = this.Claves.Find(buscadorClave);
            return retorno != null ? retorno : throw new ObjetoInexistenteException();
        }

        public List<ControladoraClave> GetListaClaves()
        {
            return this.Claves;
        }

        public override bool Equals(object objeto)
        {
            if (objeto == null) throw new ObjetoIncompletoException();
            if (objeto.GetType() != this.GetType()) throw new ObjetoIncorrectoException();
            ControladoraCategoria aIgualar = (ControladoraCategoria)objeto;
            return aIgualar.Nombre.ToUpper() == this.Nombre.ToUpper();
        }

        public bool EsListaTarjetasVacia()
        {
            bool noHayTarjetas = this.Tarjetas.Count == 0;
            return noHayTarjetas;
        }

        public void AgregarTarjeta(ControladoraTarjeta tarjetaIngresada)
        {
            bool noTieneNombre = (tarjetaIngresada.Nombre == null),
                noTieneSitio = (tarjetaIngresada.Tipo == null),
                noTieneNumero = (tarjetaIngresada.Numero == null),
                noTieneCodigo = (tarjetaIngresada.Codigo == null),
                noTieneVencimiento = (tarjetaIngresada.Vencimiento.Equals(DateTime.MinValue));

            if (noTieneNombre || noTieneSitio || noTieneNumero || noTieneCodigo || noTieneVencimiento) throw new ObjetoIncompletoException();

            if (this.YaExisteTarjeta(tarjetaIngresada)) throw new ObjetoYaExistenteException();
           
            this.Tarjetas.Add(tarjetaIngresada);
        }

        public ControladoraTarjeta GetTarjeta(ControladoraTarjeta aBuscar)
        {
            if (this.EsListaTarjetasVacia()) throw new ObjetoInexistenteException();
            Predicate<ControladoraTarjeta> buscadorTarjeta = (ControladoraTarjeta tarjeta) =>
            {
                return tarjeta.Equals(aBuscar);
            };

            ControladoraTarjeta retorno = this.Tarjetas.Find(buscadorTarjeta);
            return retorno != null ? retorno : throw new ObjetoInexistenteException();
        }

        public List<ControladoraTarjeta> GetListaTarjetas()
        {
            return this.Tarjetas;
        }

        public bool YaExisteClave(ControladoraClave aBuscar)
        {
            return (this.Claves.Contains(aBuscar));
        }

        public bool YaExisteTarjeta(ControladoraTarjeta aBuscar)
        {
            return (this.Tarjetas.Contains(aBuscar));
            
        }

        public void BorrarTarjeta(ControladoraTarjeta aBorrar)
        {

            if (this.EsListaTarjetasVacia() || !this.YaExisteTarjeta(aBorrar))
            {
                throw new ObjetoInexistenteException();
            }
            this.Tarjetas.Remove(aBorrar);
        }

        public void ModificarTarjeta(ControladoraTarjeta tarjetaVieja, ControladoraTarjeta tarjetaNueva)
        {
            bool igualNumero = tarjetaVieja.Equals(tarjetaNueva);

            if (!this.YaExisteTarjeta(tarjetaVieja)) throw new ObjetoInexistenteException();
            if (!igualNumero && this.YaExisteTarjeta(tarjetaNueva)) throw new ObjetoYaExistenteException();

            ControladoraTarjeta aModificar = this.GetTarjeta(tarjetaVieja);
            aModificar.Nombre = tarjetaNueva.Nombre;
            aModificar.Numero = tarjetaNueva.Numero;
            aModificar.Tipo = tarjetaNueva.Tipo;
            aModificar.Codigo = tarjetaNueva.Codigo;
            aModificar.Nota = tarjetaNueva.Nota;
            aModificar.Vencimiento = tarjetaNueva.Vencimiento;
        }

        public void ModificarClave(ControladoraClave claveVieja, ControladoraClave claveNueva)
        {
            bool igualSitioyUsuario = claveVieja.Equals(claveNueva);

            if (!this.YaExisteClave(claveVieja)) throw new ObjetoInexistenteException();
            if (!igualSitioyUsuario && this.YaExisteClave(claveNueva)) throw new ObjetoYaExistenteException();

            ControladoraClave aModificar = this.GetClave(claveVieja);
            aModificar.verificarUsuarioClave = claveNueva.verificarUsuarioClave;
            aModificar.VerificarSitio = claveNueva.VerificarSitio;
            aModificar.VerificarNota = claveNueva.VerificarNota;
            if (aModificar.Codigo != claveNueva.Codigo) {
                aModificar.Codigo = claveNueva.Codigo;
            }
        }

        public List<ControladoraClave> GetListaClavesColor(string color)
        {
            List<ControladoraClave> todasLasClaves = this.GetListaClaves();
            NivelSeguridad nivelSeguridad = new NivelSeguridad();
            return todasLasClaves.FindAll(buscadora => nivelSeguridad.GetNivelSeguridad(buscadora.Codigo) == color);
        }
    }
}