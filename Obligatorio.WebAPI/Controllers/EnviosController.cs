using Microsoft.AspNetCore.Mvc;
using Obligatorio.CasosDeUsoCompartida.DTOs.Envio;
using Obligatorio.CasosDeUsoCompartida.InterfacesCU;
using Obligatorio.CasosDeUsoCompartida.InterfacesCU.Envio;
using Obligatorio.Infraestructura.AccesoDatos.Exceptiones;

namespace Obligatorio.WebAPI.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class EnviosController : ControllerBase
    {
        IGetAll<EnvioListadoDTO> _getAll;
        IGetByNumeroTracking<EnvioListadoDTO> _getByNumeroTrackingEnvio;

        public EnviosController(
            IGetAll<EnvioListadoDTO> getAll,
            IGetByNumeroTracking<EnvioListadoDTO> getByNumeroTrackingEnvio)
        {
            _getAll = getAll;
            _getByNumeroTrackingEnvio = getByNumeroTrackingEnvio;
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
        }
    }
}
