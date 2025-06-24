using Obligatorio.LogicaNegocio.Entidades;

namespace Obligatorio.LogicaNegocio.InterfacesRepositorios
{
    public interface IRepositorioBuscarPorComentario
    {
        IEnumerable<Envio> BuscarPorComentario(int idCliente, string palabraClave);
    }
}
