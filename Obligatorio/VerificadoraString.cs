using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Obligatorio
{
    public static class VerificadoraString
    {
        public static string VerificarLargoEntreMinimoYMaximo(string ingreso, int minimo, int maximo)
        {
            if (ingreso==null || ingreso.Length < minimo || ingreso.Length > maximo)
            {
                throw new LargoIncorrectoException();
            }
            else
            {
                return ingreso;
            }
        }

        public static bool EsSimbolo(char ingreso) {
            int asciiIngresado = (int)ingreso;
            const int asciiMinusculaMinimo = 97;
            const int asciiMinusculaMaximo = 122;
            const int asciiMayusculaMinimo = 65;
            const int asciiMayusculaMaximo = 90;
            const int asciiDigitoMinimo = 48;
            const int asciiDigitoMaximo = 57;
            const int asciiEspecialesMinimo = 32;
            const int asciiEspecialesMaximo = 126;

            bool retorno = ( (asciiIngresado >= asciiEspecialesMinimo && asciiIngresado < asciiDigitoMinimo)
                    || (asciiIngresado > asciiDigitoMaximo && asciiIngresado < asciiMayusculaMinimo)
                    || (asciiIngresado > asciiMayusculaMaximo && asciiIngresado < asciiMinusculaMinimo)
                    || (asciiIngresado > asciiMinusculaMaximo && asciiIngresado <= asciiEspecialesMaximo));

            return retorno;
        }

        public static bool EsMayuscula(char ingreso) {
            int asciiIngresado = (int)ingreso;
            const int asciiMayusculaMinimo = 65;
            const int asciiMayusculaMaximo = 90;

            return (asciiIngresado >= asciiMayusculaMinimo && asciiIngresado <= asciiMayusculaMaximo);
        }

        public static bool EsMinuscula(char ingreso) {
            int asciiIngresado = (int)ingreso;
            const int asciiMinusculaMinimo = 97;
            const int asciiMinusculaMaximo = 122;

            return (asciiIngresado >= asciiMinusculaMinimo && asciiIngresado <= asciiMinusculaMaximo);
        }

        public static bool EsNumero(char ingreso) {
            int asciiIngresado = (int)ingreso;
            const int asciiDigitoMinimo = 48;
            const int asciiDigitoMaximo = 57;

            return (asciiIngresado >= asciiDigitoMinimo && asciiIngresado <= asciiDigitoMaximo);
        }

        public static char GenerarMayuscula()
        {
            const int asciiMayusculaMinimo = 65;
            const int asciiMayusculaMaximo = 90;
            Random aleatorio = new Random();
            char retorno = (char)aleatorio.Next(asciiMayusculaMinimo, asciiMayusculaMaximo + 1);
            return retorno;
        }

        internal static char GenerarMinuscula()
        {
            const int asciiMinusculaMinimo = 97;
            const int asciiMinusculaMaximo = 122;
            Random aleatorio = new Random();
            char retorno = (char)aleatorio.Next(asciiMinusculaMinimo, asciiMinusculaMaximo + 1);
            return retorno;
        }

        internal static char GenerarNumero()
        {
            const int asciiDigitoMinimo = 48;
            const int asciiDigitoMaximo = 57;
            Random aleatorio = new Random();
            char retorno = (char)aleatorio.Next(asciiDigitoMinimo, asciiDigitoMaximo + 1);
            return retorno;
        }

        internal static char GenerarSimbolo()
        {
            const int asciiRango1Minimo = 32;
            const int asciiRango1Maximo = 47;
            const int asciiRango2Minimo = 58;
            const int asciiRango2Maximo = 64;
            const int asciiRango3Minimo = 91;
            const int asciiRango3Maximo = 96;
            const int asciiRango4Minimo = 123;
            const int asciiRango4Maximo = 126;
            const int rangoMinimo = 1;
            const int rangoMaximo = 5;

            Random aleatorio = new Random();
            int rango = aleatorio.Next(rangoMinimo, rangoMaximo);
            char resultado;
            switch (rango)
            {
                case 1:
                    resultado =  (char)aleatorio.Next(asciiRango1Minimo, asciiRango1Maximo);
                    break;
                case 2:
                    resultado = (char)aleatorio.Next(asciiRango2Minimo, asciiRango2Maximo);
                    break;
                case 3:
                    resultado = (char)aleatorio.Next(asciiRango3Minimo, asciiRango3Maximo);
                    break;
                case 4:
                    resultado = (char)aleatorio.Next(asciiRango4Minimo, asciiRango4Maximo);
                    break;
                default:
                    throw new CaracterInesperadoException();
                    break;
            }
            return resultado;
        }

    }
}
