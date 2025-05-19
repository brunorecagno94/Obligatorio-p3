using Obligatorio.CasosDeUsoCompartida.DTOs.Agencias;
using Obligatorio.CasosDeUsoCompartida.InterfacesCU;
using Obligatorio.LogicaAplicacion.Mapper;
using Obligatorio.LogicaNegocio.InterfacesRepositorios;

namespace Obligatorio.LogicaAplicacion.CasosDeUso.Agencias
{
    public class GetAllAgencias : IGetAll<AgenciaListadaDTO>
    {
        public IRepositorioAgencia _repo;

        public GetAllAgencias(IRepositorioAgencia repo)
        {
            _repo = repo;
        }
        public IEnumerable<AgenciaListadaDTO> Execute()
        {
            return AgenciaMapper.ToListDto(_repo.GetAll());
        }
    }
}
