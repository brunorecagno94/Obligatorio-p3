using Obligatorio.CasosDeUsoCompartida.DTOs.Envio;
using Obligatorio.CasosDeUsoCompartida.InterfacesCU;
using Obligatorio.LogicaAplicacion.Mapper;
using Obligatorio.LogicaNegocio.InterfacesRepositorios;

namespace Obligatorio.LogicaAplicacion.CasosDeUso.Envios
{
    public class AddEnvio : IAdd<EnvioDTO>
    {
        private IRepositorioEnvio _repo;

        public AddEnvio(IRepositorioEnvio repo)
        {
            _repo = repo;
        }


        public void Execute(EnvioDTO obj)
        {
            if (obj.EsUrgente)
            {
                _repo.Add(EnvioMapper.FromDTOtoEnvioUrgente(obj));
            }
            else
            {
                _repo.Add(EnvioMapper.FromDTOtoEnvioComun(obj));
            }
        }
    }
}