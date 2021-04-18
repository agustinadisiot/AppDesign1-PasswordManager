namespace Obligatorio
{
    public class Contra
    {
        private string usuario;
        public string UsuarioContra
        {
            get { return usuario; }
            set { this.usuario = verificarLargo5a25(value); }
        }

        public string Clave { get; set; }

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