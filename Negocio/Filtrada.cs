using System.Collections.Generic;

namespace Negocio
{
    public class Filtrada
    {
        public virtual List<DataBreach> DataBreaches { get; set; }

        public int Id { get; set; }

        public string Texto { get; set; }

        public Filtrada()
        {
            this.DataBreaches = new List<DataBreach>();
        }

        public Filtrada(string texto)
        {
            this.Texto = texto;
            this.DataBreaches = new List<DataBreach>();
        }
        public override string ToString()
        {
            return this.Texto;
        }

        public override bool Equals(object objeto)
        {
            if (objeto == null) throw new ObjetoIncompletoException();
            if (this.GetType() != objeto.GetType()) throw new ObjetoIncorrectoException();
            Filtrada aIgualar = (Filtrada)objeto;
            bool mismoTexto = aIgualar.Texto == this.Texto;
            return (mismoTexto);
        }
    }
}