using Obligatorio.CasosDeUsoCompartida.DTOs.Envio;
using Obligatorio.CasosDeUsoCompartida.DTOs.Usuarios;
using Obligatorio.LogicaNegocio.Entidades;

namespace Obligatorio.LogicaAplicacion.Mapper
{
    public static class EnvioMapper
    {
        // 1) Para todos pasa el mismo problema:
        // EnvioDTO tiene EmailCliente, y para construir
        // el EnvioComun ya precisa pasarse de EmailCliente
        // a ClienteId. Dónde se hace?

        // 2) Separamos FromDTO entre Común y Urgente?
        public static Envio FromDTOtoEnvioComun(EnvioDTO envioDto)
        {
            return new EnvioComun(0, envioDto.);
        }

        public static Envio FromDTOtoEnvioUrgente(EnvioDTO envioDto)
        {
            return new EnvioUrgente(0, envioDto.);
        }

        public static EnvioListadoDTO ToDTO(Envio envio)
        {
            return new EnvioListadoDTO();

        }

        public static IEnumerable<EnvioListadoDTO> ToListDto(IEnumerable<Envio> envios)
        {
            List<EnvioListadoDTO> listadoEnviosDTO = new List<EnvioListadoDTO>();

            foreach (var item in envios)
            {
                listadoEnviosDTO.Add(new UsuarioListadoDTO();
            }
            return listadoEnviosDTO;
        }
    }
}
