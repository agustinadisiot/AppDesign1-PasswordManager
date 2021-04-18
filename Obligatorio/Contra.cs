namespace Obligatorio
{
    public class Contra
    {
        private string usuario;
        private string clave;
        private string sitio;

        public string UsuarioContra
        {
            get { return usuario; }
            set { this.usuario = verificarLargo5a25(value); }
        }

        public string Clave
        {
            get { return clave; }
            set { this.clave = verificarLargo5a25(value); }
        }

        public string Sitio
        {
            get { return sitio; }
            set {
                if (value.Length < 3 || value.Length > 25)
                {
                    throw new LargoIncorrectoException();
                }
                else
                {
                    this.sitio = value;
                }
            }
        }

        private string verificarLargo5a25(string dato)
        {
            if (dato.Length < 5 || dato.Length > 25)
            {
                throw new LargoIncorrectoException();
            }
            else
            {
                return dato;
            }
        }

    }
}