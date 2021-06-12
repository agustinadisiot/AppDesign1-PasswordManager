using System;

namespace LogicaDeNegocio
{
    public class ClaveNoSeguraException : Exception
    {
        private string message;

        public override string Message
        {
            get { return message; }
        }

        public ClaveNoSeguraException()
        {
            this.message = "La contraseña no es segura.";
        }
    }
}