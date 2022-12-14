using System;
namespace Negocio
{
    public class ClaveGeneradaVaciaException : Exception
    {

        private string message;

        public override string Message
        {
            get { return message; }
        }

        public ClaveGeneradaVaciaException()
        {
            this.message = "La clave generada debe contener por lo menos un tipo de caracter.";
        }
    }
}