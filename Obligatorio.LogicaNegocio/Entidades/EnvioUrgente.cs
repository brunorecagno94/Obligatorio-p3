using Obligatorio.LogicaNegocio.VO;

namespace Obligatorio.LogicaNegocio.Entidades
{
    public class EnvioUrgente : Envio
    {
       
        public Direccion Direccion { get; set; }
        public EntregaEficiente EntregaEficiente { get; set; }

        public EnvioUrgente() { }
        public EnvioUrgente(Direccion direccion, EntregaEficiente entregaEficiente, Empleado empleado, Cliente cliente,
                       PesoPaquete pesoPaquete) : base(empleado, cliente, pesoPaquete)
        {
            Direccion = direccion;
            EntregaEficiente = entregaEficiente;
        }

    }
}
