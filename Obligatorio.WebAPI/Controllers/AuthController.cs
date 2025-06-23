using Libreria.WebApi.Services;
using Microsoft.AspNetCore.Mvc;
using Obligatorio.CasosDeUsoCompartida.DTOs.Login;
using Obligatorio.CasosDeUsoCompartida.DTOs.Usuarios;
using Obligatorio.CasosDeUsoCompartida.InterfacesCU.Usuario;
using Obligatorio.Infraestructura.AccesoDatos.Exceptiones;
using Obligatorio.LogicaNegocio.Excepciones;

namespace Obligatorio.WebAPI.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class AuthController : Controller
    {
        private readonly IJwtGenerator _jwtGenerator;
        private readonly ILoginUsuario _login;

        public AuthController(IJwtGenerator jwtGenerator,
                              ILoginUsuario login)
        {
            _login = login;
            _jwtGenerator = jwtGenerator;
        }

        [HttpPost("login")]
        public IActionResult Login([FromBody] UsuarioLoginDTO usuarioLogin)
        {
            try
            {
                if (usuarioLogin == null)
                    throw new BadRequestException("Datos incompletos");

                var usuario = _login.Execute(usuarioLogin);

                if (usuario == null)
                    throw new UnauthorizedException("Credenciales inválidas");

                var token = _jwtGenerator.GenerateToken(usuario);

                var response = new LoginResponse
                {
                    Token = token,
                    Usuario = usuario
                };

                return Ok(response);
            }
            catch (LoginErrorException e)
            {
                return StatusCode(400, "Error al iniciar sesión, inténtalo nuevamente");
            }
            catch (UnauthorizedException e)
            {
                return StatusCode(e.statusCode(), e.Error());
            }
            catch (NotFoundException e)
            {
                return StatusCode(e.statusCode(), e.Error());
            }
            catch (BadRequestException e)
            {
                return StatusCode(e.statusCode(), e.Error());
            }
            catch (Exception)
            {
                Error error = new Error(500, "Ocurrió un error, inténtalo nuevamente");
                return StatusCode(500, error);
            }

        }
    }
}
