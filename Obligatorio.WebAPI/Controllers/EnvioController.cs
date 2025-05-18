using Microsoft.AspNetCore.Mvc;
using Obligatorio.CasosDeUsoCompartida.DTOs.Envio;
using Obligatorio.CasosDeUsoCompartida.InterfacesCU.Envio;
using Obligatorio.Infraestructura.AccesoDatos.Exceptiones;

namespace Obligatorio.WebAPI.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class EnvioController : ControllerBase
    {
        IGetByNumeroTracking<EnvioListadoDTO> _getByNumeroTrackingEnvio;

        public EnvioController(IGetByNumeroTracking<EnvioListadoDTO> getByNumeroTrackingEnvio)
        {
            _getByNumeroTrackingEnvio = getByNumeroTrackingEnvio;
        }

        [HttpGet("{numeroTracking}")]
        public IActionResult GetByNumeroTracking(int numeroTracking)
        {
            try
            {
                return Ok(_getByNumeroTrackingEnvio.Execute(numeroTracking));
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
