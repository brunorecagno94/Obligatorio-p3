using Obligatorio.CasosDeUsoCompartida.DTOs.Usuarios;
using Obligatorio.CasosDeUsoCompartida.InterfacesCU;
using Obligatorio.LogicaAplicacion.Mapper;
using Obligatorio.LogicaNegocio.InterfacesRepositorios;


namespace Obligatorio.LogicaAplicacion.CasosDeUso.Usuarios
{
    public class GetByIdUsuario : IGetById<UsuarioListadoDTO>
    {
        private IRepositorioUsuario _repo;

        public GetByIdUsuario(IRepositorioUsuario repo)
        {
            _repo = repo;
        }

        public UsuarioListadoDTO Execute(int id)
        {
            return UsuarioMapper.ToDTO(_repo.GetById(id));
        }
    }
}
