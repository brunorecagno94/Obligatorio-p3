namespace WebClient.Models.DTOs.Usuarios
{
    public record UsuarioDTO(string Nombre,
                             string Apellido,
                             string Contrasena,
                             string Telefono,
                             string Email,
                             string Cedula)
    {
    }
}
