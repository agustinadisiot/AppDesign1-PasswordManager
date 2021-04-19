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
            if(this.clave.Length < 8)
            {
                return "rojo";
            }
            else if(this.clave.Length < 14)
            {
                return "naranja";
            }
            else
            {
                bool tieneMin = false;
                bool tieneMay = false;
                bool tieneNum = false;
                bool tieneSim = false;
                foreach (int c in this.clave)
                {
                    if(!tieneMay || !tieneMin || !tieneMin || !tieneSim)
                    {
                        tieneMin = tieneMin || (c >= 97 && c <= 122);
                        tieneMay = tieneMay || (c >= 65 && c <= 90);
                        tieneNum = tieneNum || (c >= 48 && c <= 57);
                        tieneSim = tieneSim || ((c >= 32 && c <= 47) || (c >= 58 && c <= 64) || (c >= 91 && c <= 96) || (c >= 123 && c <= 126));
                    }
                    else
                    {
                        return "verde oscuro";
                    }
                }
                if(tieneMin && tieneMay)
                {
                    if(tieneNum && tieneSim)
                    {
                        return "verde oscuro";
                    }
                    return "verde claro";
                }
            
                return "amarillo";
            }
        }
    }
}