namespace LogicaDeNegocio
{
    public class ClaveAModificar
    {
        public ControladoraClave ClaveVieja { get; set; }
        public ControladoraClave ClaveNueva { get; set; }
        public Categoria CategoriaVieja { get; set; }
        public Categoria CategoriaNueva { get; set; }
    }
}