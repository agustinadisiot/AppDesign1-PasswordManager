using System;

namespace Obligatorio
{
    public class Tarjeta
    {
        private string _nombre;
        private string _tipo;
        private string _numero;
        private string _codigo;
        private string _nota;
        private const int largoNombreYTipoMinimo = 3;
        private const int largoNombreYTipoMaximo = 25;
        private const int largoNumeroMinimoYMaximo = 16;
        private const int largoCodigoMinimo = 3;
        private const int largoCodigoMaximo = 4;
        private const int largoNotaMinimo = 0;
        private const int largoNotaMaximo = 250;

        public string Nombre 
        {
            get { return _nombre; }
            set { this._nombre = VerificadoraString.VerificarLargoXaY(value, largoNombreYTipoMinimo, largoNombreYTipoMaximo); } 
        }

        public string Tipo
        {
            get { return _tipo; }
            set { this._tipo = VerificadoraString.VerificarLargoXaY(value, largoNombreYTipoMinimo, largoNombreYTipoMaximo); }
        }

        public string Numero 
        {
            get { return this._numero; }
            set { this._numero = VerificarStringDeNumerosYSuLargoDeXaY(value, largoNumeroMinimoYMaximo, largoNumeroMinimoYMaximo); }
        }

        public string Codigo
        {
            get { return this._codigo; }
            set { this._codigo = VerificarStringDeNumerosYSuLargoDeXaY(value, largoCodigoMinimo, largoCodigoMaximo); }
        }

        public DateTime Vencimiento { get; set; }

        public string Nota 
        {
            get { return this._nota; }
            set { this._nota = VerificadoraString.VerificarLargoXaY(value, largoNotaMinimo, largoNotaMaximo); }
        }

        public static string VerificarStringDeNumerosYSuLargoDeXaY(string dato, int x, int y)
        {
            if (dato.Length < x || dato.Length > y) throw new LargoIncorrectoException();
            foreach (char c in dato)
            {
                if (!VerificadoraString.EsNumero(c)) throw new CaracterInesperadoException();
            }
            return dato;
        }

        public override bool Equals(object obj)
        {
            if (obj == null) throw new ObjetoIncompletoException();
            if (obj.GetType() != this.GetType()) throw new ObjetoIncorrectoException();
            Tarjeta aIgualar = (Tarjeta)obj;
            return aIgualar.Numero == this.Numero;
        }
    }
}