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
                .Where(e => e.Estado == "EN_PROCESO")
                .ToList<Envio>();

            var enviosUrgentes = _context.Envios.OfType<EnvioUrgente>()
                .Where(e => e.Estado == "EN_PROCESO")
                .Include(e => e.Direccion)
                .ToList<Envio>();

            return enviosComunes.Concat(enviosUrgentes).OrderByDescending(e => e.FechaSalida).ToList();
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

        public IEnumerable<Envio> GetAllById(int idUsuario)
        {
            var enviosComunes = _context.Envios.OfType<EnvioComun>()
                .Include(e => e.Agencia)
                    .ThenInclude(a => a.Direccion)
                .Include(e => e.ListaComentario)
                .Where(e => e.ClienteId == idUsuario)
                .ToList<Envio>();

            var enviosUrgentes = _context.Envios.OfType<EnvioUrgente>()
                .Include(e => e.Direccion)
                .Include(e => e.ListaComentario)
                .Where(e => e.ClienteId == idUsuario)
                .ToList<Envio>();

            var envios = enviosComunes
                .Concat(enviosUrgentes)
                .OrderByDescending(e => e.FechaSalida)
                .ToList();

            if (!envios.Any())
            {
                throw new NotFoundException("No se encontraron envíos para el usuario especificado");
            }

            return envios;
        }


        public void Update(int id, Envio envio)
        {
            _context.Envios.Update(envio);
            _context.SaveChanges();
        }

        public Envio GetByNumeroTracking(int numeroTracking)
        {
            var envioComun = _context.Envios.OfType<EnvioComun>()
                .Include(e => e.ListaComentario)
                .Include(e => e.Agencia)
                    .ThenInclude(a => a.Direccion)
                .FirstOrDefault(e => e.NumeroTracking.Value == numeroTracking);

            if (envioComun != null)
                return envioComun;

            var envioUrgente = _context.Envios.OfType<EnvioUrgente>()
                .Include(e => e.ListaComentario)
                .Include(e => e.Direccion)
                .FirstOrDefault(e => e.NumeroTracking.Value == numeroTracking);

            if (envioUrgente != null)
                return envioUrgente;

            throw new NotFoundException("No se encontró el envío");
        }

        public IEnumerable<Comentario> GetAllComentarios(int id)
        {
            Envio envio = GetById(id);
            return envio.ObtenerComentarios();
        }

        public void Finalizar(int id)
        {
            Envio envio = GetById(id);
            envio.Finalizar(envio);
            _context.Envios.Update(envio);
            _context.SaveChanges();
        }

        public IEnumerable<Envio> BuscarPorComentario(int idCliente, string palabraClave)
        {
            if (string.IsNullOrWhiteSpace(palabraClave))
                throw new BadRequestException("La palabra clave no puede estar vacía");

            if (int.TryParse(palabraClave, out _))
                throw new BadRequestException("La palabra clave no puede ser numérica");

            palabraClave = palabraClave.ToLower();

            var enviosComunes = _context.Envios.OfType<EnvioComun>()
                .Include(e => e.ListaComentario)
                .Include(e => e.Agencia)
                    .ThenInclude(a => a.Direccion)
                .Where(e => e.ClienteId == idCliente &&
                            e.ListaComentario.Any(c => c.TextoComentario.ToLower().Contains(palabraClave)))
                .ToList<Envio>();

            var enviosUrgentes = _context.Envios.OfType<EnvioUrgente>()
                .Include(e => e.ListaComentario)
                .Include(e => e.Direccion)
                .Where(e => e.ClienteId == idCliente &&
                            e.ListaComentario.Any(c => c.TextoComentario.ToLower().Contains(palabraClave)))
                .ToList<Envio>();

            var envios = enviosComunes
                .Concat(enviosUrgentes)
                .OrderByDescending(e => e.FechaSalida)
                .ToList();

            if (!envios.Any())
            {
                throw new NotFoundException("No se encontraron envíos con esa palabra en los comentarios");
            }

            return envios;
        }

        public IEnumerable<Envio> FiltrarPorFechaYEstado(DateTime fechaInicio, DateTime fechaFin, string? estado)
        {
            if (fechaInicio == null || fechaFin == null)
            {
                throw new BadRequestException("Las fechas no pueden ser nulas");
            }
            if (fechaInicio > fechaFin)
            {
                throw new BadRequestException("La fecha de inicio no puede ser posterior a la fecha de fin");
            }

            var enviosResult = _context.Envios.AsQueryable()
                 .Where(e => e.FechaSalida >= fechaInicio && e.FechaSalida <= fechaFin);

            if (!string.IsNullOrEmpty(estado))
            {
                enviosResult = enviosResult.Where(e => e.Estado == estado);
            }

            if (!enviosResult.Any())
            {
                throw new NotFoundException("No se encontraron envíos en el rango seleccionado");
            }

            return enviosResult.OrderBy(e => e.NumeroTracking.Value).ToList();
        }
    }
}
