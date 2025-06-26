using Obligatorio.CasosDeUsoCompartida.DTOs.Envio;
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

            return new EnvioComun(envioDto.Id,
                                  envioDto.IdAgencia.Value,
                                  envioDto.EmpleadoId,
                                  envioDto.ClienteId,
                                  new PesoPaquete(envioDto.PesoPaquete),
                                  "EnvioComun");
        }

        public static Envio FromDTOtoEnvioUrgente(EnvioDTO envioDto)
        {
            return new EnvioUrgente(envioDto.Id,
                                    new Direccion(envioDto.CalleDireccion, envioDto.NumeroDireccion, envioDto.CodigoPostalDireccion),
                                    envioDto.EmpleadoId,
                                    envioDto.ClienteId,
                                    new PesoPaquete(envioDto.PesoPaquete),
                                    "EnvioUrgente");
        }

        public static EnvioListadoDTO ToDTO(Envio envio)
        {
            bool esUrgente = envio is EnvioUrgente;

            return new EnvioListadoDTO(envio.Id,
                                       envio.NumeroTracking.Value,
                                       esUrgente,
                                       envio.ClienteId,
                                       envio.FechaSalida,
                                       envio.Estado);

        }

        public static EnvioCompletoListado ToDTOCompleto(Envio envio)
        {
            bool esUrgente = envio is EnvioUrgente;

            var comentariosDTO = envio.ListaComentario
                .Select(c => new ComentarioDTO(c.TextoComentario, c.IdEmpleado, c.IdEnvio, c.Fecha))
                .ToList();

            return new EnvioCompletoListado(
                envio.Id,
                envio.NumeroTracking.Value,
                esUrgente,
                envio.ClienteId,
                envio.FechaSalida,
                envio.Estado,
                comentariosDTO
            );
        }

        public static IEnumerable<ComentarioDTO> ComentarioToDTO(IEnumerable<Comentario> comentarios)
        {
            return comentarios.Select(c =>
                new ComentarioDTO(
                    c.TextoComentario,
                    c.IdEmpleado,
                    c.IdEnvio,
                    c.Fecha
                )
            );
        }

        public static IEnumerable<EnvioListadoDTO> ToListDto(IEnumerable<Envio> envios)
        {
            List<EnvioListadoDTO> listadoEnviosDTO = new List<EnvioListadoDTO>();

            foreach (var item in envios)
            {
                bool esUrgente = item is EnvioUrgente;

                listadoEnviosDTO.Add(new EnvioListadoDTO(item.Id,
                                                         item.NumeroTracking.Value,
                                                         esUrgente,
                                                         item.ClienteId,
                                                         item.FechaSalida,
                                                         item.Estado));
            }
            return listadoEnviosDTO;
        }

        public static IEnumerable<EnvioCompletoListado> ToListDtoCompleto(IEnumerable<Envio> envios)
        {
            List<EnvioCompletoListado> listadoEnviosDTO = new List<EnvioCompletoListado>();

            foreach (var item in envios)
            {
                bool esUrgente = item is EnvioUrgente;

                var comentariosDTO = item.ListaComentario
                    .Select(c => new ComentarioDTO(c.TextoComentario, c.IdEmpleado, c.IdEnvio, c.Fecha))
                    .ToList();

                listadoEnviosDTO.Add(new EnvioCompletoListado(
                    item.Id,
                    item.NumeroTracking.Value,
                    esUrgente,
                    item.ClienteId,
                    item.FechaSalida,
                    item.Estado,
                    comentariosDTO
                ));
            }

            return listadoEnviosDTO;
        }

    }
}
