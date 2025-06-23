using Obligatorio.LogicaNegocio.Excepciones;
using Obligatorio.LogicaNegocio.InterfacesDominio;
using Obligatorio.LogicaNegocio.VO;
namespace Obligatorio.LogicaNegocio.Entidades
{
    public class Usuario : IEntity, IEquatable<Usuario>
    {
        public int Id { get; set; }
        public Nombre Nombre { get; set; }
        public Apellido Apellido { get; set; }
        public Contrasena Contrasena { get; set; }
        public Telefono Telefono { get; set; }
        public Email Email { get; set; }
        public Cedula Cedula { get; set; }
        public bool Activo { get; set; } = true;
        public string Discriminator { get; set; }

        protected Usuario() { }
        public Usuario(int id,
                       Nombre nombre,
                       Apellido apellido,
                       Contrasena contrasena,
                       Telefono telefono,
                       Email email,
                       Cedula cedula,
                       string discriminator)
        {
            Id = id;
            Nombre = nombre;
            Apellido = apellido;
            Contrasena = contrasena;
            Telefono = telefono;
            Email = email;
            Cedula = cedula;
            Discriminator = discriminator;
            Validar();
        }
        public bool Equals(Usuario? other)
        {
            return other != null && Id.Equals(other.Id);
        }

        public void Update(Usuario obj)
        {
            Nombre = obj.Nombre;
            Apellido = obj.Apellido;
            Contrasena = obj.Contrasena;
            Telefono = obj.Telefono;
            Email = obj.Email;
            Cedula = obj.Cedula;
        }

        public void UpdateContrasena(string nuevaContrasena)
        {
            Contrasena = new Contrasena(nuevaContrasena);
        }

        public void BajaUsuario()
        {
            Activo = false;
        }

        public void Validar()
        {
            if (string.IsNullOrEmpty(Nombre.Value)) throw new NombreException("Nombre inválido");
            if (string.IsNullOrEmpty(Apellido.Value)) throw new ApellidoException("Apellido inválido");
            if (string.IsNullOrEmpty(Contrasena.Value)) throw new ContrasenaException("Contraseña inválida");
            if (string.IsNullOrEmpty(Telefono.Value)) throw new TelefonoException("Teléfono inválido");
            if (string.IsNullOrEmpty(Email.Value)) throw new EmailException("Email inválido");
            if (string.IsNullOrEmpty(Cedula.Value)) throw new CedulaException("Cédula inválida");
        }
    }
}
