using System;
using System.Collections.Generic;

namespace Negocio
{
    public class DataBreach
    {
        public DataBreach() {
            this.Tarjetas = new List<Tarjeta>();
            this.Claves = new List<Clave>();
            this.Fecha = DateTime.Now;
            this.Filtradas = new List<Filtrada>();
        }

        public int Id { get; set; }

        public List<Tarjeta> Tarjetas { get; set; }

        public List<Clave> Claves { get; set; }
        public DateTime Fecha { get; set; }
        public List<Filtrada> Filtradas { get; set; }
    }
}