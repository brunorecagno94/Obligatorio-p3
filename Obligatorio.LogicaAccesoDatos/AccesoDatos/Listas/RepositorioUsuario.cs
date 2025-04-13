using Obligatorio.LogicaNegocio.Entidades;
using Obligatorio.LogicaNegocio.InterfacesRepositorios;

namespace Obligatorio.Infraestructura.AccesoDatos.Listas
{
    public class RepositorioUsuario : IRepositorioUsuario
    {
        private List<Usuario> _usuarios;

        // TODO: Agregar excepciones
        public void Add(Usuario usuario)
        {
            _usuarios.Add(usuario);
        }

        public IEnumerable<Usuario> GetAll()
        {
            return _usuarios;
        }

        public Usuario GetById(int id)
        {
            Usuario usuarioResult = null;
            foreach (var usuario in _usuarios)
            {
                if (usuario.Id == id)
                {
                    usuarioResult = usuario;
                }
            }
            return usuarioResult;
        }

        public void Remove(int id)
        {
            _usuarios.Remove(GetById(id));
        }

        public void Update(Usuario usuario)
        {
            Usuario usuarioEditar = GetById(usuario.Id);
            usuarioEditar.Nombre = usuario.Nombre;
            usuarioEditar.Apellido = usuario.Apellido;
            usuarioEditar.Contrasena = usuario.Contrasena;
            usuarioEditar.Telefono = usuario.Telefono;
            usuarioEditar.Email = usuario.Email;
            usuarioEditar.Cedula = usuario.Cedula;
        }
    }
}
