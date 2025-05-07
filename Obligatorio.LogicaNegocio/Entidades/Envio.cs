
using Obligatorio.LogicaNegocio.InterfacesDominio;
using Obligatorio.LogicaNegocio.VO;

namespace Obligatorio.LogicaNegocio.Entidades
{
    public abstract class Envio : IEntity, IEquatable<Envio>
    {
        public int Id { get; set; }
        public Empleado Empleado { get; set; }
        public Cliente Cliente { get; set; }
        public PesoPaquete PesoPaquete { get; set; }
        public NumeroTracking NumeroTracking { get; set; }
        public Comentario Comentario { get; set; }
        public DateTime FechaSalida { get; set; }
        public DateTime FechaLlegada { get; set; }
        public Estado Estado { get; set; }
        //public Estado Estado { get; set; } = Estado.EnProceso;


        public Envio(Empleado empleado, Cliente cliente, PesoPaquete pesoPaquete, NumeroTracking numeroTracking, Comentario comentario)
        {
            Empleado = empleado;
            Cliente = cliente;
            PesoPaquete = pesoPaquete;
            NumeroTracking = numeroTracking;
            Comentario = comentario;
            FechaSalida = DateTime.Now;
            //Estado = Estado.EnProceso;
        }

        public bool Equals(Envio? obj)
        {
            return obj != null && Id.Equals(obj.Id);
        }
    }
}
