using System;

namespace Obligatorio
{
    public class Categoria
    {
        private string nombre;
        private bool noAgregoContra;
        private Contra contraAgregada;

        public Categoria()
        {
            noAgregoContra = true;
            contraAgregada = null;
        }

        public string Nombre
        {
            get { return nombre; }
            set { this.nombre = VerificadoraString.verificarLargoXaY(value, 3, 15); }
        }


        public bool esListaContrasVacia()
        {
            return noAgregoContra;
        }

        public void agregarContra(Contra contraIngresada)
        {
            bool noTieneSitio = (contraIngresada.Sitio == null),
                 noTieneClave = (contraIngresada.Clave == null),
                 noTieneUsuario = (contraIngresada.UsuarioContra == null);


            if (noTieneSitio || noTieneClave || noTieneUsuario ) throw new ObjetoIncompletoException();

            this.noAgregoContra = false;
            this.contraAgregada = contraIngresada;
        }

        public Contra getContra(string sitioABuscar, string usuarioABuscar)
        {
            return this.contraAgregada;
        }
    }
}