using Negocio;
using System;
using System.Collections.Generic;
using System.Linq;

namespace LogicaDeNegocio
{
    public class IngresoDataBreachUI : IMetodoIngresoDataBreach<string>
    {
        public List<Filtrada> DevolverFiltradas(string ingreso)
        {
            string[] separadores = new string[] { Environment.NewLine };
            string[] clavesYTarjetas = ingreso.Split(separadores, StringSplitOptions.None);
            List<string> dataBreachString = new List<string>(clavesYTarjetas);
            List<Filtrada> dataBreach = dataBreachString.Select(s => new Filtrada(s)).ToList();
            return dataBreach;
        }
    }
}
