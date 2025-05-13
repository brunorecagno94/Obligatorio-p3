using Obligatorio.CasosDeUsoCompartida.InterfacesCU;
using Obligatorio.LogicaNegocio.Entidades;
using Obligatorio.LogicaNegocio.InterfacesRepositorios;

namespace Obligatorio.LogicaAplicacion.CasosDeUso.LogsCrud
{
    public class AddLogCrud : IAdd<LogCrud>
    {
        private IRepositorioLogCrud _repo;

        public AddLogCrud(IRepositorioLogCrud repo)
        {
            _repo = repo;
        }

        public void Execute(LogCrud logCrud)
        {
            _repo.Add(logCrud);
        }
    }
}
