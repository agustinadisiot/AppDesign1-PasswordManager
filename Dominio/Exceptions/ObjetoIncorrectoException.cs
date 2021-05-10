using System;
using System.Runtime.Serialization;
namespace Dominio
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