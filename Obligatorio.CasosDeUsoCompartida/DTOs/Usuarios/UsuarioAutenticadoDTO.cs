namespace Obligatorio.CasosDeUsoCompartida.DTOs.Usuarios
{
    public record UsuarioAutenticadoDTO(int Id,
                                        string Email,
                                        string Nombre,
                                        string Rol)
    {
    }
}
