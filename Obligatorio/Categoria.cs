using System;
using System.Collections.Generic;
using System.Linq;

namespace Obligatorio
{
    public class Categoria
    {
        private string nombre;
        private bool noAgregoContra;
        private List<Contra> contras;
        private bool noAgregoTarjeta;
        private List<Tarjeta> tarjetas;

        public Categoria()
        {
            noAgregoContra = true;
            contras = new List<Contra>();
            noAgregoTarjeta = true;
            tarjetas = new List<Tarjeta>();
        }

        public string Nombre
        {
            get { return nombre; }
            set { this.nombre = VerificadoraString.verificarLargoXaY(value, 3, 15); }
        }


        public bool esListaContrasVacia()
        {
            return noAgregoContra;
        }

        public void agregarContra(Contra contraIngresada)
        {
            bool noTieneSitio = (contraIngresada.Sitio == null),
                 noTieneClave = (contraIngresada.Clave == null),
                 noTieneUsuario = (contraIngresada.UsuarioContra == null);


            if (noTieneSitio || noTieneClave || noTieneUsuario ) throw new ObjetoIncompletoException();

            this.noAgregoContra = false;
            this.contras.Add(contraIngresada);
        }

        public Contra getContra(string sitioABuscar, string usuarioABuscar)
        {

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
            return this.noAgregoTarjeta;
        }

        public void agregarTarjeta(Tarjeta tarjetaIngresada)
        {
            bool noTieneNombre = (tarjetaIngresada.Nombre == null),
                noTieneSitio = (tarjetaIngresada.Tipo == null),
                noTieneNumero = (tarjetaIngresada.Numero == null),
                noTieneCodigo = (tarjetaIngresada.Codigo == null);
            if (noTieneNombre || noTieneSitio || noTieneNumero || noTieneCodigo) throw new ObjetoIncompletoException();

            this.noAgregoTarjeta = false;
            this.tarjetas.Add(tarjetaIngresada);
        }

        public Tarjeta getTarjeta(string numeroABuscar)
        {
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
            return this.tarjetas.Any(buscadora => buscadora.Equals(aBuscar));
        }

        public void borrarTarjeta(string nroTarjeta)
        {
            throw new ObjetoInexistenteException();
        }
    }
}