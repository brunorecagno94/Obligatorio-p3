namespace Obligatorio.LogicaNegocio.InterfacesRepositorios
{
    public interface IRepositorioGetAllById<T>
    {
        IEnumerable<T> GetAllById(int id);
    }
}
