using Obligatorio.CasosDeUsoCompartida.DTOs.Usuarios;

namespace Obligatorio.CasosDeUsoCompartida.InterfacesCU.Usuario
{
    public interface ILoginUsuario
    {
        UsuarioAutenticadoDTO Execute(UsuarioLoginDTO credenciales);
    }
}
