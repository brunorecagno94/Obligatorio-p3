using Obligatorio.CasosDeUsoCompartida.DTOs.Usuarios;

namespace Obligatorio.CasosDeUsoCompartida.DTOs.Login
{
    public class LoginResponse
    {
        public string Token { get; set; }
        public UsuarioAutenticadoDTO Usuario { get; set; }
    }
}
