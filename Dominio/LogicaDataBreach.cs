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
            char[] separadores = new char[] { '\t' };
            string[] clavesYTarjetas = aSeparar.Split(separadores);
            List<string> dataBreach = new List<string>(clavesYTarjetas);
            return dataBreach;
        }
    }
}
