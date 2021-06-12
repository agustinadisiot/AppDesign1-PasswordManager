using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaDeNegocio
{
    public class LogicaDataBreach
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

        public List<ControladoraClave> FiltrarClaves(List<Filtrada> dataBreach, List<ControladoraClave> controlar)
        {
            return controlar.FindAll(buscadora => buscadora.FueFiltrado(dataBreach));
        }

        public List<Tarjeta> FiltrarTarjetas(List<Filtrada> dataBreach, List<Tarjeta> controlar)
        {
            return controlar.FindAll(buscadora => buscadora.FueFiltrado(dataBreach));
        }
    }
}
