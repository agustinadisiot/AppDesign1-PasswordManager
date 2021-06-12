using Negocio;
using Repositorio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace LogicaDeNegocio
{
    public class ControladoraTarjeta : IControladora<Tarjeta>
    {
        private string _nombre;
        private string _tipo;
        private string _numero;
        private string _codigo;
        private string _nota;
        private const int _largoNombreYTipoMinimo = 3;
        private const int _largoNombreYTipoMaximo = 25;
        private const int _largoNumeroMinimoYMaximo = 16;
        private const int _largoCodigoMinimo = 3;
        private const int _largoCodigoMaximo = 4;
        private const int _largoNotaMinimo = 0;
        private const int _largoNotaMaximo = 250;

        public void Modificar(Tarjeta vieja, Tarjeta nueva)
        {
            this.Verificar(vieja);
            this.Verificar(nueva);

            nueva.Id = vieja.Id;
            DataAccessTarjeta acceso = new DataAccessTarjeta();
            acceso.Modificar(nueva);
        }

        public void Verificar(Tarjeta aVerificar)
        {
            this.VerificarNombre(aVerificar);
            this.VerificarTipo(aVerificar);
            this.VerificarNumero(aVerificar);
            this.VerificarCodigo(aVerificar);
            this.VerificarNota(aVerificar);
        }

        public void VerificarNombre(Tarjeta aVerificar)
        {
            VerificadoraString.VerificarLargoEntreMinimoYMaximo(aVerificar.Nombre, _largoNombreYTipoMinimo, _largoNombreYTipoMaximo);
        }

        public void VerificarTipo(Tarjeta aVerificar)
        {
            VerificadoraString.VerificarLargoEntreMinimoYMaximo(aVerificar.Tipo, _largoNombreYTipoMinimo, _largoNombreYTipoMaximo);
        }

        public void VerificarNumero(Tarjeta aVerificar)
        {
            VerificadoraString.VerificarLargoEntreMinimoYMaximo(aVerificar.Numero, _largoNumeroMinimoYMaximo, _largoNumeroMinimoYMaximo);
            foreach (char caracter in aVerificar.Numero)
            {
                if (!VerificadoraString.EsNumero(caracter)) throw new CaracterInesperadoException();
            }
        }

        public void VerificarCodigo(Tarjeta aVerificar)
        {
            VerificadoraString.VerificarLargoEntreMinimoYMaximo(aVerificar.Codigo, _largoCodigoMinimo, _largoCodigoMaximo);
            foreach (char caracter in aVerificar.Codigo)
            {
                if (!VerificadoraString.EsNumero(caracter)) throw new CaracterInesperadoException();
            }
        }

        public void VerificarNota(Tarjeta aVerificar)
        {
            VerificadoraString.VerificarLargoEntreMinimoYMaximo(aVerificar.Nota, _largoNotaMinimo, _largoNotaMaximo);
        }


        public bool FueFiltrado(Tarjeta aVerificar, List<Filtrada> filtradas)
        {
            const int largoTarjetaSinEspacios = 16;
            const string regexEspacio = @"\s+";
            const string vacio = "";

            List<string> potencialesTarjetas = new List<string>();

            foreach (Filtrada potencial in filtradas)
            {
                string sinEspacio = Regex.Replace(potencial.Texto, regexEspacio, vacio);
                bool esNumero = sinEspacio.All(caracter => VerificadoraString.EsNumero(caracter));
                bool tieneLargoTarjeta = sinEspacio.Length == largoTarjetaSinEspacios;

                if (esNumero && tieneLargoTarjeta)
                {
                    potencialesTarjetas.Add(sinEspacio);
                }
            }

            return potencialesTarjetas.Contains(aVerificar.Numero);
        }

        
    }
}