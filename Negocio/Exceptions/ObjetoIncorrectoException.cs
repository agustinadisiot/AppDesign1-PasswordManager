using System;
namespace Negocio
{
    public class ObjetoIncorrectoException : Exception
    {

        private string message;

        public override string Message
        {
            get { return message; }
        }

        public ObjetoIncorrectoException()
        {
            this.message = "El objeto utilizado no es de la clase o tipo esperado.";
        }
    }
}