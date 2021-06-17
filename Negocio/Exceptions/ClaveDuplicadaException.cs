using System;

namespace Negocio
{
    public class ClaveDuplicadaException : Exception
    {
        private string message;

        public override string Message
        {
            get { return message; }
        }

        public ClaveDuplicadaException()
        {
            this.message = "Contraseña no Segura: Ya has usado esta contraseña para otro sitio o app.";
        }
    }
}