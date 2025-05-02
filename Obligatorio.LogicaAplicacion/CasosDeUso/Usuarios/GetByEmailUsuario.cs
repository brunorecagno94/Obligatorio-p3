using Obligatorio.CasosDeUsoCompartida.DTOs.Usuarios;
using Obligatorio.CasosDeUsoCompartida.InterfacesCU;
using Obligatorio.LogicaAplicacion.Mapper;
using Obligatorio.LogicaNegocio.InterfacesRepositorios;

namespace Obligatorio.LogicaAplicacion.CasosDeUso.Usuarios
{
    public class GetByEmailUsuario : IGetByEmail<UsuarioListadoDTO>
    {
        private IRepositorioUsuario _repo;

        public GetByEmailUsuario(IRepositorioUsuario repo)
        {
            _repo = repo;
        }

        public UsuarioListadoDTO Execute(string email)
        {
            return UsuarioMapper.ToDTO(_repo.GetByEmail(email));
        }
    }
}
