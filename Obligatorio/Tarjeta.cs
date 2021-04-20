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
            set
            {
                if (value.Length != 16)
                {
                    throw new LargoIncorrectoException();
                }
                else
                {
                    foreach (int c in value)
                    {
                        if (c <= 48 || c >= 57) throw new CaracterInesperadoException();
                    }
                }
                this.numero = value;
            }
        }

        public string Codigo
        {
            get { return this.codigo; }
            set
            {
                if (value.Length < 3 || value.Length > 4)
                {
                    throw new LargoIncorrectoException();
                }
                this.codigo = value;
            }
        }
    }
}