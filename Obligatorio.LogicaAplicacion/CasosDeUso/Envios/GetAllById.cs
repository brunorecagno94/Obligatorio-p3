using Obligatorio.CasosDeUsoCompartida.DTOs.Envio;
using Obligatorio.CasosDeUsoCompartida.InterfacesCU.Envio;
using Obligatorio.LogicaAplicacion.Mapper;
using Obligatorio.LogicaNegocio.InterfacesRepositorios;

namespace Obligatorio.LogicaAplicacion.CasosDeUso.Envios
{
    public class GetAllById : IGetAllById<EnvioListadoDTO>
    {
        IRepositorioEnvio _repo;

        public GetAllById(IRepositorioEnvio repo)
        {
            _repo = repo;
        }

        public IEnumerable<EnvioListadoDTO> Execute(int id)
        {
            return EnvioMapper.ToListDto(_repo.GetAllById(id));
        }
    }
}
