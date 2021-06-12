using System;
using System.Runtime.Serialization;

namespace Negocio
{
    [Serializable]
    public class UsuarioInexistenteException : Exception
    {

        private string message;

        public override string Message
        {
            get { return message; }
        }

        public UsuarioInexistenteException()
        {
            this.message = "El usuario buscado no existe.";
        }
    }
}