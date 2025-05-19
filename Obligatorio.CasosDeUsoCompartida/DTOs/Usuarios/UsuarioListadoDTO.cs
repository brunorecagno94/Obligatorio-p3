namespace Obligatorio.CasosDeUsoCompartida.DTOs.Usuarios
{
    public record UsuarioListadoDTO(int Id,
                                    string Nombre,
                                    string Apellido,
                                    string Email,
                                    string Telefono,
                                    string Cedula)
    {
    }
}
