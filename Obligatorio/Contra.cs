using System;

namespace Obligatorio
{
    public class Contra
    {
        private string _usuario;
        private string _clave;
        private string _sitio;
        private string _nota;
        private DateTime _fechaModificacion;
        public bool EsCompartida;
        private const int _largoUsuarioYClaveMinimo = 5;
        private const int _largoUsuarioYClaveMaximo = 25;
        private const int _largoSitioMinimo = 3;
        private const int _largoSitioMaximo = 25;
        private const int _largoNotaMinimo = 0;
        private const int _largoNotaMaximo = 250;

        public Contra()
        {
            this.EsCompartida = false;
        }

        public string UsuarioContra
        {
            get { return _usuario; }
            set { this._usuario = VerificadoraString.VerificarLargoEntreMinimoYMaximo(value, _largoUsuarioYClaveMinimo, _largoUsuarioYClaveMaximo); }
        }

        public string Clave
        {
            get { return _clave; }
            set { CambioClave(value); }
        }


        private void CambioClave(string ingreso) {

            try
            {
                this._clave = VerificadoraString.VerificarLargoEntreMinimoYMaximo(ingreso, _largoUsuarioYClaveMinimo, _largoUsuarioYClaveMaximo);
                this.ActualizarFechaModificacion();
            }
            catch (LargoIncorrectoException) {
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


        public string GetNivelSeguridad()
        {
            const int largoRojoMaximo = 7;
            const int largoNaranjaMaximo = 13;

            string rojo = "rojo",
                naranja = "naranja",
                amarillo = "amarillo",
                verdeClaro = "verde claro",
                verdeOscuro = "verde oscuro";

            if (this.Clave.Length <= largoRojoMaximo) return rojo;
            if(this.Clave.Length <= largoNaranjaMaximo) return naranja;

            bool tieneMin = false,
                tieneMay = false,
                tieneNum = false,
                tieneSim = false;

            foreach (char caracter in this.Clave)
            {
                if (!tieneMay || !tieneMin || !tieneMin || !tieneSim)
                {
                    tieneMin = tieneMin || VerificadoraString.EsMinuscula(caracter);
                    tieneMay = tieneMay || VerificadoraString.EsMayuscula(caracter);
                    tieneNum = tieneNum || VerificadoraString.EsNumero(caracter);
                    tieneSim = tieneSim || VerificadoraString.EsSimbolo(caracter);
                }
                else return verdeOscuro;
            }
            if(tieneMin && tieneMay) return (tieneNum && tieneSim) ? verdeOscuro : verdeClaro;

            return amarillo;   
        }

        public override bool Equals(object objeto)
        {
            if (objeto == null) throw new ObjetoIncompletoException();
            if (this.GetType() != objeto.GetType()) throw new ObjetoIncorrectoException();
            Contra aIgualar = (Contra)objeto;
            bool mismoSitio = aIgualar.Sitio.ToUpper() == this.Sitio.ToUpper();
            bool mismoUsuario = aIgualar.UsuarioContra == this.UsuarioContra;
            return (mismoSitio && mismoUsuario);
        }

        private void ActualizarFechaModificacion()
        {
            this._fechaModificacion = new System.DateTime().Date;
        }
    }
}