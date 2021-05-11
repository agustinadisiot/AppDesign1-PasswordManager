﻿using System;
using System.Collections.Generic;
using System.Linq;

namespace Dominio
{
    public class Categoria
    {
        private List<Clave> _claves;
        private List<Tarjeta> _tarjetas;
        private string _nombre;
        private const int _largoNombreMinimo = 3;
        private const int _largoNombreMaximo = 15;

        public Categoria()
        {
            _claves = new List<Clave>();
            _tarjetas = new List<Tarjeta>();
        }

        public string Nombre
        {
            get { return _nombre; }
            set { this._nombre = VerificadoraString.VerificarLargoEntreMinimoYMaximo(value, _largoNombreMinimo, _largoNombreMaximo); }
        }


        public bool EsListaClavesVacia()
        {
            bool noHayClaves = (this._claves.Count == 0);
            return noHayClaves;
        }

        public void AgregarClave(Clave claveIngresada)
        {
            bool noTieneSitio = (claveIngresada.Sitio == null),
                 noTieneClave = (claveIngresada.Codigo == null),
                 noTieneUsuario = (claveIngresada.UsuarioClave == null);


            if (noTieneSitio || noTieneClave || noTieneUsuario ) throw new ObjetoIncompletoException();
            if (this.YaExisteClave(claveIngresada)) throw new ObjetoYaExistenteException();
            this._claves.Add(claveIngresada);
        }

        public void BorrarClave(Clave claveABorrar)
        {
            if (this.EsListaClavesVacia()) {
                throw new ObjetoInexistenteException();
            }
            if (!this.YaExisteClave(claveABorrar)) {
                throw new ObjetoInexistenteException();
            }
            this._claves.Remove(claveABorrar);
        }

        public Clave GetClave(Clave aBuscar)
        {
            if (this.EsListaClavesVacia()) {
                throw new ObjetoInexistenteException();
            }

            Predicate<Clave> buscadorClave = (Clave clave) => 
            {
                return clave.Equals(aBuscar);
            };

            Clave retorno = this._claves.Find(buscadorClave);
            return retorno != null ? retorno : throw new ObjetoInexistenteException();
        }

        public List<Clave> GetListaClaves()
        {
            return this._claves;
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

        public bool YaExisteClave(Clave aBuscar)
        {
            return (this._claves.Contains(aBuscar));
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
            bool igualNumero = tarjetaVieja.Equals(tarjetaNueva);

            if (!this.YaExisteTarjeta(tarjetaVieja)) throw new ObjetoInexistenteException();
            if (!igualNumero && this.YaExisteTarjeta(tarjetaNueva)) throw new ObjetoYaExistenteException();

            Tarjeta aModificar = this.GetTarjeta(tarjetaVieja);
            aModificar.Nombre = tarjetaNueva.Nombre;
            aModificar.Numero = tarjetaNueva.Numero;
            aModificar.Tipo = tarjetaNueva.Tipo;
            aModificar.Codigo = tarjetaNueva.Codigo;
            aModificar.Nota = tarjetaNueva.Nota;
            aModificar.Vencimiento = tarjetaNueva.Vencimiento;
        }

        public void ModificarClave(Clave claveVieja, Clave claveNueva)
        {
            bool igualSitioyUsuario = claveVieja.Equals(claveNueva);

            if (!this.YaExisteClave(claveVieja)) throw new ObjetoInexistenteException();
            if (!igualSitioyUsuario && this.YaExisteClave(claveNueva)) throw new ObjetoYaExistenteException();

            Clave aModificar = this.GetClave(claveVieja);
            aModificar.UsuarioClave = claveNueva.UsuarioClave;
            aModificar.Sitio = claveNueva.Sitio;
            aModificar.Nota = claveNueva.Nota;
            if (aModificar.Codigo != claveNueva.Codigo) {
                aModificar.Codigo = claveNueva.Codigo;
            }
        }

        public List<Clave> GetListaClavesColor(string color)
        {
            List<Clave> todasLasClaves = this.GetListaClaves();
            return todasLasClaves.FindAll(buscadora => buscadora.GetNivelSeguridad() == color);
        }
    }
}