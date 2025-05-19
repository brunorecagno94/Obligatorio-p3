using Obligatorio.Infraestructura.AccesoDatos.Exceptiones;
using Obligatorio.LogicaNegocio.Entidades;
using Obligatorio.LogicaNegocio.InterfacesRepositorios;

namespace Obligatorio.Infraestructura.AccesoDatos.EF
{
    public class RepositorioAgencia : IRepositorioAgencia
    {
        private ObligatorioContext _context;

        public RepositorioAgencia(ObligatorioContext context)
        {
            _context = context;
        }

        public void Add(Agencia obj)
        {
            if (obj == null)
            {
                throw new BadRequestException("Objeto vacío");
            }

            _context.Agencias.Add(obj);
            _context.SaveChanges();
        }

        public IEnumerable<Agencia> GetAll()
        {
            return _context.Agencias.ToList();
        }
    }
}
