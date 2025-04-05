using Obligatorio.LogicaNegocio.Entidades;
using Obligatorio.LogicaNegocio.InterfacesRepositorios;

namespace Obligatorio.LogicaAccesoDatos.Listas
{
    public class RepositorioAgencia : IRepositorioAgencia
    {
        private List<Agencia> _agencias;

        public IEnumerable<Agencia> GetAll()
        {
            return _agencias;
        }
    }
}
