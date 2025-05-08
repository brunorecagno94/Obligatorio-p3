
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
        public Estado Estado { get; set; } = Estado.EnProceso;

        public Envio() { }
        public Envio(Empleado empleado, Cliente cliente, PesoPaquete pesoPaquete)
        {
            Empleado = empleado;
            Cliente = cliente;
            PesoPaquete = pesoPaquete;
            NumeroTracking = new NumeroTracking();
            FechaSalida = DateTime.Now;
            Estado = Estado.EnProceso;
        }

        public bool Equals(Envio? obj)
        {
            return obj != null && Id.Equals(obj.Id);
        }
    }
}
