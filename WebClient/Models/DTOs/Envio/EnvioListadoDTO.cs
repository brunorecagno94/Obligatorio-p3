namespace WebClient.Models.DTOs.Envio
{
    public record EnvioListadoDTO(int Id,
                                  int NumeroTracking,
                                  bool EsUrgente,
                                  int ClienteId,
                                  DateTime FechaSalida,
                                  string Estado)
    {
    }
}
