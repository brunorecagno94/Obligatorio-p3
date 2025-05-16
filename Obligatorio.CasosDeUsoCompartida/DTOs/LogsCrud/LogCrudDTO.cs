namespace Obligatorio.CasosDeUsoCompartida.DTOs.LogsCrud
{
    public record LogCrudDTO(int Id,
                             string AccionRealizada,
                             DateTime FechaOperacion,
                             int UsuarioId)
    { }
}
