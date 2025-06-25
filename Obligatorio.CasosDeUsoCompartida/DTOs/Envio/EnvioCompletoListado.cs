
namespace Obligatorio.CasosDeUsoCompartida.DTOs.Envio
{
    public record EnvioComentarioListadoDTO(int Id,
                                           int NumeroTracking,
                                           bool EsUrgente,
                                           int ClienteId,
                                           DateTime Fecha,
                                           string Estado,
                                           List<ComentarioDTO> Comentarios)
    {

    }
    
}
