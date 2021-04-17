﻿using System;
using System.Runtime.Serialization;
namespace Obligatorio

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