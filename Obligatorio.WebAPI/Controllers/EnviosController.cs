using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using Obligatorio.CasosDeUsoCompartida.DTOs.Envio;
using Obligatorio.CasosDeUsoCompartida.InterfacesCU;
using Obligatorio.CasosDeUsoCompartida.InterfacesCU.Envio;
using Obligatorio.Infraestructura.AccesoDatos.Exceptiones;
using System.Security.Claims;

namespace Obligatorio.WebAPI.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class EnviosController : ControllerBase
    {
        IGetAll<EnvioListadoDTO> _getAll;
        IGetAllById<EnvioCompletoListado> _getAllById;
        IGetByNumeroTracking<EnvioCompletoListado> _getByNumeroTrackingEnvio;
        IBuscarEnviosPorComentario<EnvioCompletoListado> _buscarEnviosPorComentario;
        IFiltrarPorFechaYEstado<EnvioListadoDTO> _filtrarPorFechaYEstado;

        public EnviosController(
            IGetAll<EnvioListadoDTO> getAll,
            IGetAllById<EnvioCompletoListado> getAllById,
            IGetByNumeroTracking<EnvioCompletoListado> getByNumeroTrackingEnvio,
            IBuscarEnviosPorComentario<EnvioCompletoListado> buscarEnviosPorComentario,
            IFiltrarPorFechaYEstado<EnvioListadoDTO> filtrarPorFechaYEstado)
        {
            _getAll = getAll;
            _getAllById = getAllById;
            _getByNumeroTrackingEnvio = getByNumeroTrackingEnvio;
            _buscarEnviosPorComentario = buscarEnviosPorComentario;
            _filtrarPorFechaYEstado = filtrarPorFechaYEstado;
        }
        [HttpGet]
        public IActionResult GetAll()
        {
            try
            {
                return Ok(_getAll.Execute());
            }
            catch (InfraestructuraException e)
            {
                return StatusCode(e.statusCode(), e.Error());
            }
        }

        [HttpGet("{numeroTracking}")]
        public IActionResult GetByNumeroTracking(string numeroTracking)
        {
            try
            {
                int numeroTrackingInt;
                int.TryParse(numeroTracking, out numeroTrackingInt);
                if (numeroTrackingInt <= 0)
                {
                    throw new BadRequestException("Ingrese un número mayor a 0");
                }
                return Ok(_getByNumeroTrackingEnvio.Execute(numeroTrackingInt));
            }
            catch (NotFoundException e)
            {
                return StatusCode(e.statusCode(), e.Error());
            }
            catch (InfraestructuraException e)
            {
                return StatusCode(e.statusCode(), e.Error());
            }
            catch (Exception)
            {
                return StatusCode(500, "Ocurrió un error inesperado, intente nuevamente más tarde");
            }
        }

        [HttpGet("mis-envios")]
        public IActionResult GetByUsuario()
        {
            try
            {
                if (!int.TryParse(User.FindFirstValue(ClaimTypes.NameIdentifier), out int idCliente))
                    return Unauthorized("Usuario no autenticado");

                var rol = User.FindFirstValue(ClaimTypes.Role);
                if (rol != "Cliente")
                {
                    throw new UnauthorizedException("No tienes permisos para ver los envíos.");
                }

                var envios = _getAllById.Execute(idCliente);
                if (envios.Count() == 0)
                {
                    throw new NotFoundException("No se encontraron envíos para el usuario especificado");
                }
                return Ok(envios);
            }
            catch (InfraestructuraException e)
            {
                return StatusCode(e.statusCode(), e.Error());
            }
            catch (Exception)
            {
                return StatusCode(500, "Ocurrió un error inesperado, intente nuevamente más tarde");
            }
        }

        [HttpPost("mis-envios/busquedaComentario")]
        public IActionResult GetMisEnviosPorComentario([FromBody] string palabraClave)
        {
            try
            {
                if (!int.TryParse(User.FindFirstValue(ClaimTypes.NameIdentifier), out int idCliente))
                    return Unauthorized("Usuario no autenticado");

                var rol = User.FindFirstValue(ClaimTypes.Role);
                if (rol != "Cliente")
                {
                    throw new UnauthorizedException("No tienes permisos para ver los envíos.");
                }

                var envios = _buscarEnviosPorComentario.Execute(idCliente, palabraClave);

                return Ok(envios);
            }
            catch (InfraestructuraException e)
            {
                return StatusCode(e.statusCode(), e.Error());
            }
            catch (Exception)
            {
                return StatusCode(500, "Ocurrió un error, intente nuevamente más tarde");
            }
        }

        [Authorize]
        [HttpGet("buscar-fecha/{fecha1}/{fecha2}/{estado}")]
        public IActionResult FiltrarPorFechaYEstado(string fecha1, string fecha2, string? estado)
        {

            if (!int.TryParse(User.FindFirstValue(ClaimTypes.NameIdentifier), out int idCliente))
                return Unauthorized("Usuario no autenticado");

            if (fecha1.IsNullOrEmpty() || fecha2.IsNullOrEmpty())
            {
                try
                {
                    IEnumerable<EnvioListadoDTO> enviosDTO = _getAll.Execute();
                    return Ok(enviosDTO);
                }
                catch (Exception)
                {
                    return StatusCode(500, "Error al cargar envios");
                }
            }

            if (!DateTime.TryParse(fecha1, out DateTime fechaInicio) || !DateTime.TryParse(fecha2, out DateTime fechaFin))
            {
                return StatusCode(400, "Las fechas proporcionadas no son válidas.");
            }

            if (fechaInicio > fechaFin)
            {
                return StatusCode(400, "La fecha de inicio no puede ser posterior a la fecha de fin.");
            }
            try
            {
                var resultado = _filtrarPorFechaYEstado.Execute(idCliente, fechaInicio, fechaFin, estado);
                if (resultado == null)
                {
                    throw new NotFoundException("No se encontraron envíos en el rango de fechas especificado.");
                }
                return Ok(resultado);
            }
            catch (Exception)
            {
                return StatusCode(500, "Error al cargar envíos");
            }
        }

    }
}
