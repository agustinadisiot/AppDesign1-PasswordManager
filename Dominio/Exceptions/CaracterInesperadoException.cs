using System;
namespace Dominio

{
    [Serializable]
    public class CaracterInesperadoException : Exception
    {
        private string message;

        public override string Message
        {
            get { return message; }
        }

        public CaracterInesperadoException()
        {
            this.message = "La variable incluye uno o mas caracteres incorrectos.";
        }
    }
}