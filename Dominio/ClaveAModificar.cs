namespace LogicaDeNegocio
{
    public class ClaveAModificar
    {
        public ControladoraClave ClaveVieja { get; set; }
        public ControladoraClave ClaveNueva { get; set; }
        public ControladoraCategoria CategoriaVieja { get; set; }
        public ControladoraCategoria CategoriaNueva { get; set; }
    }
}