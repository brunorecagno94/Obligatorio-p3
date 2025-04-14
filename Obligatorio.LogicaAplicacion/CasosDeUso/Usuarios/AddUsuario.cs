
using Obligatorio.CasosDeUsoCompartida.DTOs.Usuarios;
using Obligatorio.CasosDeUsoCompartida.InterfacesCU;
using Obligatorio.LogicaAplicacion.Mapper;
using Obligatorio.LogicaNegocio.InterfacesRepositorios;

namespace Obligatorio.LogicaAplicacion.CasosDeUso.Usuarios
{
    public class AddUsuario : IAdd<UsuarioDTO>
    {
        private IRepositorioUsuario _repo;

        public AddUsuario(IRepositorioUsuario repo)
        {
            _repo = repo;   
        }

        public void Execute(UsuarioDTO obj)
        {
            _repo.Add(UsuarioMapper.FromDTO(obj));
        }
    }
}
