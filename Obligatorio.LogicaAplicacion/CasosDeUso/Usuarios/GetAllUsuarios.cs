using Obligatorio.CasosDeUsoCompartida.DTOs.Usuarios;
using Obligatorio.CasosDeUsoCompartida.InterfacesCU;
using Obligatorio.LogicaAplicacion.Mapper;
using Obligatorio.LogicaNegocio.InterfacesRepositorios;

namespace Obligatorio.LogicaAplicacion.CasosDeUso.Usuarios
{
    public class GetAllUsuarios : IGetAll<UsuarioListadoDTO>
    {
        private IRepositorioUsuario _repo;

        public GetAllUsuarios(IRepositorioUsuario repo)
        {
            _repo = repo;
        }

        public IEnumerable<UsuarioListadoDTO> Execute()
        {
            return UsuarioMapper.ToListDto(_repo.GetAll());
        }
    }
}
