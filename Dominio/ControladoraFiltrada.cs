using Negocio;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaDeNegocio
{
    public class ControladoraFiltrada
    {
        public List<Clave> FiltrarClaves(List<Filtrada> dataBreach, List<Clave> claves)
        {
            ControladoraClave controladora = new ControladoraClave();
            return claves.FindAll(buscadora => controladora.FueFiltrado(buscadora, dataBreach));
        }

        public List<Tarjeta> FiltrarTarjetas(List<Filtrada> dataBreach, List<Tarjeta> tarjetas)
        {
            ControladoraTarjeta controladora = new ControladoraTarjeta();
            return tarjetas.FindAll(buscadora => controladora.FueFiltrado(buscadora, dataBreach));
        }
    }
}
