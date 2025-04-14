using Obligatorio.CasosDeUsoCompartida.DTOs.Usuarios;
using Obligatorio.CasosDeUsoCompartida.InterfacesCU;
using Obligatorio.LogicaAplicacion.Mapper;
using Obligatorio.LogicaNegocio.InterfacesRepositorios;

namespace Obligatorio.LogicaAplicacion.CasosDeUso.Usuarios
{
    public class UpdateUsuario : IUpdate<UsuarioDTO>
    {
        private IRepositorioUsuario _repo;

        public UpdateUsuario(IRepositorioUsuario repo)
        {
            _repo = repo;
        }

        public void Execute(int id, UsuarioDTO obj)
        {
            _repo.Update(id, UsuarioMapper.FromDTO(obj));
        }
    }
}
