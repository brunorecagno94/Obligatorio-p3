
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
        public List<Comentario> ListaComentario { get; set; }
        public DateTime FechaSalida { get; set; }
        public DateTime FechaLlegada { get; set; }
        public Estado Estado { get; set; }
        //public Estado Estado { get; set; } = Estado.EnProceso;


        public Envio(Empleado empleado, Cliente cliente, PesoPaquete pesoPaquete, NumeroTracking numeroTracking, List<Comentario> listaComentario)
        {
            Empleado = empleado;
            Cliente = cliente;
            PesoPaquete = pesoPaquete;
            NumeroTracking = numeroTracking;
            ListaComentario = listaComentario;
            FechaSalida = DateTime.Now;
            //Estado = Estado.EnProceso;
        }

        public bool Equals(Envio? obj)
        {
            return obj != null && Id.Equals(obj.Id);
        }
    }
}
