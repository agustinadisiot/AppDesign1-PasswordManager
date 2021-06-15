using Negocio;
using Repositorio;
using System;
using System.Collections.Generic;

namespace LogicaDeNegocio
{
    public class ControladoraClave: IControladora<Clave>
    {
        private const int _largoUsuarioYClaveMinimo = 5;
        private const int _largoUsuarioYClaveMaximo = 25;
        private const int _largoSitioMinimo = 3;
        private const int _largoSitioMaximo = 25;
        private const int _largoNotaMinimo = 0;
        private const int _largoNotaMaximo = 250;

        public void Modificar(Clave nueva) {
            this.Verificar(nueva);

            DataAccessClave acceso = new DataAccessClave();
            ControladoraEncriptador controladoraEncriptador = new ControladoraEncriptador();
            

            Clave vieja = acceso.Get(nueva.Id);

            if (vieja.Codigo != nueva.Codigo)
            {
                nueva.FechaModificacion = DateTime.Now.Date;
            }
            acceso.Modificar(nueva);
        }

        public void Verificar(Clave aVerificar)
        {
            this.VerificarUsuarioClave(aVerificar);
            this.VerificarCodigo(aVerificar);
            this.VerificarSitio(aVerificar);
            this.VerificarNota(aVerificar);
            this.VerificarSitio(aVerificar);
        }

        public string VerificarUsuarioClave(Clave aVerificar)
        {
            return VerificadoraString.VerificarLargoEntreMinimoYMaximo(aVerificar.UsuarioClave, _largoUsuarioYClaveMinimo, _largoUsuarioYClaveMaximo);
        }

        public void VerificarCodigo(Clave aVerificar)
        {
            VerificadoraString.VerificarLargoEntreMinimoYMaximo(aVerificar.Codigo, _largoUsuarioYClaveMinimo, _largoUsuarioYClaveMaximo);
        }

        public void VerificarSitio(Clave aVerificar)
        {
            VerificadoraString.VerificarLargoEntreMinimoYMaximo(aVerificar.Sitio, _largoSitioMinimo, _largoSitioMaximo);
        }

        public void VerificarNota(Clave aVerificar)
        {
            VerificadoraString.VerificarLargoEntreMinimoYMaximo(aVerificar.Nota, _largoNotaMinimo, _largoNotaMaximo);
        }

        public bool FueFiltrado(Clave aVerificar, List<Filtrada> filtradas)
        {
            return filtradas.Exists(f => aVerificar.Codigo.Equals(f.Texto));
        }

        public void Borrar(Clave aBorrar) {
            this.Verificar(aBorrar);
            DataAccessClave acceso = new DataAccessClave();
            acceso.Borrar(aBorrar);
        }
    }
}