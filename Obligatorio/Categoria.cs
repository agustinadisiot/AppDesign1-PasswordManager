using System;
using System.Collections.Generic;
using System.Linq;

namespace Obligatorio
{
    public class Categoria
    {
        private List<Contra> _contras;
        private List<Tarjeta> _tarjetas;
        private string _nombre;
        private const int _largoNombreMinimo = 3;
        private const int _largoNombreMaximo = 15;

        public Categoria()
        {
            _contras = new List<Contra>();
            _tarjetas = new List<Tarjeta>();
        }

        public string Nombre
        {
            get { return _nombre; }
            set { this._nombre = VerificadoraString.VerificarLargoEntreMinimoYMaximo(value, _largoNombreMinimo, _largoNombreMaximo); }
        }


        public bool EsListaContrasVacia()
        {
            bool noHayContras = (this._contras.Count == 0);
            return noHayContras;
        }

        public void AgregarContra(Contra contraIngresada)
        {
            bool noTieneSitio = (contraIngresada.Sitio == null),
                 noTieneClave = (contraIngresada.Clave == null),
                 noTieneUsuario = (contraIngresada.UsuarioContra == null);


            if (noTieneSitio || noTieneClave || noTieneUsuario ) throw new ObjetoIncompletoException();
            if (this.YaExisteContra(contraIngresada)) throw new ObjetoYaExistenteException();
            this._contras.Add(contraIngresada);
        }

        public void BorrarContra(Contra contraABorrar)
        {
            if (this.EsListaContrasVacia()) {
                throw new ObjetoInexistenteException();
            }
            if (!this.YaExisteContra(contraABorrar)) {
                throw new ObjetoInexistenteException();
            }
            this._contras.Remove(contraABorrar);
        }

        public Contra GetContra(Contra aBuscar)
        {
            if (this.EsListaContrasVacia()) {
                throw new ObjetoInexistenteException();
            }

            Predicate<Contra> buscadorContra = (Contra contra) => 
            {
                return contra.Equals(aBuscar);
            };

            Contra retorno = this._contras.Find(buscadorContra);
            return retorno != null ? retorno : throw new ObjetoInexistenteException();
        }

        public List<Contra> GetListaContras()
        {
            return this._contras;
        }

        public override bool Equals(object objeto)
        {
            if (objeto == null) throw new ObjetoIncompletoException();
            if (objeto.GetType() != this.GetType()) throw new ObjetoIncorrectoException();
            Categoria aIgualar = (Categoria)objeto;
            return aIgualar.Nombre.ToUpper() == this.Nombre.ToUpper();
        }

        public bool EsListaTarjetasVacia()
        {
            bool noHayTarjetas = this._tarjetas.Count == 0;
            return noHayTarjetas;
        }

        public void AgregarTarjeta(Tarjeta tarjetaIngresada)
        {
            bool noTieneNombre = (tarjetaIngresada.Nombre == null),
                noTieneSitio = (tarjetaIngresada.Tipo == null),
                noTieneNumero = (tarjetaIngresada.Numero == null),
                noTieneCodigo = (tarjetaIngresada.Codigo == null),
                noTieneVencimiento = (tarjetaIngresada.Vencimiento.Equals(DateTime.MinValue));

            if (noTieneNombre || noTieneSitio || noTieneNumero || noTieneCodigo || noTieneVencimiento) throw new ObjetoIncompletoException();

            if (this.YaExisteTarjeta(tarjetaIngresada)) throw new ObjetoYaExistenteException();
           
            this._tarjetas.Add(tarjetaIngresada);
        }

        public Tarjeta GetTarjeta(Tarjeta aBuscar)
        {
            if (this.EsListaTarjetasVacia()) throw new ObjetoInexistenteException();
            Predicate<Tarjeta> buscadorTarjeta = (Tarjeta tarjeta) =>
            {
                return tarjeta.Equals(aBuscar);
            };

            Tarjeta retorno = this._tarjetas.Find(buscadorTarjeta);
            return retorno != null ? retorno : throw new ObjetoInexistenteException();
        }

        public List<Tarjeta> GetListaTarjetas()
        {
            return this._tarjetas;
        }

        public bool YaExisteContra(Contra aBuscar)
        {
            return (this._contras.Contains(aBuscar));
        }

        public bool YaExisteTarjeta(Tarjeta aBuscar)
        {
            return (this._tarjetas.Contains(aBuscar));
            
        }

        public void BorrarTarjeta(Tarjeta aBorrar)
        {

            if (this.EsListaTarjetasVacia() || !this.YaExisteTarjeta(aBorrar))
            {
                throw new ObjetoInexistenteException();
            }
            this._tarjetas.Remove(aBorrar);
        }

        public void ModificarTarjeta(Tarjeta tarjetaVieja, Tarjeta tarjetaNueva)
        {
            if (this.YaExisteTarjeta(tarjetaNueva)) throw new ObjetoYaExistenteException();
            Tarjeta aModificar = this.GetTarjeta(tarjetaVieja);
            aModificar.Nombre = tarjetaNueva.Nombre;
            aModificar.Numero = tarjetaNueva.Numero;
            aModificar.Tipo = tarjetaNueva.Tipo;
            aModificar.Nota = tarjetaNueva.Nota;
            aModificar.Vencimiento = tarjetaNueva.Vencimiento;
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
    }
}