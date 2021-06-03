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
                StreamReader sr = new StreamReader(direccion);
                string linea = sr.ReadLine();
                string[] clavesYTarjetas = linea.Split('\t');
                List<string> dataBreach = new List<string>();
                int cantidadClavesYTarjetas = clavesYTarjetas.Length;

                for (int i = 0; i < cantidadClavesYTarjetas; i++)
                {
                    dataBreach.Add(clavesYTarjetas[i]);
                }
                sr.Close();
                return dataBreach;
            }
            catch (Exception)
            {
                throw new ArchivoNoExistenteException();
            }
        }
    }
}
