namespace LogicaDeNegocio
{
    public class TarjetaAModificar
    {
        public ControladoraTarjeta TarjetaVieja { get; set; }
        public ControladoraTarjeta TarjetaNueva { get; set; }
        public ControladoraCategoria CategoriaVieja { get; set; }
        public ControladoraCategoria CategoriaNueva { get; set; }
    }
}