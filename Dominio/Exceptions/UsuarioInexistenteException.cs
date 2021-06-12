using System;
using System.Runtime.Serialization;

namespace LogicaDeNegocio
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