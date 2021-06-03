using System;
namespace Dominio
{
    public class ArchivoNoExistenteException : Exception
    {

        private string message;

        public override string Message
        {
            get { return message; }
        }

        public ArchivoNoExistenteException()
        {
            this.message = "No se pudo leer el archivo seleccionado o no existe el archivo.";
        }
    }
}