using Obligatorio.CasosDeUsoCompartida.DTOs.Envio;
using Obligatorio.CasosDeUsoCompartida.InterfacesCU.Envio;
using Obligatorio.LogicaAplicacion.Mapper;
using Obligatorio.LogicaNegocio.InterfacesRepositorios;

namespace Obligatorio.LogicaAplicacion.CasosDeUso.Envios
{
    public class GetAllComentarios : IGetAllComentarios<ComentarioDTO>
    {
        IRepositorioEnvio _repo;
        public GetAllComentarios(IRepositorioEnvio repo)
        {
            _repo = repo;
        }
        public IEnumerable<ComentarioDTO> Execute(int id)
        {
            return EnvioMapper.ComentarioToDTO(_repo.GetAllComentarios(id));
        }
    }
}
