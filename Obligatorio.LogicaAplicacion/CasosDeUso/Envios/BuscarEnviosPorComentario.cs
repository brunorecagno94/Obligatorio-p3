

using Obligatorio.CasosDeUsoCompartida.DTOs.Envio;
using Obligatorio.CasosDeUsoCompartida.InterfacesCU.Envio;
using Obligatorio.LogicaAplicacion.Mapper;
using Obligatorio.LogicaNegocio.Entidades;
using Obligatorio.LogicaNegocio.InterfacesRepositorios;

namespace Obligatorio.LogicaAplicacion.CasosDeUso.Envios
{
    public class BuscarEnviosPorComentario: IBuscarEnviosPorComentario<EnvioListadoDTO>
    {
        IRepositorioEnvio _repo;

        public BuscarEnviosPorComentario(IRepositorioEnvio repo)
        {
            _repo = repo;
        }

        public IEnumerable<EnvioListadoDTO> Execute(int id, string palabraClave)
        {
            var envios = _repo.BuscarPorComentario(id, palabraClave);
            return EnvioMapper.ToListDto(envios).ToList();
        }
    }
}
