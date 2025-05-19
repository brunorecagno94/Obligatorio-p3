using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Obligatorio.LogicaNegocio.Entidades;

namespace Obligatorio.Infraestructura.AccesoDatos.EF.Config
{
    public class EnvioComunConfiguration : IEntityTypeConfiguration<EnvioComun>
    {
        public void Configure(EntityTypeBuilder<EnvioComun> builder)
        {
            builder
            .HasOne(e => e.Agencia)
            .WithMany()
            .HasForeignKey(e => e.AgenciaId)
            .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
