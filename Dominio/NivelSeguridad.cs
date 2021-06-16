using Negocio;
using System;
using System.Collections.Generic;
using System.Linq;

namespace LogicaDeNegocio
{
    public class NivelSeguridad
    {
        public string GetNivelSeguridad(String clave)
        {
            const int largoRojoMaximo = 7;
            const int largoNaranjaMaximo = 13;
            ColorNivelSeguridad color = new ColorNivelSeguridad();

            if (clave.Length <= largoRojoMaximo) return color.Rojo;
            if (clave.Length <= largoNaranjaMaximo) return color.Naranja;

            bool tieneMin = false,
                tieneMay = false,
                tieneNum = false,
                tieneSim = false;

            foreach (char caracter in clave)
            {
                if (!tieneMay || !tieneMin || !tieneNum || !tieneSim)
                {
                    tieneMin = tieneMin || VerificadoraString.EsMinuscula(caracter);
                    tieneMay = tieneMay || VerificadoraString.EsMayuscula(caracter);
                    tieneNum = tieneNum || VerificadoraString.EsNumero(caracter);
                    tieneSim = tieneSim || VerificadoraString.EsSimbolo(caracter);
                }
                else return color.VerdeOscuro;
            }
            if (tieneMin && tieneMay) return (tieneNum && tieneSim) ? color.VerdeOscuro : color.VerdeClaro;

            return color.Amarillo;
        }

        public bool EsClaveRepetida(string aVerificar, Usuario contenedor)
        {
            ControladoraUsuario controladoraUsuario = new ControladoraUsuario();
            List<Clave> clavesUsuario = controladoraUsuario.GetListaClaves(contenedor);

            return clavesUsuario.Any(actual => actual.Codigo.Equals(aVerificar));
        }

        public bool EsClaveNivelSeguro(string aVerificar)
        {
            ColorNivelSeguridad color = new ColorNivelSeguridad();

            string colorAVerificar = this.GetNivelSeguridad(aVerificar);
            if (colorAVerificar.Equals(color.VerdeClaro) || colorAVerificar.Equals(color.VerdeOscuro))
            {
                return true;
            }
            return false;
        }

        public void ClaveCumpleRequerimientos(string aVerificar, Usuario contenedor)
        {
            if (this.EsClaveRepetida(aVerificar, contenedor)) throw new ClaveDuplicadaException();
            if (!this.EsClaveNivelSeguro(aVerificar)) throw new ClaveNoSeguraException();
            if (this.EstaClaveContenidaEnDataBrech(aVerificar, contenedor)) throw new ClaveEstaEnDataBreachException();
        }

        public bool EstaClaveContenidaEnDataBrech(string aVerificar, Usuario usuario)
        {
            ControladoraClave controladoraClave = new ControladoraClave();
            Clave claveAVerificar = new Clave()
            {
                Codigo = aVerificar
            };
            foreach(DataBreach dataBreach in usuario.DataBreaches)
            {
                if (controladoraClave.FueFiltrado(claveAVerificar, dataBreach.Filtradas))
                {
                    return true;
                }
            }
            return false;
        }
    }
}
