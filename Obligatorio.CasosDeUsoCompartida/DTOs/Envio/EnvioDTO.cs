
namespace Obligatorio.CasosDeUsoCompartida.DTOs.Envio
{
    public record EnvioDTO(bool EsUrgente,
                           string EmailCliente,
                           string? CalleDireccion,
                           string? NumeroDireccion,
                           string? CodigoPostalDireccion,
                           int? IdAgencia,
                           float PesoPaquete
                           )
    {
    }
}
