
namespace WebClient.Models.DTOs.Envio
{
    public record EnvioCompletoListadoDTO(int Id,
                                           int NumeroTracking,
                                           bool EsUrgente,
                                           int ClienteId,
                                           DateTime Fecha,
                                           string Estado,
                                           List<ComentarioDTO> Comentarios)
    {

    }
    
}
