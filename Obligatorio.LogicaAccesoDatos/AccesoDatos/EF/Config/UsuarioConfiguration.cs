using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Obligatorio.LogicaNegocio.Entidades;

namespace Obligatorio.Infraestructura.AccesoDatos.EF.Config
{
    public class UsuarioConfiguration : IEntityTypeConfiguration<Usuario>
    {
        public void Configure(EntityTypeBuilder<Usuario> builder)
        {
            builder.OwnsOne(u => u.Nombre, nombre =>
            {
                nombre.Property(p => p.Value).HasColumnName("Nombre");
            });

            builder.OwnsOne(u => u.Apellido, apellido =>
            {
                apellido.Property(p => p.Value).HasColumnName("Apellido");
            });

            builder.OwnsOne(u => u.Contrasena, contrasena =>
            {
                contrasena.Property(p => p.Value).HasColumnName("Contrasena");
            });

            builder.OwnsOne(u => u.Telefono, telefono =>
            {
                telefono.Property(p => p.Value).HasColumnName("Telefono");
            });

            builder.OwnsOne(u => u.Email, email =>
            {
                email.Property(p => p.Value).HasColumnName("Email");
            });

            builder.OwnsOne(u => u.Cedula, cedula =>
            {
                cedula.Property(p => p.Value).HasColumnName("Cedula");
            });
        }
    }
}
