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

    }
}
