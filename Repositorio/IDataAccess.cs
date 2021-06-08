using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositorio
{
    public interface IDataAccess<T>
    {
        T Get(int id);
        IEnumerable<T> GetTodos();
        void Agregar(T entity);
        void Modificar(T entity);
        void Borrar(T entity);
    }
}
