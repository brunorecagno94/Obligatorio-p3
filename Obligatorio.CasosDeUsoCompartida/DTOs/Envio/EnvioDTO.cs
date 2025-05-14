
namespace Obligatorio.CasosDeUsoCompartida.DTOs.Envio
{
    public record EnvioDTO(bool EsUrgente,
                           int EmpleadoId,
                           int ClienteId,
                           float PesoPaquete,
                           string? CalleDireccion,
                           string? NumeroDireccion,
                           string? CodigoPostalDireccion,
                           int? IdAgencia)
    {
    }
}
