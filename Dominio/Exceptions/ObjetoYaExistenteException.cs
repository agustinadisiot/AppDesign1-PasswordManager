using System;
using System.Runtime.Serialization;
namespace Dominio
{
    public class ObjetoYaExistenteException : Exception
    {

        private string message;

        public override string Message
        {
            get { return message; }
        }

        public ObjetoYaExistenteException()
        {
            this.message = "El objeto que se intento agregar ya existe en la lista.";
        }
    }
}