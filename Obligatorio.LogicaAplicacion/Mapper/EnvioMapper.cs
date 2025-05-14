using Obligatorio.CasosDeUsoCompartida.DTOs.Envio;
using Obligatorio.CasosDeUsoCompartida.DTOs.Usuarios;
using Obligatorio.LogicaNegocio.Entidades;
using Obligatorio.LogicaNegocio.VO;

namespace Obligatorio.LogicaAplicacion.Mapper
{
    public static class EnvioMapper
    {
        public static Envio FromDTOtoEnvioComun(EnvioDTO envioDto)
        {
            if (!envioDto.IdAgencia.HasValue)
                throw new InvalidOperationException("EmpleadoId no puede ser null");

            return new EnvioComun(envioDto.IdAgencia.Value,
                                  envioDto.EmpleadoId,
                                  envioDto.ClienteId,
                                  new PesoPaquete(envioDto.PesoPaquete));
        }

        public static Envio FromDTOtoEnvioUrgente(EnvioDTO envioDto)
        {
            return new EnvioUrgente(new Direccion(envioDto.CalleDireccion, envioDto.NumeroDireccion, envioDto.CodigoPostalDireccion),
                                    envioDto.EmpleadoId,
                                    envioDto.ClienteId,
                                    new PesoPaquete(envioDto.PesoPaquete));
        }

        public static EnvioListadoDTO ToDTO(Envio envio)
        {
            bool esUrgente = envio is EnvioUrgente;

            return new EnvioListadoDTO(envio.NumeroTracking.Value,
                                       esUrgente,
                                       envio.ClienteId,
                                       envio.FechaSalida,
                                       envio.Estado.Value);

        }

        public static IEnumerable<EnvioListadoDTO> ToListDto(IEnumerable<Envio> envios)
        {
            List<EnvioListadoDTO> listadoEnviosDTO = new List<EnvioListadoDTO>();

            foreach (var item in envios)
            {
                bool esUrgente = item is EnvioUrgente;

                listadoEnviosDTO.Add(new EnvioListadoDTO(item.NumeroTracking.Value,
                                                         esUrgente,
                                                         item.ClienteId,
                                                         item.FechaSalida,
                                                         item.Estado.Value));
            }
            return listadoEnviosDTO;
        }
    }
}
