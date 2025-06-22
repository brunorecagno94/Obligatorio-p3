using Obligatorio.CasosDeUsoCompartida.DTOs.Usuarios;

namespace Libreria.WebApi.Services
{
    public interface IJwtGenerator
    {
        string GenerateToken(UsuarioAutenticadoDTO usuario);
    }
}
