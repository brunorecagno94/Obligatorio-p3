namespace Obligatorio.LogicaNegocio.InterfacesRepositorios
{
    public interface IRepositorioGetByNumeroTracking<T>
    {
        T GetByNumeroTracking(int numeroTracking);
    }
}
