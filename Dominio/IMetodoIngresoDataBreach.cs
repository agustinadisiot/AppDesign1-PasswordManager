using Negocio;
using System.Collections.Generic;

namespace LogicaDeNegocio
{
    public interface IMetodoIngresoDataBreach<T>
    {
        List<Filtrada> DevolverFiltradas(T ingreso);
    }
}
