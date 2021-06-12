using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
    }
}
