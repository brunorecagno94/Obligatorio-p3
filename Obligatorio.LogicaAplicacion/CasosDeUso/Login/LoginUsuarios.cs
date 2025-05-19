
using Obligatorio.CasosDeUsoCompartida.DTOs.Usuarios;
using Obligatorio.CasosDeUsoCompartida.InterfacesCU.Usuario;
using Obligatorio.LogicaNegocio.Excepciones;
using Obligatorio.LogicaNegocio.InterfacesRepositorios;

namespace Obligatorio.LogicaAplicacion.CasosDeUso.Login
{
    public class LoginUsuarios : ILoginUsuario
    {
        private IRepositorioUsuario _repo;

        public LoginUsuarios(IRepositorioUsuario repo)
        {
            _repo = repo;
        }

        public UsuarioAutenticadoDTO Execute(UsuarioLoginDTO credenciales)
        {
            var usuario = _repo.GetByEmail(credenciales.Email);

            if (usuario == null || usuario.Contrasena.Value != credenciales.Contrasena || usuario.Discriminator == "Cliente" || !usuario.Activo)
            {
                throw new LoginErrorException();
            }

            return new UsuarioAutenticadoDTO(
                usuario.Id,
                usuario.Email.Value,
                usuario.Nombre.Value,
                usuario.Discriminator
            );
        }
    }
}
