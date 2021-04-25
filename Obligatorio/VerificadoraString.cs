using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Obligatorio
{
    public static class VerificadoraString
    {
        public static string verificarLargoXaY(string dato, int x, int y)
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

        //Verifica si el caracter ingreso es un simbolo al fijarse su numero en ASCII
        public static bool esSimbolo(char ingreso) {
            int caracterASCII = (int)ingreso;
            return ((caracterASCII >= 32 && caracterASCII <= 47) || (caracterASCII >= 58 && caracterASCII <= 64) || (caracterASCII >= 91 && caracterASCII <= 96) || (caracterASCII >= 123 && caracterASCII <= 126));
        }

        //Verifica si el caracter ingreso es una mayuscula al fijarse su numero en ASCII
        public static bool esMayuscula(char ingreso) {
            int caracterASCII = (int)ingreso;
            return (caracterASCII >= 65 && caracterASCII <= 90);
        }

        //Verifica si el caracter ingreso es una minuscula al fijarse su numero en ASCII
        public static bool esMinuscula(char ingreso) {
            int caracterASCII = (int)ingreso;
            return (caracterASCII >= 97 && caracterASCII <= 122);
        }

        //Verifica si el caracter ingreso es un numero al fijarse su numero en ASCII
        public static bool esNumero(char ingreso) {
            int caracterASCII = (int)ingreso;
            return (caracterASCII >= 48 && caracterASCII <= 57);
        }

    }
}
