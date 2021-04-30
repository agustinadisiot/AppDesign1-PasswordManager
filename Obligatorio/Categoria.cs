using System;
using System.Collections.Generic;
using System.Linq;

namespace Obligatorio
{
    public class Categoria
    {
        private string nombre;
        private List<Contra> contras;
        private List<Tarjeta> tarjetas;

        public Categoria()
        {
            contras = new List<Contra>();
            tarjetas = new List<Tarjeta>();
        }

        public string Nombre
        {
            get { return nombre; }
            set { this.nombre = VerificadoraString.verificarLargoXaY(value, 3, 15); }
        }


        public bool esListaContrasVacia()
        {
            bool noQuedanContras = (this.contras.Count == 0);
            return noQuedanContras;
        }

        public void agregarContra(Contra contraIngresada)
        {
            bool noTieneSitio = (contraIngresada.Sitio == null),
                 noTieneClave = (contraIngresada.Clave == null),
                 noTieneUsuario = (contraIngresada.UsuarioContra == null);


            if (noTieneSitio || noTieneClave || noTieneUsuario ) throw new ObjetoIncompletoException();
            if (this.yaExisteContra(contraIngresada)) throw new ObjetoYaExistenteException();
            this.contras.Add(contraIngresada);
        }

        public void borrarContra(string paginaContra, string usuarioContra)
        {
            if (this.esListaContrasVacia()) {
                throw new ObjetoInexistenteException();
            }
            Contra contraABorrar = new Contra()
            {
                Sitio = paginaContra,
                UsuarioContra = usuarioContra
            };

            if (!this.yaExisteContra(contraABorrar)) {
                throw new ObjetoInexistenteException();
            }
            this.contras.Remove(contraABorrar);
        }
        public Contra getContra(string sitioABuscar, string usuarioABuscar)
        {
            if (this.esListaContrasVacia()) {
                throw new ObjetoInexistenteException();
            }

            //Predicate se utiliza en conjunto con una clase, se le da una condicion que retorne true para ser buscado en una List con un List.Find
            Predicate<Contra> buscadorContra = (Contra contra) => 
            { return contra.Sitio == sitioABuscar &&
              contra.UsuarioContra == usuarioABuscar;
            };

            Contra retorno = this.contras.Find(buscadorContra);
            return retorno != null ? retorno : throw new ObjetoInexistenteException();
        }

        public List<Contra> getListaContras()
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

        public bool esListaTarjetasVacia()
        {
            return this.tarjetas.Count == 0;
        }

        public void agregarTarjeta(Tarjeta tarjetaIngresada)
        {
            bool noTieneNombre = (tarjetaIngresada.Nombre == null),
                noTieneSitio = (tarjetaIngresada.Tipo == null),
                noTieneNumero = (tarjetaIngresada.Numero == null),
                noTieneCodigo = (tarjetaIngresada.Codigo == null),
                noTieneVencimiento = (tarjetaIngresada.Vencimiento.Equals(DateTime.MinValue));

            if (noTieneNombre || noTieneSitio || noTieneNumero || noTieneCodigo || noTieneVencimiento) throw new ObjetoIncompletoException();

            if (this.yaExisteTarjeta(tarjetaIngresada)) throw new ObjetoYaExistenteException();
           
            this.tarjetas.Add(tarjetaIngresada);
        }

        public Tarjeta getTarjeta(string numeroABuscar)
        {
            if (this.esListaTarjetasVacia()) throw new ObjetoInexistenteException();
            Predicate<Tarjeta> buscadorTarjeta = (Tarjeta tarjeta) =>
            {
                return tarjeta.Numero == numeroABuscar;
            };

            Tarjeta retorno = this.tarjetas.Find(buscadorTarjeta);
            return retorno != null ? retorno : throw new ObjetoInexistenteException();
        }

        public List<Tarjeta> getListaTarjetas()
        {
            return this.tarjetas;
        }

        public bool yaExisteContra(Contra aBuscar)
        {
            return this.contras.Any(buscadora => buscadora.Equals(aBuscar));
        }

        public bool yaExisteTarjeta(Tarjeta aBuscar)
        {
            return (this.tarjetas.Contains(aBuscar));
            
        }

        public void borrarTarjeta(string tarjetaABorrar)
        {
            Tarjeta aBorrar = new Tarjeta()
            {
                Numero = tarjetaABorrar
            };

            if (this.esListaTarjetasVacia() || !this.yaExisteTarjeta(aBorrar))
            {
                throw new ObjetoInexistenteException();
            }
            this.tarjetas.Remove(aBorrar);
        }

       
    }
}