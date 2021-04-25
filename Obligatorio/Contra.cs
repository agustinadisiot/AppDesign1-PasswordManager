using System;

namespace Obligatorio
{
    public class Contra
    {
        private string usuario;
        private string clave;
        private string sitio;
        private string nota;

        public string UsuarioContra
        {
            get { return usuario; }
            set { this.usuario = VerificadoraString.verificarLargoXaY(value, 5, 25); }
        }

        public string Clave
        {
            get { return clave; }
            set { this.clave = VerificadoraString.verificarLargoXaY(value, 5, 25); }
        }

        public string Sitio
        {
            get { return sitio; }
            set { this.sitio = VerificadoraString.verificarLargoXaY(value, 3, 25); }
        }

        public string Nota
        {
            get { return nota; }
            set { this.nota = VerificadoraString.verificarLargoXaY(value, 0, 250); }
        }

        public string getNivelSeguridad()
        {
            string rojo = "rojo", naranja = "naranja", amarillo = "amarillo", verdeClaro = "verde claro", verdeOscuro = "verde oscuro";
            if (this.clave.Length < 8) return rojo;
            if(this.clave.Length < 14) return naranja;

            bool tieneMin = false, tieneMay = false, tieneNum = false, tieneSim = false;
            foreach (char c in this.clave)
            {
                if (!tieneMay || !tieneMin || !tieneMin || !tieneSim)
                {
                    tieneMin = tieneMin || VerificadoraString.esMinuscula(c);
                    tieneMay = tieneMay || VerificadoraString.esMayuscula(c);
                    tieneNum = tieneNum || VerificadoraString.esNumero(c);
                    tieneSim = tieneSim || VerificadoraString.esSimbolo(c);
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