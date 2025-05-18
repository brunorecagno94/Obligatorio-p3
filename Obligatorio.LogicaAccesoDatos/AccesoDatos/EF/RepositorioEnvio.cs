

using Microsoft.EntityFrameworkCore;
using Obligatorio.Infraestructura.AccesoDatos.Exceptiones;
using Obligatorio.LogicaNegocio.Entidades;
using Obligatorio.LogicaNegocio.InterfacesRepositorios;
using Obligatorio.LogicaNegocio.VO;

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
            var enviosComunes = _context.Envios.OfType<EnvioComun>()
                .Include(e => e.Agencia)
                .ThenInclude(a => a.Direccion)
                .Where(e => e.Estado.Value == "EnProceso")
                .ToList<Envio>();

            var enviosUrgentes = _context.Envios.OfType<EnvioUrgente>()
                .Where(e => e.Estado.Value == "EnProceso")
                .ToList<Envio>();

            return enviosComunes.Concat(enviosUrgentes).ToList();
        }

        public Envio GetById(int id)
        {
            var envio = _context.Envios
                        .FirstOrDefault(e => e.Id == id);

            if (envio is EnvioComun)
            {
                envio = _context.Envios
                    .OfType<EnvioComun>()
                    .Include(e => e.Agencia)
                        .ThenInclude(a => a.Direccion)
                    .FirstOrDefault(e => e.Id == id);
            }
            else if (envio is EnvioUrgente)
            {
                envio = _context.Envios
                    .OfType<EnvioUrgente>()
                    .Include(e => e.Direccion)
                    .FirstOrDefault(e => e.Id == id);
            }

            if (envio == null)
            {
                throw new NotFoundException("No se encontró el envío");
            }
            return envio;
        }

        public void Update(int id, Envio envio)
        {
            _context.Envios.Update(envio);
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

        public IEnumerable<Comentario> GetAllComentarios(int id)
        {
            Envio envio = GetById(id);
            return envio.ObtenerComentarios();
        }
    }
}
