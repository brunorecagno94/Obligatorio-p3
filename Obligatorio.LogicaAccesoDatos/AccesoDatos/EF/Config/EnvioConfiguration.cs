
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Obligatorio.LogicaNegocio.Entidades;

namespace Obligatorio.Infraestructura.AccesoDatos.EF.Config
{
    public class EnvioConfiguration: IEntityTypeConfiguration<Envio>
    {
        public void Configure(EntityTypeBuilder<Envio> builder)
        {
            builder.HasDiscriminator<string>("Discriminator")
                .HasValue<Envio>("Envio")
                .HasValue<EnvioComun>("EnvioComun")
                .HasValue<EnvioUrgente>("EnvioUrgente");

            builder
            .HasOne(e => e.Empleado)
            .WithMany()
            .HasForeignKey(e => e.EmpleadoId)
            .OnDelete(DeleteBehavior.Restrict);

            builder
                .HasOne(e => e.Cliente)
                .WithMany()
                .HasForeignKey(e => e.ClienteId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.OwnsOne(e => e.PesoPaquete, pesoPaquete =>
            {
                pesoPaquete.Property(p => p.Value).HasColumnName("PesoPaquete");
            });
            
            builder.OwnsOne(e => e.NumeroTracking, numeroTracking =>
            {
                numeroTracking.Property(p => p.Value).HasColumnName("NumeroTracking");
            });

            builder.OwnsMany(e => e.ListaComentario, listaComentario =>
            {
                listaComentario.Property(p => p.Fecha).HasColumnName("FechaComentario");
                listaComentario.Property(p => p.TextoComentario).HasColumnName("TextoComentario");
                listaComentario.Property(p => p.IdEmpleado).HasColumnName("IdEmpleado");
                listaComentario.Property(p => p.IdEnvio).HasColumnName("IdEnvio");
            });

            builder.OwnsOne(e => e.Estado, estado =>
            {
                estado.Property(p => p.Value).HasColumnName("Estado");
            });
        }
    }
}
