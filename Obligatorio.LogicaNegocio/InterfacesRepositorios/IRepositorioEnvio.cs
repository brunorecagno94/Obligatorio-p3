using Obligatorio.LogicaNegocio.Entidades;

namespace Obligatorio.LogicaNegocio.InterfacesRepositorios
{
    public interface IRepositorioEnvio :
                    IRepositorioAdd<Envio>,
                    IRepositorioGetAll<Envio>,
                    IRepositorioGetById<Envio>,
                    IRepositorioUpdate<Envio>
    {
    }
}
