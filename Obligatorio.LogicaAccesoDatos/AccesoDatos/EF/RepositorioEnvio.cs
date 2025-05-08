

using Obligatorio.LogicaNegocio.Entidades;
using Obligatorio.LogicaNegocio.InterfacesRepositorios;

namespace Obligatorio.Infraestructura.AccesoDatos.EF
{
    public class RepositorioEnvio : IRepositorioEnvio
    {
        private ObligatorioContext _context;

        public void Add(Envio obj)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Envio> GetAll()
        {
            throw new NotImplementedException();
        }

        public Envio GetById(int id)
        {
            throw new NotImplementedException();
        }

        public void Update(int id, Envio usuario)
        {
            throw new NotImplementedException();
        }
    }
}
