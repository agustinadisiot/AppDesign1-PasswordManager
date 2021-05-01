using System;
using System.Collections.Generic;
using System.Linq;

namespace Obligatorio
{
    public class Categoria
    {
        private List<Contra> contras;
        private List<Tarjeta> tarjetas;
        private string _nombre;
        private bool _noModificoContra;
        private const int largoNombreMinimo = 3;
        private const int largoNombreMaximo = 15;

        public Categoria()
        {
            contras = new List<Contra>();
            tarjetas = new List<Tarjeta>();
            _noModificoContra = true;
        }

        public string Nombre
        {
            get { return _nombre; }
            set { this._nombre = VerificadoraString.VerificarLargoXaY(value, largoNombreMinimo, largoNombreMaximo); }
        }


        public bool EsListaContrasVacia()
        {
            bool noQuedanContras = (this.contras.Count == 0);
            return noQuedanContras;
        }

        public void AgregarContra(Contra contraIngresada)
        {
            bool noTieneSitio = (contraIngresada.Sitio == null),
                 noTieneClave = (contraIngresada.Clave == null),
                 noTieneUsuario = (contraIngresada.UsuarioContra == null);


            if (noTieneSitio || noTieneClave || noTieneUsuario ) throw new ObjetoIncompletoException();
            if (this.YaExisteContra(contraIngresada)) throw new ObjetoYaExistenteException();
            this.contras.Add(contraIngresada);
        }

        public void BorrarContra(Contra contraABorrar)
        {
            if (this.EsListaContrasVacia()) {
                throw new ObjetoInexistenteException();
            }
            if (!this.YaExisteContra(contraABorrar)) {
                throw new ObjetoInexistenteException();
            }
            this.contras.Remove(contraABorrar);
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

            Contra retorno = this.contras.Find(buscadorContra);
            return retorno != null ? retorno : throw new ObjetoInexistenteException();
        }

        public List<Contra> GetListaContras()
        {
            return this.contras;
        }

        public override bool Equals(object obj)
        {
            if (obj == null) throw new ObjetoIncompletoException();
            if (obj.GetType() != this.GetType()) throw new ObjetoIncorrectoException();
            Categoria aIgualar = (Categoria)obj;
            return aIgualar.Nombre.ToUpper() == this.Nombre.ToUpper();
        }

        public bool EsListaTarjetasVacia()
        {
            return this.tarjetas.Count == 0;
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
           
            this.tarjetas.Add(tarjetaIngresada);
        }

        public Tarjeta GetTarjeta(Tarjeta aBuscar)
        {
            if (this.EsListaTarjetasVacia()) throw new ObjetoInexistenteException();
            Predicate<Tarjeta> buscadorTarjeta = (Tarjeta tarjeta) =>
            {
                return tarjeta.Equals(aBuscar);
            };

            Tarjeta retorno = this.tarjetas.Find(buscadorTarjeta);
            return retorno != null ? retorno : throw new ObjetoInexistenteException();
        }

        public List<Tarjeta> GetListaTarjetas()
        {
            return this.tarjetas;
        }

        public bool YaExisteContra(Contra aBuscar)
        {
            if (!_noModificoContra) return false;
            return this.contras.Any(buscadora => buscadora.Equals(aBuscar));
        }

        public bool YaExisteTarjeta(Tarjeta aBuscar)
        {
            return (this.tarjetas.Contains(aBuscar));
            
        }

        public void BorrarTarjeta(Tarjeta aBorrar)
        {

            if (this.EsListaTarjetasVacia() || !this.YaExisteTarjeta(aBorrar))
            {
                throw new ObjetoInexistenteException();
            }
            this.tarjetas.Remove(aBorrar);
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
            if(this.YaExisteContra(contraNueva)) throw new ObjetoYaExistenteException();
            _noModificoContra = false;
            Contra aModificar = this.GetContra(contraVieja);
            aModificar.UsuarioContra = contraNueva.UsuarioContra;
            aModificar.Clave = contraNueva.Clave;
            aModificar.Sitio = contraNueva.Sitio;
            aModificar.Nota = contraNueva.Nota;
        }
    }
}