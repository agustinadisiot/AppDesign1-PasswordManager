﻿using System;
namespace Dominio
{
    public class ObjetoIncompletoException : Exception
    {

        private string message;

        public override string Message
        {
            get { return message; }
        }

        public ObjetoIncompletoException()
        {
            this.message = "Al objeto ingresado le falta uno o mas atributos.";
        }
    }
}