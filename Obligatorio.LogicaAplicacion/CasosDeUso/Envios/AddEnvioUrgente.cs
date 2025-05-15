using Obligatorio.CasosDeUsoCompartida.DTOs.Envio;
using Obligatorio.CasosDeUsoCompartida.InterfacesCU;
using Obligatorio.LogicaAplicacion.Mapper;
using Obligatorio.LogicaNegocio.InterfacesRepositorios;

namespace Obligatorio.LogicaAplicacion.CasosDeUso.Envios
{
    public class AddEnvioUrgente : IAdd<EnvioDTO>
    {
        private IRepositorioEnvio _repo;

        public AddEnvioUrgente(IRepositorioEnvio repo)
        {
            _repo = repo;
        }


        public void Execute(EnvioDTO obj)
        {
            _repo.Add(EnvioMapper.FromDTOtoEnvioUrgente(obj));
        }
    }
}