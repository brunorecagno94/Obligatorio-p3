
using Obligatorio.CasosDeUsoCompartida.DTOs.Usuarios;
using Obligatorio.LogicaNegocio.Entidades;
using Obligatorio.LogicaNegocio.VO;

namespace Obligatorio.LogicaAplicacion.Mapper
{
    public static class UsuarioMapper
    {
        public static Usuario FromDTO(UsuarioDTO usuarioDTO)
        {
            return new Funcionario(0, 
                                   new Nombre(usuarioDTO.Nombre),
                                   new Apellido(usuarioDTO.Apellido),
                                   new Contrasena(usuarioDTO.Contrasena),
                                   new Telefono(usuarioDTO.Telefono),
                                   new Email(usuarioDTO.Email),
                                   new Cedula(usuarioDTO.Cedula));
                         
        }

        public static UsuarioListadoDTO ToDTO(Usuario usuario)
        {
            return new UsuarioListadoDTO(usuario.Id,
                                   usuario.Nombre.Value,
                                   usuario.Apellido.Value,
                                   usuario.Email.Value,
                                   usuario.Telefono.Value,
                                   usuario.Cedula.Value);

        }

        public static IEnumerable<UsuarioListadoDTO> ToListDto(IEnumerable<Usuario> usuarios)
        {
            List<UsuarioListadoDTO> listadoUsuariosDTO = new List<UsuarioListadoDTO>();
            
            foreach (var item in usuarios)
            {
                listadoUsuariosDTO.Add(new UsuarioListadoDTO(item.Id,
                                   item.Nombre.Value,
                                   item.Apellido.Value,
                                   item.Email.Value,
                                   item.Telefono.Value,
                                   item.Cedula.Value));
            }
            return listadoUsuariosDTO;
        }
    }
}
