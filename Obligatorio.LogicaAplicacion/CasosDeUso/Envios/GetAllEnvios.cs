using Obligatorio.CasosDeUsoCompartida.DTOs.Envio;
using Obligatorio.CasosDeUsoCompartida.InterfacesCU;
using Obligatorio.LogicaAplicacion.Mapper;
using Obligatorio.LogicaNegocio.InterfacesRepositorios;

namespace Obligatorio.LogicaAplicacion.CasosDeUso.Envios
{
    public class GetAllEnvios : IGetAll<EnvioListadoDTO>
    {
        private IRepositorioEnvio _repo;

        public GetAllEnvios(IRepositorioEnvio repo)
        {
            _repo = repo;
        }

        public IEnumerable<EnvioListadoDTO> Execute()
        {
            return EnvioMapper.ToListDto(_repo.GetAll());
        }
    }
}
