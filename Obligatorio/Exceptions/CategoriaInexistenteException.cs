using System;
using System.Runtime.Serialization;
namespace Obligatorio
{
    public class CategoriaInexistenteException : ObjetoInexistenteException
    {

        private string message;

        public override string Message
        {
            get { return message; }
        }

        public CategoriaInexistenteException()
        {
            this.message = "La Categoria buscada no existe o no esta contenida en la lista.";
        }
    }
}