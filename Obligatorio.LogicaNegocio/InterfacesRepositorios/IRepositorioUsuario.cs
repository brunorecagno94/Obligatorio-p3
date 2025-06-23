using Obligatorio.LogicaNegocio.Entidades;

namespace Obligatorio.LogicaNegocio.InterfacesRepositorios
{
    public interface IRepositorioUsuario :
                    IRepositorioAdd<Usuario>,
                    IRepositorioGetAll<Usuario>,
                    IRepositorioGetById<Usuario>,
                    IRepositorioRemove,
                    IRepositorioUpdate<Usuario>,
                    IRepositorioGetByEmail<Usuario>,
                    IRepositorioUpdateContrasena
    {
    }
}
