using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Obligatorio.LogicaNegocio.Entidades;
using Obligatorio.LogicaNegocio.VO;


namespace Obligatorio.Infraestructura.AccesoDatos.EF.Config
{
    public class EnvioUrgenteConfiguration : IEntityTypeConfiguration<EnvioUrgente>
    {
        public void Configure(EntityTypeBuilder<EnvioUrgente> builder)
        {
            builder.OwnsOne(d => d.Direccion, direccion =>
            {
                direccion.Property(p => p.Calle).HasColumnName("Calle");
                direccion.Property(p => p.Numero).HasColumnName("Numero");
                direccion.Property(p => p.CodigoPostal).HasColumnName("CodigoPostal");
            });

            builder.OwnsOne(d => d.EntregaEficiente, entregaEficiente =>
            {
                entregaEficiente.Property(p => p.Value).HasColumnName("EntregaEficiente");
            });
        }
    }
}
