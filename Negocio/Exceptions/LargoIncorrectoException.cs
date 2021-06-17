using System;
namespace Negocio

{
    [Serializable]
    public class LargoIncorrectoException : Exception
    {
        private string message;

        public override string Message {
            get { return message; }
        }

        public LargoIncorrectoException()
        {
            this.message = "El largo ingresado no cumple las restricciones";
        }
    }
}