
using Obligatorio.LogicaNegocio.VO;

namespace Obligatorio.LogicaNegocio.Entidades
{
    public class EnvioComun : Envio
    {
        public Agencia DireccionEnvio { get; set; }
        public int DireccionEnvioId { get; set; }

        public EnvioComun() { }
        public EnvioComun(int direccionEnvioId,
                       int empleadoId,
                       int clienteId,
                       PesoPaquete pesoPaquete) : base(empleadoId, clienteId, pesoPaquete)
        {
            DireccionEnvioId = direccionEnvioId;
        }
    }
}
