using Obligatorio.CasosDeUsoCompartida.DTOs.Envio;
using Obligatorio.CasosDeUsoCompartida.InterfacesCU.Envio;
using Obligatorio.LogicaAplicacion.Mapper;
using Obligatorio.LogicaNegocio.InterfacesRepositorios;

namespace Obligatorio.LogicaAplicacion.CasosDeUso.Envios
{
    public class GetByNumeroTracking : IGetByNumeroTracking<EnvioCompletoListado>
    {
        private IRepositorioEnvio _repo;
        public GetByNumeroTracking(IRepositorioEnvio repo)
        {
            _repo = repo;
        }
        public EnvioCompletoListado Execute(int numeroTracking)
        {
            return EnvioMapper.ToDTOCompleto(_repo.GetByNumeroTracking(numeroTracking));
        }
    }
}
