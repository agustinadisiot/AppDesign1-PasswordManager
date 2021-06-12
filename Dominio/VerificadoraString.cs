namespace LogicaDeNegocio
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
    }
}
