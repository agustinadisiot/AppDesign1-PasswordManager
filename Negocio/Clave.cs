using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Negocio
{
    public class Clave
    {
        private string _usuario;
        private string _codigo;
        private string _sitio;
        private string _nota;
        private DateTime _fechaModificacion;
        private const int _largoUsuarioYClaveMinimo = 5;
        private const int _largoUsuarioYClaveMaximo = 25;
        private const int _largoSitioMinimo = 3;
        private const int _largoSitioMaximo = 25;
        private const int _largoNotaMinimo = 0;
        private const int _largoNotaMaximo = 250;

        public List<DataBreach> DataBreaches { get; set; }

        public Clave()
        {
            this.EsCompartida = false;
            this._fechaModificacion = DateTime.Now.Date;
            this.DataBreaches = new List<DataBreach>();
        }

        public int Id { get; set; }

        public string UsuarioClave
        {
            get { return _usuario; }
            set { this._usuario = VerificadoraString.VerificarLargoEntreMinimoYMaximo(value, _largoUsuarioYClaveMinimo, _largoUsuarioYClaveMaximo); }
        }

        public string Codigo
        {
            get { return _codigo; }
            set { CambioClave(value); }
        }

        public bool EsCompartida { get; set; }

        public string Sitio
        {
            get { return _sitio; }
            set { this._sitio = VerificadoraString.VerificarLargoEntreMinimoYMaximo(value, _largoSitioMinimo, _largoSitioMaximo); }
        }

        public string Nota
        {
            get { return _nota; }
            set { this._nota = VerificadoraString.VerificarLargoEntreMinimoYMaximo(value, _largoNotaMinimo, _largoNotaMaximo); }
        }

        public DateTime FechaModificacion
        {
            get { return this._fechaModificacion; }
            set { this._fechaModificacion = value; }
        }
    }
}
