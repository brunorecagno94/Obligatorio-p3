using Obligatorio.LogicaNegocio.VO;

namespace Obligatorio.WebApp.Models
{
    public class VMUsuario
    {
        public Nombre Nombre { get; set; }
        public Apellido Apellido { get; set; }
        public Contrasena Contrasena { get; set; }
        public Telefono Telefono { get; set; }
        public Email Email { get; set; }
        public Cedula Cedula { get; set; }
    }
}
