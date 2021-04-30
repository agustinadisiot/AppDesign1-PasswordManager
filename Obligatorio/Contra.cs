using System;

namespace Obligatorio
{
    public class Contra
    {
        public string UsuarioContra
        {
            get { return UsuarioContra; }
            set { this.UsuarioContra = VerificadoraString.verificarLargoXaY(value, 5, 25); }
        }

        public string Clave
        {
            get { return Clave; }
            set { this.Clave = VerificadoraString.verificarLargoXaY(value, 5, 25); }
        }

        public string Sitio
        {
            get { return Sitio; }
            set { this.Sitio = VerificadoraString.verificarLargoXaY(value, 3, 25); }
        }

        public string Nota
        {
            get { return Nota; }
            set { this.Nota = VerificadoraString.verificarLargoXaY(value, 0, 250); }
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