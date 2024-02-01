using Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Data.Configuration;

public class AsignacionesConfiguration : IEntityTypeConfiguration<Asignaciones>
{
    public void Configure(EntityTypeBuilder<Asignaciones> builder)
    {
        builder.ToTable("Asignaciones");

        builder.HasKey(x => x.Id);

        builder.Property(x => x.ResguardoUrl)
            .HasMaxLength(500);

        builder.Property(x => x.Comentarios)
            .HasMaxLength(500);

        builder.HasOne(x => x.Activo)
            .WithMany(x => x.Asignaciones)
            .HasForeignKey(x => x.ActivoId)
            .OnDelete(DeleteBehavior.Restrict);

        builder.HasOne(x => x.Resguardante)
            .WithMany(x => x.Asignaciones)
            .HasForeignKey(x => x.ResguradanteId)
            .OnDelete(DeleteBehavior.Restrict);

        builder.HasOne(x => x.Municipio)
            .WithMany(x => x.Asignaciones)
            .HasForeignKey(x => x.MunicipioId)
            .OnDelete(DeleteBehavior.Restrict);
    }

}