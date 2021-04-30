using System;

namespace Obligatorio
{
    public class Tarjeta
    {
        public string Nombre 
        {
            get { return Nombre; }
            set { this.Nombre = VerificadoraString.VerificarLargoXaY(value, 3, 25); } 
        }

        public string Tipo
        {
            get { return Tipo; }
            set { this.Tipo = VerificadoraString.VerificarLargoXaY(value, 3, 25); }
        }

        public string Numero 
        {
            get { return this.Numero; }
            set { this.Numero = VerificarStringDeNumerosYSuLargoDeXaY(value, 16, 16); }
        }

        public string Codigo
        {
            get { return this.Codigo; }
            set { this.Codigo = VerificarStringDeNumerosYSuLargoDeXaY(value, 3, 4); }
        }

        public DateTime Vencimiento { get; set; }

        public string Nota 
        {
            get { return this.Nota; }
            set { this.Nota = VerificadoraString.VerificarLargoXaY(value, 0, 250); }
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