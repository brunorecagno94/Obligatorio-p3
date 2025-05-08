
using Obligatorio.LogicaNegocio.VO;

namespace Obligatorio.LogicaNegocio.Entidades
{
    public class EnvioComun: Envio
    {
        public Agencia DireccionEnvio { get; set; }
        public int DireccionEnvioId { get; set; }

        public EnvioComun() { }
        public EnvioComun(Agencia direccionEnvio,
                       Empleado empleado,
                       Cliente cliente,
                       PesoPaquete pesoPaquete) : base(empleado, cliente, pesoPaquete)
        {
            DireccionEnvio = direccionEnvio;
        }
    }
}
