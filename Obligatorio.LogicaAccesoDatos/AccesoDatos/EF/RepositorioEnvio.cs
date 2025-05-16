

using Obligatorio.Infraestructura.AccesoDatos.Exceptiones;
using Obligatorio.LogicaNegocio.Entidades;
using Obligatorio.LogicaNegocio.InterfacesRepositorios;

namespace Obligatorio.Infraestructura.AccesoDatos.EF
{
    public class RepositorioEnvio : IRepositorioEnvio
    {
        private ObligatorioContext _context;

        public RepositorioEnvio(ObligatorioContext context)
        {
            _context = context;
        }

        public void Add(Envio obj)
        {
            if (obj == null)
            {
                throw new BadRequestException("Objeto vacío");
            }

            _context.Envios.Add(obj);
            _context.SaveChanges();
        }

        public IEnumerable<Envio> GetAll()
        {
            return _context.Envios.ToList();
        }

        public Envio GetById(int id)
        {
            Envio unE = _context.Envios.FirstOrDefault(envio => envio.Id == id);

            if (unE == null)
            {
                throw new NotFoundException("No se encontró el envío");
            }
            return unE;
        }

        public void Update(int id, Envio envio)
        {
            Envio unE = GetById(id);
            unE.Update(envio);
            _context.Envios.Update(unE);
            _context.SaveChanges();
        }

        public Envio GetByNumeroTracking(int numeroTracking)
        {
            Envio envioEncontrado = _context.Envios.FirstOrDefault(envio => envio.NumeroTracking.Value == numeroTracking);
            if (envioEncontrado == null)
            {
                throw new NotFoundException("No se encontró el envío");
            }

            return envioEncontrado;
        }
    }
}
