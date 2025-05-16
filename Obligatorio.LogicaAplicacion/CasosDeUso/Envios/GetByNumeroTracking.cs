

using Obligatorio.CasosDeUsoCompartida.DTOs.Envio;
using Obligatorio.CasosDeUsoCompartida.InterfacesCU;
using Obligatorio.LogicaAplicacion.Mapper;
using Obligatorio.LogicaNegocio.InterfacesRepositorios;

namespace Obligatorio.LogicaAplicacion.CasosDeUso.Envios
{
    public class GetByNumeroTracking : IGetByNumeroTracking<EnvioListadoDTO>
    {
        private IRepositorioEnvio _repo;
        public GetByNumeroTracking(IRepositorioEnvio repo)
        {
            _repo = repo;
        }
        public EnvioListadoDTO Execute(int numeroTracking)
        {
            return EnvioMapper.ToDTO(_repo.GetByNumeroTracking(numeroTracking));
        }
    }
}
