namespace Obligatorio.LogicaNegocio.InterfacesRepositorios
{
    public interface IRepositorioGetAllComentarios<T>
    {
        IEnumerable<T> GetAllComentarios(int id);
    }
}
