using System;

namespace Negocio
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
            this.message = "Contraseña no Segura: La contraseña es demasiado debil.";
        }
    }
}