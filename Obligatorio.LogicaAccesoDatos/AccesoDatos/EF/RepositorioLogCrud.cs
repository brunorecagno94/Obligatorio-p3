using Obligatorio.LogicaNegocio.Entidades;
using Obligatorio.LogicaNegocio.InterfacesRepositorios;

namespace Obligatorio.Infraestructura.AccesoDatos.EF
{
    public class RepositorioLogCrud : IRepositorioLogCrud
    {
        private ObligatorioContext _context;

        public RepositorioLogCrud(ObligatorioContext context)
        {
            _context = context;
        }

        public void Add(LogCrud obj)
        {
            if (obj == null)
            {
                throw new ArgumentNullException("Objeto vacío");
            }

            _context.LogCrud.Add(obj);
            _context.SaveChanges();
        }
    }
}
