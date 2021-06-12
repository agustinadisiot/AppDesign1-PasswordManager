using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
                if (!tieneMay || !tieneMin || !tieneMin || !tieneSim)
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
    }
}
