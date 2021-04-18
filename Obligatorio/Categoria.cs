namespace Obligatorio
{
    public class Categoria
    {
        private string nombre;

        public string Nombre
        {
            get { return nombre; }
            set
            {
                if (value.Length < 3 || value.Length > 15)
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