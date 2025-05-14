using Obligatorio.CasosDeUsoCompartida.DTOs.Envio;
using Obligatorio.CasosDeUsoCompartida.InterfacesCU;
using Obligatorio.LogicaAplicacion.Mapper;
using Obligatorio.LogicaNegocio.InterfacesRepositorios;

namespace Obligatorio.LogicaAplicacion.CasosDeUso.Envios
{
    public class UpdateEnvio : IUpdate<EnvioDTO>
    {
        private IRepositorioEnvio _repo;

        public UpdateEnvio(IRepositorioEnvio repo)
        {
            _repo = repo;
        }

        void IUpdate<EnvioDTO>.Execute(int id, EnvioDTO obj)
        {
            throw new NotImplementedException();
        }

        // TODO: resolver si separamos FromDTOEnvioComun/Urgente
        // o hacemos sólo FromDTO
        //public void Execute(int id, EnvioDTO envio)
        //{
        //    _repo.Update(id, EnvioMapper.FromDTO(obj));
        //}
    }
}
