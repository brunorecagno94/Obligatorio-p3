namespace WebClient.Models.DTOs.LogsCrud
{
    public record LogCrudDTO(int Id,
                             string AccionRealizada,
                             DateTime FechaOperacion,
                             int UsuarioId)
    {
    }
}
