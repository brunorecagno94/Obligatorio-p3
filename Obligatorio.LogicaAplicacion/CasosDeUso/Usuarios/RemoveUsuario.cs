using Obligatorio.CasosDeUsoCompartida.InterfacesCU;
using Obligatorio.LogicaNegocio.InterfacesRepositorios;

namespace Obligatorio.LogicaAplicacion.CasosDeUso.Usuarios
{
    public class RemoveUsuario : IRemove
    {
        private IRepositorioUsuario _repo;

        public RemoveUsuario(IRepositorioUsuario repo)
        {
            _repo = repo;
        }
        public void Execute(int id)
        {
            _repo.Remove(id);
        }
    }
}
