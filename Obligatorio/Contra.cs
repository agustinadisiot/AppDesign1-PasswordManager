using System;

namespace Obligatorio
{
    public class Contra
    {
        private string _usuario;
        private string _clave;
        private string _sitio;
        private string _nota;
        private const int largoUsuarioYClaveMinimo = 5;
        private const int largoUsuarioYClaveMaximo = 25;
        private const int largoSitioMinimo = 3;
        private const int largoSitioMaximo = 25;
        private const int largoNotaMinimo = 0;
        private const int largoNotaMaximo = 250;

        public string UsuarioContra
        {
            get { return _usuario; }
            set { this._usuario = VerificadoraString.VerificarLargoXaY(value, largoUsuarioYClaveMinimo, largoUsuarioYClaveMaximo); }
        }

        public string Clave
        {
            get { return _clave; }
            set { this._clave = VerificadoraString.VerificarLargoXaY(value, largoUsuarioYClaveMinimo, largoUsuarioYClaveMaximo); }
        }

        public string Sitio
        {
            get { return _sitio; }
            set { this._sitio = VerificadoraString.VerificarLargoXaY(value, largoSitioMinimo, largoSitioMaximo); }
        }

        public string Nota
        {
            get { return _nota; }
            set { this._nota = VerificadoraString.VerificarLargoXaY(value, largoNotaMinimo, largoNotaMaximo); }
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

            foreach (char c in this.Clave)
            {
                if (!tieneMay || !tieneMin || !tieneMin || !tieneSim)
                {
                    tieneMin = tieneMin || VerificadoraString.EsMinuscula(c);
                    tieneMay = tieneMay || VerificadoraString.EsMayuscula(c);
                    tieneNum = tieneNum || VerificadoraString.EsNumero(c);
                    tieneSim = tieneSim || VerificadoraString.EsSimbolo(c);
                }
                else return verdeOscuro;
            }
            if(tieneMin && tieneMay) return (tieneNum && tieneSim) ? verdeOscuro : verdeClaro;

            return amarillo;   
        }

        public override bool Equals(object obj)
        {
            if (obj == null) throw new ObjetoIncompletoException();
            if (this.GetType() != obj.GetType()) throw new ObjetoIncorrectoException();
            Contra aIgualar = (Contra)obj;
            bool mismoSitio = aIgualar.Sitio.ToUpper() == this.Sitio.ToUpper();
            bool mismoUsuario = aIgualar.UsuarioContra == this.UsuarioContra;
            return mismoSitio && mismoUsuario;
        }
    }
}