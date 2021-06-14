using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaDeNegocio
{
    public interface IControladora<T>
    {
        void Verificar(T aVerificar);

        void Modificar(T nueva);
    }
}
