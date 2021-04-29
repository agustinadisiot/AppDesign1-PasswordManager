using System;
using System.Collections.Generic;
using System.Linq;

namespace Obligatorio
{
    public class Categoria
    {
        private string nombre;
        private List<Contra> contras;
        private bool noAgregoTarjeta;
        private List<Tarjeta> tarjetas;
        private int cantContras;

        public Categoria()
        {
            contras = new List<Contra>();
            noAgregoTarjeta = true;
            cantContras = 0;
            tarjetas = new List<Tarjeta>();
        }

        public string Nombre
        {
            get { return nombre; }
            set { this.nombre = VerificadoraString.verificarLargoXaY(value, 3, 15); }
        }


        public bool esListaContrasVacia()
        {
            return this.cantContras == 0;
        }

        public void agregarContra(Contra contraIngresada)
        {
            bool noTieneSitio = (contraIngresada.Sitio == null),
                 noTieneClave = (contraIngresada.Clave == null),
                 noTieneUsuario = (contraIngresada.UsuarioContra == null);


            if (noTieneSitio || noTieneClave || noTieneUsuario ) throw new ObjetoIncompletoException();
            if (this.yaExisteContra(contraIngresada)) throw new ObjetoYaExistenteException();
            this.cantContras++;
            this.contras.Add(contraIngresada);
        }

        public void borrarContra(string paginaContra, string usuarioContra)
        {
            if (this.esListaContrasVacia()) {
                throw new ObjetoInexistenteException();
            }
            this.cantContras--;
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
            if (this.esListaContrasVacia())
            {
                return false;
            }

            return this.contras.Any(buscadora => buscadora.Equals(aBuscar));
        }

        public bool yaExisteTarjeta(Tarjeta aBuscar)
        {
            return this.tarjetas.Any(buscadora => buscadora.Equals(aBuscar));
        }

       
    }
}