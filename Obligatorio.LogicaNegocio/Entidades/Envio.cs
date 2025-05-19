using Obligatorio.LogicaNegocio.InterfacesDominio;
using Obligatorio.LogicaNegocio.VO;

namespace Obligatorio.LogicaNegocio.Entidades
{
    public class Envio : IEntity, IEquatable<Envio>
    {
        public int Id { get; set; }
        public Empleado Empleado { get; set; }
        public int EmpleadoId { get; set; }
        public Cliente Cliente { get; set; }
        public int ClienteId { get; set; }
        public PesoPaquete PesoPaquete { get; set; }
        public NumeroTracking NumeroTracking { get; set; }
        public List<Comentario> ListaComentario { get; set; }
        public DateTime FechaSalida { get; set; }
        public DateTime FechaLlegada { get; set; }
        public Estado Estado { get; set; } = new Estado("EN_PROCESO");
        public string Discriminator { get; set; }

        public Envio()
        {
            Estado = new Estado("EN_PROCESO");
        }
        public Envio(int id, int empleadoId, int clienteId, PesoPaquete pesoPaquete, string discriminator)
        {
            Id = id;
            EmpleadoId = empleadoId;
            ClienteId = clienteId;
            PesoPaquete = pesoPaquete;
            NumeroTracking = new NumeroTracking();
            FechaSalida = DateTime.Now;
            Estado = new Estado("EN_PROCESO");
            Discriminator = discriminator;
        }

        public Envio(int id, int empleadoId, int clienteId, PesoPaquete pesoPaquete, string discriminator, DateTime fecha, Estado estado)
        {
            Id = id;
            EmpleadoId = empleadoId;
            ClienteId = clienteId;
            PesoPaquete = pesoPaquete;
            NumeroTracking = new NumeroTracking();
            FechaSalida = fecha;
            Estado = estado;
            Discriminator = discriminator;
        }

        public bool Equals(Envio? obj)
        {
            return obj != null && Id.Equals(obj.Id);
        }

        public void AgregarComentario(string textoComentario, int empleadoId, int envioId)
        {

            if (string.IsNullOrWhiteSpace(textoComentario))
                throw new ArgumentException("El comentario no puede estar vacío");

            Comentario nuevoComentario = new Comentario(textoComentario, empleadoId, envioId);

            ListaComentario.Add(nuevoComentario);
        }

        public IEnumerable<Comentario> ObtenerComentarios()
        {
            return ListaComentario;
        }

        public virtual void Finalizar(Envio obj)
        {
            Estado = new Estado("FINALIZADO");
            FechaLlegada = DateTime.Now;
        }
    }
}
