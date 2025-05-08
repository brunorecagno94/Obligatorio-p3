using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Obligatorio.LogicaNegocio.Entidades;

namespace Obligatorio.Infraestructura.AccesoDatos.EF.Config
{
    public class AgenciaConfiguration : IEntityTypeConfiguration<Agencia>
    {
        public void Configure(EntityTypeBuilder<Agencia> builder)
        {
            builder.OwnsOne(e => e.Nombre, nombre =>
            {
                nombre.Property(p => p.Value).HasColumnName("Nombre");
            });

            builder.OwnsOne(e => e.Direccion, direccion=>
            {
                direccion.Property(p => p.Calle).HasColumnName("Calle");
                direccion.Property(p => p.Numero).HasColumnName("Numero");
                direccion.Property(p => p.CodigoPostal).HasColumnName("CodigoPostal");
            });
        }
    }
}
