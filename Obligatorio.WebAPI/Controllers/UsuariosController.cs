using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Obligatorio.CasosDeUsoCompartida.DTOs.Usuarios;
using Obligatorio.CasosDeUsoCompartida.InterfacesCU;
using Obligatorio.Infraestructura.AccesoDatos.Exceptiones;
using Obligatorio.LogicaNegocio.Excepciones;
using System.Security.Claims;

namespace Obligatorio.WebAPI.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class UsuariosController : ControllerBase
    {
        ICambiarContrasenaUsuario _cambiarContrasena;
        IGetById<UsuarioListadoDTO> _getById;

        public UsuariosController(ICambiarContrasenaUsuario cambiarContrasena, IGetById<UsuarioListadoDTO> getById)
        {
            _cambiarContrasena = cambiarContrasena;
            _getById = getById;
        }

        [Authorize]
        [HttpGet("detalles")]
        public IActionResult GetUsuario() 
        {
            try
            {
                if (!int.TryParse(User.FindFirstValue(ClaimTypes.NameIdentifier), out int idUsuario))
                {
                    return Unauthorized("Usuario no autenticado");
                }

                var usuario = _getById.Execute(idUsuario);
                return Ok(usuario);
            }
            catch (NotFoundException e)
            {
                return StatusCode(e.statusCode(), e.Error());
            }
            catch (Exception)
            {
                return StatusCode(500, new { error = "Error interno del servidor." });
            }
        }

        [Authorize]
        [HttpPut("contrasena")]
        public IActionResult CambiarContrasena([FromBody] CambiarContrasenaDTO dto)
        {
            try
            {
                if (!int.TryParse(User.FindFirstValue(ClaimTypes.NameIdentifier), out int idUsuario))
                {
                    return Unauthorized("Usuario no autenticado");
                }

                _cambiarContrasena.Execute(idUsuario, dto);

                return Ok(dto); 
            } catch (ContrasenaException e)
            {
               return StatusCode(400, e.Message);
            }
            catch (BadRequestException e)
            {
                return StatusCode(e.statusCode(), e.Error());
            }
            catch (NotFoundException e)
            {
                return StatusCode(e.statusCode(), e.Error());
            }
            catch (Exception)
            {
                return StatusCode(500, "Ocurrió un error");
            }
        }

    }
}
