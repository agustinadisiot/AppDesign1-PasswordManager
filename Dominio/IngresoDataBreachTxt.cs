using Negocio;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaDeNegocio
{
    public class IngresoDataBreachTxt : IMetodoIngresoDataBreach<string>
    {

        public List<Filtrada> DevolverFiltradas(string ingreso)
        {
            try
            {
                StreamReader streamReader = new StreamReader(ingreso);
                string linea = streamReader.ReadLine();
                streamReader.Close();

                string[] separadores = new string[] { "\t" };

                string[] clavesYTarjetas = linea.Split(separadores, StringSplitOptions.None);
                List<string> dataBreachString = new List<string>(clavesYTarjetas);
                List<Filtrada> dataBreach = dataBreachString.Select(s => new Filtrada(s)).ToList();
                return dataBreach;
            }
            catch (Exception)
            {
                throw new ArchivoNoExistenteException();
            }
        }
    }
}
