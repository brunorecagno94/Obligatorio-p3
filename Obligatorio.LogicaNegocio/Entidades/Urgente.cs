using Obligatorio.LogicaNegocio.VO;

namespace Obligatorio.LogicaNegocio.Entidades
{
    public class Urgente : Envio
    {
       
        public Direccion Direccion { get; set; }
        public EntregaEficiente EntregaEficiente { get; set; }

        //TODO: Actualizar empleado, cliente y comentarios
        public Urgente(Direccion direccion, EntregaEficiente entregaEficiente, string empleado, string cliente,
                       PesoPaquete pesoPaquete, NumeroTracking numeroTracking, List<string> listaComentario) : base(empleado, cliente, pesoPaquete, numeroTracking, listaComentario)
        {
            Direccion = direccion;
            EntregaEficiente = entregaEficiente;
        }

    }
}
