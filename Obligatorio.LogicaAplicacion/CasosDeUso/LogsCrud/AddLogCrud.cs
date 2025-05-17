using Obligatorio.CasosDeUsoCompartida.DTOs.LogsCrud;
using Obligatorio.CasosDeUsoCompartida.InterfacesCU;
using Obligatorio.LogicaAplicacion.Mapper;
using Obligatorio.LogicaNegocio.InterfacesRepositorios;

namespace Obligatorio.LogicaAplicacion.CasosDeUso.LogsCrud
{
    public class AddLogCrud : IAdd<LogCrudDTO>
    {
        private IRepositorioLogCrud _repo;

        public AddLogCrud(IRepositorioLogCrud repo)
        {
            _repo = repo;
        }

        public void Execute(LogCrudDTO logCrud)
        {
            _repo.Add(LogCrudMapper.FromDTO(logCrud));
        }
    }
}
