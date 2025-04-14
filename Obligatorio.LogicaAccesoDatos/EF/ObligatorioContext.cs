using Obligatorio.LogicaNegocio.Entidades;
using Microsoft.EntityFrameworkCore;

namespace Obligatorio.Infraestructura.EF
{
    public class ObligatorioContext : DbContext
    {
        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<Empleado> Empleados { get; set; }
        public DbSet<Cliente> Clientes { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            optionsBuilder.UseSqlServer(@"
                Data Source=(localdb)\MSSQLLocalDB;
                Initial Catalog=Obligatorio;
                Integrated Security=True;");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            #region Usuario
            modelBuilder.Entity<Usuario>().OwnsOne(u => u.Nombre, nombre =>
            {
                nombre.Property(n => n.Value).HasColumnName("Nombre");
            });

            modelBuilder.Entity<Usuario>().OwnsOne(u => u.Apellido, apellido =>
            {
                apellido.Property(a => a.Value).HasColumnName("Apellido");
            });

            modelBuilder.Entity<Usuario>().OwnsOne(u => u.Contrasena, contrasena =>
            {
                contrasena.Property(c => c.Value).HasColumnName("Contrasena");
            });

            // TODO: Cambiar por OwnsMany
            modelBuilder.Entity<Usuario>().OwnsOne(u => u.Telefono, telefono =>
            {
                telefono.Property(t => t.Value).HasColumnName("Telefono");
            });

            modelBuilder.Entity<Usuario>().OwnsOne(u => u.Email, email =>
            {
                email.Property(e => e.Value).HasColumnName("Email");
            });

            modelBuilder.Entity<Usuario>().OwnsOne(u => u.Cedula, cedula =>
            {
                cedula.Property(c => c.Value).HasColumnName("Cedula");
            });
            #endregion

        }
    }
}
