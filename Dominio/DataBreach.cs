﻿using System;
using System.Collections.Generic;

namespace LogicaDeNegocio
{
    public class DataBreach
    {
        public DataBreach() {
            this.Tarjetas = new List<ControladoraTarjeta>();
            this.Claves = new List<ControladoraClave>();
            this.Fecha = DateTime.Now;
            this.Filtradas = new List<Filtrada>();
        }

        public int Id { get; set; }

        public List<ControladoraTarjeta> Tarjetas { get; set; }

        public List<ControladoraClave> Claves { get; set; }
        public DateTime Fecha { get; set; }
        public List<Filtrada> Filtradas { get; set; }
    }
}