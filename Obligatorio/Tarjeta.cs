namespace Obligatorio
{
    public class Tarjeta
    {
        private string nombre;
        public string Nombre 
        {
            get { return nombre; }
            set 
            {
                if (value.Length < 3)
                {
                    throw new LargoIncorrectoException();
                }
                else
                {
                    this.nombre = value;
                }
            } 
        }
    }
}