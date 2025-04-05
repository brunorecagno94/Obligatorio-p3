using Obligatorio.LogicaNegocio.VO;

namespace Obligatorio.LogicaNegocio.Entidades
{
    public class Urgente : Envio
    {
       
        public Direccion Direccion { get; set; }
        public EntregaEficiente EntregaEficiente { get; set; }

        public Urgente(Direccion direccion, EntregaEficiente entregaEficiente, Empleado empleado, Cliente cliente,
                       PesoPaquete pesoPaquete, NumeroTracking numeroTracking, List<Comentario> listaComentario) : base(empleado, cliente, pesoPaquete, numeroTracking, listaComentario)
        {
            Direccion = direccion;
            EntregaEficiente = entregaEficiente;
        }

    }
}
