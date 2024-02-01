using Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Data.Configuration;

public class ProveedorConfiguration : IEntityTypeConfiguration<Proveedor>
{
    public void Configure(EntityTypeBuilder<Proveedor> builder)
    {
        builder.ToTable("Proveedor");

        builder.HasKey(x => x.Id);

        builder.Property(x => x.Nombre)
            .HasMaxLength(100)
            .IsRequired();
        
        builder.Property(x => x.Direccion)
            .HasMaxLength(100)
            .IsRequired(false);

        builder.Property(x => x.Telefono)
            .HasMaxLength(100)
            .IsRequired(false);
        
        builder.Property(x => x.Email)
            .HasMaxLength(100)
            .IsRequired(false);
        
    }

}