using Negocio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaDeNegocio
{
    public interface IMetodoIngresoDataBreach<T>
    {
        List<Filtrada> DevolverFiltradas(T ingreso);
    }
}
