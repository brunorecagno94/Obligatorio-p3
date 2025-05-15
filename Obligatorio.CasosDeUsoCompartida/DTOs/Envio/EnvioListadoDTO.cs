

namespace Obligatorio.CasosDeUsoCompartida.DTOs.Envio
{
    public record EnvioListadoDTO(int NumeroTracking,
                                  bool EsUrgente,
                                  int ClienteId,
                                  DateTime FechaSalida,
                                  string Estado)
    {
    }
}
