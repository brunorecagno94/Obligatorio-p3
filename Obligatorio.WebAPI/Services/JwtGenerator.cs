using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Libreria.WebApi.Services;
using Microsoft.IdentityModel.Tokens;
using Obligatorio.CasosDeUsoCompartida.DTOs.Usuarios;

namespace Libreria.WepApi.Services
{
    public class JwtGenerator : IJwtGenerator
    {
        private readonly IConfiguration _config;

        public JwtGenerator(IConfiguration config)
        {
            _config = config;
        }

        public string GenerateToken(UsuarioAutenticadoDTO usuario)
        {
            var key = Encoding.UTF8.GetBytes(_config["Jwt:Key"]);
            var issuer = _config["Jwt:Issuer"];
            var audience = _config["Jwt:Audience"];

            var claims = new[]
            {
                new Claim(JwtRegisteredClaimNames.Email, usuario.Email),
                new Claim(ClaimTypes.Role, usuario.Rol switch
                {
                    "Administrador" => "Admin",
                    "Funcionario" => "Funcionario",
                    "Cliente" => "Cliente",
                    _ => ""
                })
            };

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(claims),
                Expires = DateTime.UtcNow.AddMinutes(60),
                //Issuer = issuer,
                //Audience = audience,
                SigningCredentials = new SigningCredentials(
                    new SymmetricSecurityKey(key),
                    SecurityAlgorithms.HmacSha256Signature)
            };

            var tokenHandler = new JwtSecurityTokenHandler();
            var token = tokenHandler.CreateToken(tokenDescriptor);

            return tokenHandler.WriteToken(token);
        }
    }
}
