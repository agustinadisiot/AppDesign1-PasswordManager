using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Obligatorio
{
    public static class VerificadoraString
    {
        public static string VerificarLargoXaY(string dato, int x, int y)
        {
            if (dato.Length < x || dato.Length > y)
            {
                throw new LargoIncorrectoException();
            }
            else
            {
                return dato;
            }
        }

        public static bool EsSimbolo(char ingreso) {
            int caracterASCII = (int)ingreso;
            return ((caracterASCII >= 32 && caracterASCII <= 47) || (caracterASCII >= 58 && caracterASCII <= 64) || (caracterASCII >= 91 && caracterASCII <= 96) || (caracterASCII >= 123 && caracterASCII <= 126));
        }

        public static bool EsMayuscula(char ingreso) {
            int caracterASCII = (int)ingreso;
            return (caracterASCII >= 65 && caracterASCII <= 90);
        }

        public static bool EsMinuscula(char ingreso) {
            int caracterASCII = (int)ingreso;
            return (caracterASCII >= 97 && caracterASCII <= 122);
        }

        public static bool EsNumero(char ingreso) {
            int caracterASCII = (int)ingreso;
            return (caracterASCII >= 48 && caracterASCII <= 57);
        }

    }
}
