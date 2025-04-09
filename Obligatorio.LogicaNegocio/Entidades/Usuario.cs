using Obligatorio.LogicaNegocio.InterfacesDominio;
using Obligatorio.LogicaNegocio.VO;
namespace Obligatorio.LogicaNegocio.Entidades
{
    public abstract class Usuario : IEntity, IEquatable<Usuario>
    {
        public int Id { get; set; }
        public Nombre Nombre { get; set; }
        public Apellido Apellido { get; set; }
        public Contrasena Contrasena { get; set; }
        public Telefono Telefono { get; set; }
        public Email Email { get; set; }
        public Cedula Cedula { get; set; }

        public Usuario(int id,
                       Nombre nombre,
                       Apellido apellido,
                       Contrasena contrasena,
                       Telefono telefono,
                       Email email,
                       Cedula cedula)
        {
            Id = id;
            Nombre = nombre;
            Apellido = apellido;
            Contrasena = contrasena;
            Telefono = telefono;
            Email = email;
            Cedula = cedula;
        }
        public bool Equals(Usuario? other)
        {
            return other != null && Id.Equals(other.Id);
        }
    }
}
