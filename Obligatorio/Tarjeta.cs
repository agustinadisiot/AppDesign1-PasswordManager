﻿using System;

namespace Obligatorio
{
    public class Tarjeta
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

        public string Nombre 
        {
            get { return _nombre; }
            set { this._nombre = VerificadoraString.VerificarLargoEntreMinimoYMaximo(value, _largoNombreYTipoMinimo, _largoNombreYTipoMaximo); } 
        }

        public string Tipo
        {
            get { return _tipo; }
            set { this._tipo = VerificadoraString.VerificarLargoEntreMinimoYMaximo(value, _largoNombreYTipoMinimo, _largoNombreYTipoMaximo); }
        }

        public string Numero 
        {
            get { return this._numero; }
            set { this._numero = VerificarStringDeNumerosYSuLargoEntreMinimoYMaximo(value, _largoNumeroMinimoYMaximo, _largoNumeroMinimoYMaximo); }
        }

        public string Codigo
        {
            get { return this._codigo; }
            set { this._codigo = VerificarStringDeNumerosYSuLargoEntreMinimoYMaximo(value, _largoCodigoMinimo, _largoCodigoMaximo); }
        }

        public DateTime Vencimiento { get; set; }

        public string Nota 
        {
            get { return this._nota; }
            set { this._nota = VerificadoraString.VerificarLargoEntreMinimoYMaximo(value, _largoNotaMinimo, _largoNotaMaximo); }
        }

        public static string VerificarStringDeNumerosYSuLargoEntreMinimoYMaximo(string ingreso, int minimo, int maximo)
        {
            if (ingreso.Length < minimo || ingreso.Length > maximo) throw new LargoIncorrectoException();
            foreach (char caracter in ingreso)
            {
                if (!VerificadoraString.EsNumero(caracter)) throw new CaracterInesperadoException();
            }
            return ingreso;
        }

        public override bool Equals(object objeto)
        {
            if (objeto == null) throw new ObjetoIncompletoException();
            if (objeto.GetType() != this.GetType()) throw new ObjetoIncorrectoException();
            Tarjeta aIgualar = (Tarjeta)objeto;
            return aIgualar.Numero == this.Numero;
        }
    }
}