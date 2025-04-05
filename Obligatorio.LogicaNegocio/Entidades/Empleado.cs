using Obligatorio.LogicaNegocio.VO;

namespace Obligatorio.LogicaNegocio.Entidades
{
    public abstract class Empleado : Usuario
    {
        public Contrasena Contrasena { get; set; }
        public Empleado(int id,
                       Nombre nombre,
                       Apellido apellido,
                       Contrasena contrasena,
                       Telefono telefono,
                       Email email,
                       Cedula cedula) : base(id, nombre, apellido, telefono, email, cedula)
        {
        }
    }
}
