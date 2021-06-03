using System;
using System.Collections.Generic;

namespace Dominio
{
    public class DataBreach
    {


        public DataBreach() {

        }

        public List<Tarjeta> Tarjetas { get; set; }

        public List<Clave> Claves { get; set; }
        public DateTime Fecha { get; set; }
    }
}