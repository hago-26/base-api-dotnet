using Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Data.Configuration;

public class EmpleadoConfiguration : IEntityTypeConfiguration<Empleado>
{
    public void Configure(EntityTypeBuilder<Empleado> builder)
    {
        builder.ToTable("Empleado");

        builder.HasKey(x => x.Id);

        builder.Property(x => x.NoEmpleado)
            .IsRequired();

        builder.Property(x => x.Nombres)
            .HasMaxLength(100)
            .IsRequired();

        builder.Property(x => x.ApellidoPaterno)
            .HasMaxLength(100)
            .IsRequired();
        
        builder.Property(x => x.ApellidoMaterno)
            .HasMaxLength(100)
            .IsRequired();

        builder.Property(x => x.FechaCreacion)
            .ValueGeneratedOnAddOrUpdate()
            .HasDefaultValueSql("CURRENT_TIMESTAMP");
            // .HasDefaultValueSql("GETDATE()");

        builder.Property(x => x.FechaModificacion)
            .HasDefaultValueSql("CURRENT_TIMESTAMP")
            .ValueGeneratedOnAddOrUpdate();
            // .HasDefaultValueSql("GETDATE()");

        builder.HasOne(x => x.Dependencia)
            .WithMany(x => x.Empleados)
            .HasForeignKey(x => x.DependenciaId)
            .IsRequired()
            .OnDelete(DeleteBehavior.ClientSetNull);
    }

}