using Obligatorio.Infraestructura.AccesoDatos.Exceptiones;
using Obligatorio.LogicaNegocio.Entidades;
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
            //if (GetByEmail(obj.Email.Value) != null)
            //{
            //    throw new ConflictException("Ya existe un usuario con ese email");
            //}

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
            //if (GetByEmail(obj.Email.Value) != null)
            //{
            //    throw new ConflictException("Ya existe un usuario con ese email");
            //}
            Usuario unU = GetById(id);
            unU.Update(obj);
            _context.Usuarios.Update(unU);
            _context.SaveChanges();
        }
    }
}

