using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace Negocio
{
    public class Tarjeta
    {

        public List<DataBreach> DataBreaches { get; set; }

        public Tarjeta() {
            this.DataBreaches = new List<DataBreach>();
        }

        public int Id { get; set; }

        public string Nombre { get; set; }

        public string Tipo { get; set; }

        public string Numero { get; set; }

        public string Codigo { get; set; }

        public DateTime Vencimiento { get; set; }

        public string Nota { get; set; }

        public override bool Equals(object objeto)
        {
            if (objeto == null) throw new ObjetoIncompletoException();
            if (objeto.GetType() != this.GetType()) throw new ObjetoIncorrectoException();
            Tarjeta aIgualar = (Tarjeta)objeto;
            return aIgualar.Numero == this.Numero;
        }
    }
}