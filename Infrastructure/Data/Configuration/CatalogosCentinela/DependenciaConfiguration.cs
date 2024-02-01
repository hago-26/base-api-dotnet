using Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Data.Configuration;

public class DependenciaConfiguration : IEntityTypeConfiguration<Dependencia>
{
    public void Configure(EntityTypeBuilder<Dependencia> builder)
    {
        builder.ToTable("Dependencia");

        builder.HasKey(x => x.Id);

        builder.Property(x => x.Nombre)
            .HasMaxLength(100)
            .IsRequired();

        builder.HasOne(x => x.DependenciaPadre)
            .WithMany(x => x.DependenciasHijas)
            .HasForeignKey(x => x.DependenciaPadreId)
            .IsRequired(false)
            .OnDelete(DeleteBehavior.ClientSetNull);
    }

}