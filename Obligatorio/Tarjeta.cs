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


        public string Nombre 
        {
            get { return _nombre; }
            set { this._nombre = VerificadoraString.VerificarLargoXaY(value, 3, 25); } 
        }

        public string Tipo
        {
            get { return _tipo; }
            set { this._tipo = VerificadoraString.VerificarLargoXaY(value, 3, 25); }
        }

        public string Numero 
        {
            get { return this._numero; }
            set { this._numero = VerificarStringDeNumerosYSuLargoDeXaY(value, 16, 16); }
        }

        public string Codigo
        {
            get { return this._codigo; }
            set { this._codigo = VerificarStringDeNumerosYSuLargoDeXaY(value, 3, 4); }
        }

        public DateTime Vencimiento { get; set; }

        public string Nota 
        {
            get { return this._nota; }
            set { this._nota = VerificadoraString.VerificarLargoXaY(value, 0, 250); }
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