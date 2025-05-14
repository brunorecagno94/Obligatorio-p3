
using Obligatorio.CasosDeUsoCompartida.DTOs.Agencias;
using Obligatorio.CasosDeUsoCompartida.DTOs.Envio;
using Obligatorio.LogicaNegocio.Entidades;

namespace Obligatorio.LogicaAplicacion.Mapper
{
    public class AgenciaMapper
    {
        public static IEnumerable<AgenciaListadaDTO> ToListDto(IEnumerable<Agencia> agencias)
        {
            List<AgenciaListadaDTO> listadoAgenciasDTO = new List<AgenciaListadaDTO>();

            foreach (var item in agencias)
            {
                bool esUrgente = item is EnvioUrgente;

                listadoAgenciasDTO.Add(new AgenciaListadaDTO(item.Id.ToString(),
                                                             item.Nombre.Value,
                                                             item.Direccion.Calle,
                                                             item.Direccion.Numero));
            }
            return listadoAgenciasDTO;
        }
    }
}
