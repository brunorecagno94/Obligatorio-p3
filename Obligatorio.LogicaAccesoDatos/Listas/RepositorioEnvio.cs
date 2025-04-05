using Obligatorio.LogicaNegocio.InterfacesRepositorios;
using Obligatorio.LogicaNegocio.Entidades;
using Obligatorio.LogicaNegocio.Excepciones;

namespace Obligatorio.LogicaAccesoDatos.Listas
{
    public class RepositorioEnvio : IRepositorioEnvio
    {
        private List<Envio> _envios;

        // TODO: Agregar excepciones
        public void Add(Envio envio)
        {
            _envios.Add(envio);
        }

        public IEnumerable<Envio> GetAll()
        {
            return _envios;
        }
        public Envio GetById(int id)
        {
            Envio envioResult = null;

            foreach (var envio in _envios)
            {
                if (envio is Envio)
                {
                    if (envio.Id == id)
                    {
                        envioResult = envio;
                    }
                }
            }
            return envioResult;
        }
        public void Update(Envio envio) { 
        Envio envioUpdate = GetById(envio.Id);

        }
    }
}
