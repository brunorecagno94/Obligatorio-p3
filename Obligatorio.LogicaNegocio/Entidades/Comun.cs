
using Obligatorio.LogicaNegocio.VO;

namespace Obligatorio.LogicaNegocio.Entidades
{
    public class Comun: Envio
    {
        public Agencia DireccionEnvio { get; set; }

        public Comun(Agencia direccionEnvio,
                       Empleado empleado,
                       Cliente cliente,
                       PesoPaquete pesoPaquete,
                       NumeroTracking numeroTracking,
                       List<Comentario> listaComentario) : base(empleado, cliente, pesoPaquete, numeroTracking, listaComentario)
        {
            DireccionEnvio = direccionEnvio;
        }
    }
}
