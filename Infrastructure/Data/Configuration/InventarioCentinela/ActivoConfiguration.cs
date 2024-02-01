using Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Data.Configuration;

public class ActivoConfiguration : IEntityTypeConfiguration<Activo>
{
    public void Configure(EntityTypeBuilder<Activo> builder)
    {
        builder.ToTable("Activo");

        builder.HasKey(x => x.Id);

        builder.Property(x => x.NoInventario)
            .HasMaxLength(100)
            .IsRequired();
        
        builder.Property(x => x.NoSerie)
            .HasMaxLength(100)
            .IsRequired();
        
        builder.Property(x => x.NoFactura)
            .HasMaxLength(100)
            .IsRequired(false);

        builder.Property(x => x.Comentarios)
            .HasMaxLength(500)
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
            .WithMany(x => x.Activos)
            .HasForeignKey(x => x.TipoActivoId)
            .IsRequired()
            .OnDelete(DeleteBehavior.Cascade);
        
        builder.HasOne(x => x.Producto)
            .WithMany(x => x.Activos)
            .HasForeignKey(x => x.ProductoId)
            .IsRequired()
            .OnDelete(DeleteBehavior.Cascade);
            
        builder.HasOne(x => x.Partida)
            .WithMany(x => x.Activos)
            .HasForeignKey(x => x.PartidaId)
            .IsRequired(false)
            .OnDelete(DeleteBehavior.Cascade); // Desactivar temporalmente la acción de borrado en caso de conflicto

        builder.HasOne(x => x.Proveedor)
            .WithMany(x => x.Activos)
            .HasForeignKey(x => x.ProveedorId)
            .IsRequired()
            .OnDelete(DeleteBehavior.Cascade);

        

    }

}