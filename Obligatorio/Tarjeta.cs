namespace Obligatorio
{
    public class Tarjeta
    {
        private string nombre;
        public string Nombre 
        {
            get { return nombre; }
            set { this.nombre = VerificadoraString.verificarLargoXaY(value, 3, 25); } 
        }

        public string Tipo { get; set; }
    }
}