namespace LogicaDeNegocio
{
    public interface IControladora<T>
    {
        void Verificar(T aVerificar);

        void Modificar(T nueva);
    }
}
