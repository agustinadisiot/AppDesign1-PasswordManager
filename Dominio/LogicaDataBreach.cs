using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio
{
    public class LogicaDataBreach
    {
        public List<string> LeerArchivo(string direccion)
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

        public List<string> SepararPorLineas(string aSeparar)
        {
            string[] separadores = new string[] { "\t", "\r\n", Environment.NewLine };
            string[] clavesYTarjetas = aSeparar.Split(separadores, StringSplitOptions.None);
            List<string> dataBreach = new List<string>(clavesYTarjetas);
            return dataBreach;
        }

        public List<Clave> FiltrarClaves(List<String> dataBreach, List<Clave> controlar)
        {
            return controlar.FindAll(buscadora => buscadora.FueFiltrado(dataBreach));
        }

        public List<Tarjeta> FiltrarTarjetas(List<String> dataBreach, List<Tarjeta> controlar)
        {
            return controlar.FindAll(buscadora => buscadora.FueFiltrado(dataBreach));
        }
    }
}
