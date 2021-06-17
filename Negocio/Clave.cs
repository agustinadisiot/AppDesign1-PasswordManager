using System;
using System.Collections.Generic;

namespace Negocio
{
    public class Clave
    {
        public Clave()
        {
            this.EsCompartida = false;
            this.FechaModificacion = DateTime.Now.Date;
            this.DataBreaches = new List<DataBreach>();
        }

        public List<DataBreach> DataBreaches { get; set; }

        public int Id { get; set; }

        public string UsuarioClave { get; set; }

        public string Codigo { get; set; }

        public bool EsCompartida { get; set; }

        public string Sitio { get; set; }

        public string Nota { get; set; }

        public DateTime FechaModificacion { get; set; }
        public override bool Equals(object objeto)
        {
            if (objeto == null) throw new ObjetoIncompletoException();
            if (this.GetType() != objeto.GetType()) throw new ObjetoIncorrectoException();
            Clave aIgualar = (Clave)objeto;
            bool mismoSitio = aIgualar.Sitio.ToUpper() == this.Sitio.ToUpper();
            bool mismoUsuario = aIgualar.UsuarioClave.ToUpper() == this.UsuarioClave.ToUpper();
            return (mismoSitio && mismoUsuario);
        }
    }
}
