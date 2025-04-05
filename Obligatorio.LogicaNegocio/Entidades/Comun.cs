
using Obligatorio.LogicaNegocio.VO;

namespace Obligatorio.LogicaNegocio.Entidades
{
    public class Comun: Envio
    {
        public Agencia DireccionEnvio { get; set; }

        //TODO: Actualizar empleado, cliente y comentarios
        public Comun(Agencia direccionEnvio,
                       string empleado,
                       string cliente,
                       PesoPaquete pesoPaquete,
                       NumeroTracking numeroTracking,
                       List<string> listaComentario) : base(empleado, cliente, pesoPaquete, numeroTracking, listaComentario)
        {
            DireccionEnvio = direccionEnvio;
        }
    }
}
