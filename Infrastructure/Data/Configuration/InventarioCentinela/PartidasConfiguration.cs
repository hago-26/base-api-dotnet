using Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Data.Configuration;

public class PartidasConfiguration : IEntityTypeConfiguration<Partidas>
{
    public void Configure(EntityTypeBuilder<Partidas> builder)
    {
        builder.ToTable("Partidas");

        builder.HasKey(x => x.Id);

        builder.Property(x => x.Cantidad)
            .IsRequired();
        
        builder.Property(x => x.NoFactura)
            .HasMaxLength(100)
            .IsRequired(false);

        builder.Property(x => x.FechaCreacion)
            .ValueGeneratedOnAddOrUpdate()
            .HasDefaultValueSql("CURRENT_TIMESTAMP");
            // .HasDefaultValueSql("GETDATE()");

        builder.Property(x => x.FechaModificacion)
            .HasDefaultValueSql("CURRENT_TIMESTAMP")
            .ValueGeneratedOnAddOrUpdate();
            // .HasDefaultValueSql("GETDATE()");

        builder.HasOne(x => x.TipoActivo)
            .WithMany(x => x.Partidas)
            .HasForeignKey(x => x.TipoActivoId)
            .IsRequired()
            .OnDelete(DeleteBehavior.Cascade);
        
        builder.HasOne(x => x.Producto)
            .WithMany(x => x.Partidas)
            .HasForeignKey(x => x.ProductoId)
            .IsRequired()
            .OnDelete(DeleteBehavior.Cascade);

        builder.HasOne(x => x.Proveedor)
            .WithMany(x => x.Partidas)
            .HasForeignKey(x => x.ProveedorId)
            .IsRequired()
            .OnDelete(DeleteBehavior.Cascade);
    }

}