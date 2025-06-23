using Obligatorio.LogicaNegocio.Entidades;
using Obligatorio.LogicaNegocio.VO;

namespace Obligatorio.LogicaNegocio.InterfacesRepositorios
{
    public interface IRepositorioEnvio : IRepositorioAdd<Envio>,
                    IRepositorioGetAll<Envio>,
                    IRepositorioGetAllById<Envio>,
                    IRepositorioGetById<Envio>,
                    IRepositorioUpdate<Envio>,
                    IRepositorioGetByNumeroTracking<Envio>,
                    IRepositorioGetAllComentarios<Comentario>,
                    IRepositorioFinalizarEnvio
    {
    }
}
