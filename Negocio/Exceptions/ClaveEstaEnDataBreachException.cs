using System;

namespace Negocio
{
    public class ClaveEstaEnDataBreachException: Exception
    {
        private string message;

        public override string Message
        {
            get { return message; }
        }

        public ClaveEstaEnDataBreachException()
        {
            this.message = "Contraseña no Segura: Esta contraseña se ya a sido filtrada.";
        }
    }
}