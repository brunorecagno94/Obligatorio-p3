
namespace Obligatorio.CasosDeUsoCompartida.DTOs.Envio
{
    public record EnvioCompletoListado(int Id,
                                           int NumeroTracking,
                                           bool EsUrgente,
                                           int ClienteId,
                                           DateTime Fecha,
                                           string Estado,
                                           List<ComentarioDTO> Comentarios)
    {

    }
    
}
