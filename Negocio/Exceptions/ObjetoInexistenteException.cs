using System;
namespace Negocio
{
    public class ObjetoInexistenteException : Exception
    {

        private string message;

        public override string Message
        {
            get { return message; }
        }

        public ObjetoInexistenteException()
        {
            this.message = "El objeto buscado no existe o no esta contenido en la lista.";
        }
    }
}