using Negocio;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaDeNegocio
{
    public class ControladoraFiltradas
    {
        public List<Filtrada> LeerArchivo(string direccion)
        {
            try
            {
                StreamReader streamReader = new StreamReader(direccion);
                string linea = streamReader.ReadLine();
                streamReader.Close();
                return this.SepararPorLineas(linea);
            }
            catch (Exception)
            {
                throw new ArchivoNoExistenteException();
            }
        }

        public List<Filtrada> SepararPorLineas(string aSeparar)
        {
            string[] separadores = new string[] { "\t", "\r\n", Environment.NewLine };
            string[] clavesYTarjetas = aSeparar.Split(separadores, StringSplitOptions.None);
            List<string> dataBreachString = new List<string>(clavesYTarjetas);
            List<Filtrada> dataBreach = dataBreachString.Select(s => new Filtrada(s)).ToList();
            return dataBreach;
        }

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
