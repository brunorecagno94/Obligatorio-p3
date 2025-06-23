using Obligatorio.Infraestructura.AccesoDatos.Exceptiones;
using Obligatorio.LogicaNegocio.Entidades;
using Obligatorio.LogicaNegocio.Excepciones;
using Obligatorio.LogicaNegocio.InterfacesRepositorios;

namespace Obligatorio.Infraestructura.AccesoDatos.EF
{
    public class RepositorioUsuario : IRepositorioUsuario
    {
        private ObligatorioContext _context;

        public RepositorioUsuario(ObligatorioContext context)
        {
            _context = context;
        }

        public void Add(Usuario obj)
        {
            if (obj == null)
            {
                throw new BadRequestException("Objeto vacío");
            }
            if (_context.Usuarios.Any(u => u.Email.Value == obj.Email.Value))
            {
                throw new EmailRepetidoException("Ese email ya está en uso");
            }
            _context.Usuarios.Add(obj);
            _context.SaveChanges();
        }

        public IEnumerable<Usuario> GetAll()
        {
            return _context.Usuarios.Where(u => u.Activo).ToList();
        }

        public Usuario GetById(int id)
        {
            Usuario unU = _context.Usuarios.FirstOrDefault(usuario => usuario.Id == id);

            if (unU == null)
            {
                throw new NotFoundException("No se encontró el usuario");
            }
            return unU;
        }

        public Usuario GetByEmail(string email)
        {
            Usuario unU = _context.Usuarios.FirstOrDefault(usuario => usuario.Email.Value == email);

            if (unU == null)
            {
                throw new NotFoundException("No se encontró el usuario");
            }
            return unU;
        }

        public void Remove(int id)
        {
            Usuario unU = GetById(id);
            unU.BajaUsuario();
            _context.SaveChanges();
        }

        public void Update(int id, Usuario obj)
        {
            if (obj == null)
            {
                throw new BadRequestException("Objeto vacío");
            }

            Usuario unU = GetById(id);

            if (_context.Usuarios.Any(u => u.Email.Value == obj.Email.Value && u.Id != id))
            {
                throw new EmailRepetidoException("Ese email ya está en uso");
            }
            unU.Update(obj);
            _context.Usuarios.Update(unU);
            _context.SaveChanges();
        }

        public void UpdateContrasena(int id, string contrasenaActual, string contrasenaNueva)
        {
            if (contrasenaNueva == null || contrasenaActual == null)
            {
                throw new BadRequestException("Objeto vacío");
            }

            Usuario unU = GetById(id);

            if (unU.Contrasena.Value != contrasenaActual)
            {
                throw new ContrasenaException("La contraseña actual no coincide");
            }

            unU.UpdateContrasena(contrasenaNueva);
            _context.Usuarios.Update(unU);
            _context.SaveChanges();
        }
    }
}

