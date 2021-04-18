namespace Obligatorio
{
    public class Contra
    {
        private string usuario;
        public string UsuarioContra
        {
            get { return usuario; }
            set {
                if (value.Length < 5 || value.Length > 25)
                {
                    throw new LargoIncorrectoException();
                }
                else
                {
                    this.usuario = value;
                }
            }
        }
    }
}