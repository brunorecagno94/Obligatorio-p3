using Obligatorio.LogicaNegocio.VO;

namespace Obligatorio.LogicaNegocio.Entidades
{
    public class Cliente : Usuario
    {
        public Cliente(int id,
                       Nombre nombre,
                       Apellido apellido,
                       Telefono telefono,
                       Email email,
                       Cedula cedula) : base(id, nombre, apellido, telefono, email, cedula)
        {
        }
    }
}
