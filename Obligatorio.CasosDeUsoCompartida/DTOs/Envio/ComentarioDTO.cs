namespace Obligatorio.CasosDeUsoCompartida.DTOs.Envio
{
    public record ComentarioDTO(string TextoComentario,
                               int Empleado,
                               int EnvioId,
                               DateTime FechaComentario)
    {
    }
}
