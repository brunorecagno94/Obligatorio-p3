using Obligatorio.CasosDeUsoCompartida.DTOs.Envio;
using Obligatorio.CasosDeUsoCompartida.InterfacesCU;
using Obligatorio.LogicaAplicacion.Mapper;
using Obligatorio.LogicaNegocio.InterfacesRepositorios;

namespace Obligatorio.LogicaAplicacion.CasosDeUso.Envios
{
    public class AddEnvioComun : IAdd<EnvioDTO>
    {
        private IRepositorioEnvio _repo;

        public AddEnvioComun(IRepositorioEnvio repo)
        {
            _repo = repo;
        }

        public void Execute(EnvioDTO obj)
        {
            _repo.Add(EnvioMapper.FromDTOtoEnvioComun(obj));
        }
    }
}
