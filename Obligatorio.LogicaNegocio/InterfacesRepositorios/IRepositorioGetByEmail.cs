namespace Obligatorio.LogicaNegocio.InterfacesRepositorios
{
    public interface IRepositorioGetByEmail <T>
    {
        T GetByEmail (string email);
    }
}
