using Obligatorio.CasosDeUsoCompartida.DTOs.Envio;
using Obligatorio.CasosDeUsoCompartida.InterfacesCU;
using Obligatorio.LogicaAplicacion.Mapper;
using Obligatorio.LogicaNegocio.InterfacesRepositorios;

namespace Obligatorio.LogicaAplicacion.CasosDeUso.Envios
{
    public class GetByIdEnvio : IGetById<EnvioListadoDTO>
    {
        private IRepositorioEnvio _repo;

        public GetByIdEnvio(IRepositorioEnvio repo)
        {
            _repo = repo;
        }

        public EnvioListadoDTO Execute(int id)
        {
            return EnvioMapper.ToDTO(_repo.GetById(id));
        }
    }
}
