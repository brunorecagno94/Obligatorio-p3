namespace Obligatorio.WebClient.Models.DTOs.Envio
{
    public record ComentarioDTO(string TextoComentario,
                               int Empleado,
                               int EnvioId,
                               DateTime FechaComentario)
    {
    }
}
