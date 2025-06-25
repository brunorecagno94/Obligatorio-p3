using WebClient.Models.DTOs.Usuarios;

namespace Obligatorio.CasosDeUsoCompartida.DTOs.Login
{
    public record LoginResponse
    {
        public string Token { get; init; }
        public UsuarioAutenticadoDTO Usuario { get; init; }
    }
}
