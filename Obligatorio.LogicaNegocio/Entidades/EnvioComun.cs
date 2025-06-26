using Obligatorio.LogicaNegocio.VO;

namespace Obligatorio.LogicaNegocio.Entidades
{
    public class EnvioComun : Envio
    {
        public Agencia Agencia { get; set; }
        public int AgenciaId { get; set; }

        protected EnvioComun() { }
        public EnvioComun(int id,
            int direccionEnvioId,
                       int empleadoId,
                       int clienteId,
                       PesoPaquete pesoPaquete,
                       string discriminator) : base(id, empleadoId, clienteId, pesoPaquete, discriminator)
        {
            AgenciaId = direccionEnvioId;
        }
        public EnvioComun(int id,
            int direccionEnvioId,
                       int empleadoId,
                       int clienteId,
                       PesoPaquete pesoPaquete,
                       string discriminator,
                       DateTime fecha, string estado) : base(id, empleadoId, clienteId, pesoPaquete, discriminator, fecha, estado)
        {
            AgenciaId = direccionEnvioId;
        }
    }
}
