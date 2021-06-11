using System;
using System.Collections.Generic;

namespace Dominio
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

        public ICollection<DataBreach> DataBreaches { get; set; }

        public Clave()
        {
            this.EsCompartida = false;
            this._fechaModificacion = DateTime.Now.Date;
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

        private void CambioClave(string ingreso)
        {

            try
            {
                this._codigo = VerificadoraString.VerificarLargoEntreMinimoYMaximo(ingreso, _largoUsuarioYClaveMinimo, _largoUsuarioYClaveMaximo);
                this.ActualizarFechaModificacion();
            }
            catch (LargoIncorrectoException)
            {
                throw new LargoIncorrectoException();
            }
        }

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

        public override bool Equals(object objeto)
        {
            if (objeto == null) throw new ObjetoIncompletoException();
            if (this.GetType() != objeto.GetType()) throw new ObjetoIncorrectoException();
            Clave aIgualar = (Clave)objeto;
            bool mismoSitio = aIgualar.Sitio.ToUpper() == this.Sitio.ToUpper();
            bool mismoUsuario = aIgualar.UsuarioClave.ToUpper() == this.UsuarioClave.ToUpper();
            return (mismoSitio && mismoUsuario);
        }

        private void ActualizarFechaModificacion()
        {
            this._fechaModificacion = System.DateTime.Now.Date;
        }

        public bool FueFiltrado(List<Filtrada> filtradas)
        {
            return filtradas.Exists(f => this.Codigo.Equals(f.Texto));
        }
    }
}