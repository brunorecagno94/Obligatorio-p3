using Obligatorio.LogicaNegocio.VO;

namespace Obligatorio.LogicaNegocio.Entidades
{
    public class Administrador : Empleado
    {
        public Administrador() { }
        public Administrador(int id,
                             Nombre nombre,
                             Apellido apellido,
                             Contrasena contrasena,
                             Telefono telefono,
                             Email email,
                             Cedula cedula,
                             string discriminator) : base(id, nombre, apellido, contrasena, telefono, email, cedula, discriminator)
        {
        }
    }
}
