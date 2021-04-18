﻿namespace Obligatorio
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

    }
}