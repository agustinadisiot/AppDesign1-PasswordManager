using System;

namespace Obligatorio
{
    public class Contra
    {
        private string _usuario;
        private string _clave;
        private string _sitio;
        private string _nota;

        public string UsuarioContra
        {
            get { return _usuario; }
            set { this._usuario = VerificadoraString.VerificarLargoXaY(value, 5, 25); }
        }

        public string Clave
        {
            get { return _clave; }
            set { this._clave = VerificadoraString.VerificarLargoXaY(value, 5, 25); }
        }

        public string Sitio
        {
            get { return _sitio; }
            set { this._sitio = VerificadoraString.VerificarLargoXaY(value, 3, 25); }
        }

        public string Nota
        {
            get { return _nota; }
            set { this._nota = VerificadoraString.VerificarLargoXaY(value, 0, 250); }
        }

        public string GetNivelSeguridad()
        {
            string rojo = "rojo", naranja = "naranja", amarillo = "amarillo", verdeClaro = "verde claro", verdeOscuro = "verde oscuro";
            if (this.Clave.Length < 8) return rojo;
            if(this.Clave.Length < 14) return naranja;

            bool tieneMin = false, tieneMay = false, tieneNum = false, tieneSim = false;
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