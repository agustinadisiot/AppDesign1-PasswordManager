using Negocio;

namespace Negocio
{
    public class ClaveAModificar
    {
        public Clave ClaveVieja { get; set; }
        public Clave ClaveNueva { get; set; }
        public Categoria CategoriaVieja { get; set; }
        public Categoria CategoriaNueva { get; set; }
    }
}