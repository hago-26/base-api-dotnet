using Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Data.Configuration;

public class ProductoConfiguration : IEntityTypeConfiguration<Producto>
{
    public void Configure(EntityTypeBuilder<Producto> builder)
    {
        builder.ToTable("Producto");

        builder.HasKey(x => x.Id);

        builder.Property(x => x.Nombre)
            .HasMaxLength(100)
            .IsRequired();

        builder.Property(x => x.Modelo)
            .HasMaxLength(100);

        builder.HasOne(x => x.MarcaProducto)
            .WithMany(x => x.Productos)
            .HasForeignKey(x => x.MarcaProductoId)
            .IsRequired()
            .OnDelete(DeleteBehavior.Cascade);
    }

}