using Obligatorio.CasosDeUsoCompartida.DTOs.Envio;
using Obligatorio.CasosDeUsoCompartida.InterfacesCU.Envio;
using Obligatorio.LogicaAplicacion.Mapper;
using Obligatorio.LogicaNegocio.InterfacesRepositorios;

namespace Obligatorio.LogicaAplicacion.CasosDeUso.Envios
{
    public class FiltrarPorFechaYEstado : IFiltrarPorFechaYEstado<EnvioListadoDTO>
    {
        IRepositorioEnvio _repo;

        public FiltrarPorFechaYEstado(IRepositorioEnvio repo)
        {
            _repo = repo;
        }

        public IEnumerable<EnvioListadoDTO> Execute(int idUsuario, DateTime fechaInicio, DateTime fechaFin, string estado)
        {
            return EnvioMapper.ToListDto(_repo.FiltrarPorFechaYEstado(idUsuario, fechaInicio, fechaFin, estado));
        }
    }
}