using Obligatorio.CasosDeUsoCompartida.InterfacesCU.Envio;
using Obligatorio.LogicaNegocio.InterfacesRepositorios;

namespace Obligatorio.LogicaAplicacion.CasosDeUso.Envios
{
    public class FinalizarEnvio : IFinalizarEnvio
    {
        private IRepositorioEnvio _repo;

        public FinalizarEnvio(IRepositorioEnvio repo)
        {
            _repo = repo;
        }

        public void Execute(int id)
        {
            _repo.Finalizar(id);
        }
    }
}
