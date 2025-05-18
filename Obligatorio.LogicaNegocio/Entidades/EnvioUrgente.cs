using Obligatorio.LogicaNegocio.VO;

namespace Obligatorio.LogicaNegocio.Entidades
{
    public class EnvioUrgente : Envio
    {

        public Direccion Direccion { get; set; }
        public EntregaEficiente EntregaEficiente { get; set; }

        public EnvioUrgente() { }
        public EnvioUrgente(int id, Direccion direccion, int empleadoId, int clienteId,
                       PesoPaquete pesoPaquete, string discriminator) : base(id, empleadoId, clienteId, pesoPaquete, discriminator)
        {
            Direccion = direccion;
        }

    }
}
