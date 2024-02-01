using Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Data.Configuration;

public class MarcaProductoConfiguration : IEntityTypeConfiguration<MarcaProducto>
{
    public void Configure(EntityTypeBuilder<MarcaProducto> builder)
    {
        builder.ToTable("MarcaProducto");

        builder.HasKey(x => x.Id);

        builder.Property(x => x.Nombre)
            .HasMaxLength(100)
            .IsRequired();
    }
}