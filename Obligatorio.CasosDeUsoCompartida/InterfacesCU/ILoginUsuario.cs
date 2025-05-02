
using Obligatorio.CasosDeUsoCompartida.DTOs.Usuarios;

namespace Obligatorio.CasosDeUsoCompartida.InterfacesCU
{
    public interface ILoginUsuario
    {
        UsuarioAutenticadoDTO Execute(UsuarioLoginDTO credenciales);
    }
}
