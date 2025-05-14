using Obligatorio.LogicaNegocio.VO;

namespace Obligatorio.LogicaNegocio.Entidades
{
    public class EnvioUrgente : Envio
    {

        public Direccion Direccion { get; set; }
        public EntregaEficiente EntregaEficiente { get; set; }

        public EnvioUrgente() { }
        public EnvioUrgente(Direccion direccion, int empleadoId, int clienteId,
                       PesoPaquete pesoPaquete) : base(empleadoId, clienteId, pesoPaquete)
        {
            Direccion = direccion;
        }

    }
}
