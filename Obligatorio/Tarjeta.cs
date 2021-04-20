using System;

namespace Obligatorio
{
    public class Tarjeta
    {
        private string nombre;
        private string tipo;
        private string numero;
        private string codigo;

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

        public static string verificarStringDeNumerosYSuLargoDeXaY(string dato, int x, int y)
        {
            if (dato.Length < x || dato.Length > y) throw new LargoIncorrectoException();
            foreach (int c in dato) if (c <= 48 || c >= 57) throw new CaracterInesperadoException();
            return dato;
        }
    }
}