

namespace Obligatorio.CasosDeUsoCompartida.DTOs.Envio
{
    public record EnvioListadoDTO(int NumeroTracking,
                                  bool EsUrgente,
                                  string EmailCliente,
                                  DateTime FechaSalida,
                                  string Estado)
    {
    }
}
