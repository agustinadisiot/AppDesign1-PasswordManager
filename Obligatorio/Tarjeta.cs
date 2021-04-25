using System;

namespace Obligatorio
{
    public class Tarjeta
    {
        private string nombre;
        private string tipo;
        private string numero;
        private string codigo;
        private string nota;

        public string Nombre 
        {
            get { return nombre; }
            set { this.nombre = VerificadoraString.verificarLargoXaY(value, 3, 25); } 
        }

        public string Tipo
        {
            get { return tipo; }
            set { this.tipo = VerificadoraString.verificarLargoXaY(value, 3, 25); }
        }

        public string Numero 
        {
            get { return this.numero; }
            set { this.numero = verificarStringDeNumerosYSuLargoDeXaY(value, 16, 16); }
        }

        public string Codigo
        {
            get { return this.codigo; }
            set { this.codigo = verificarStringDeNumerosYSuLargoDeXaY(value, 3, 4); }
        }

        public DateTime Vencimiento { get; set; }

        public string Nota 
        {
            get { return this.nota; }
            set { this.nota = VerificadoraString.verificarLargoXaY(value, 0, 250); }
        }

        public static string verificarStringDeNumerosYSuLargoDeXaY(string dato, int x, int y)
        {
            if (dato.Length < x || dato.Length > y) throw new LargoIncorrectoException();
            foreach (char c in dato)
            {
                if (!VerificadoraString.esNumero(c)) throw new CaracterInesperadoException();
            }
            return dato;
        }

        public override bool Equals(object obj)
        {
            if (obj == null) throw new ObjetoIncompletoException();
            if (obj.GetType() != this.GetType()) throw new ObjetoIncorrectoException();
            Tarjeta aIgualar = (Tarjeta)obj;
            return aIgualar.Numero == this.numero;
        }
    }
}