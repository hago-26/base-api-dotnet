

using Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Data.Configuration;

public class UsuarioConsiguration : IEntityTypeConfiguration<Usuario>
{
    public void Configure(EntityTypeBuilder<Usuario> builder)
    {
        builder.ToTable("Usuarios");
        builder.Property(p=>p.Id)
            .IsRequired();
        builder.Property(p=>p.Nombres)
            .IsRequired()
            .HasMaxLength(50);
        builder.Property(p=>p.ApellidoPaterno)
            .IsRequired()
            .HasMaxLength(50);
        builder.Property(p=>p.ApellidoMaterno)
            .IsRequired()
            .HasMaxLength(50);
        builder.Property(p=>p.Email)
            .IsRequired()
            .HasMaxLength(100);
        builder.Property(p=>p.Username)
            .IsRequired()
            .HasMaxLength(50);
        
        builder.HasMany(p=>p.Roles)
            .WithMany(p=>p.Usuarios)
            .UsingEntity<UsuariosRoles>(
                j=>j.HasOne(p=>p.Rol)
                    .WithMany(p=>p.UsuariosRoles)
                    .HasForeignKey(p=>p.RolId),
                j=>j.HasOne(p=>p.Usuario)
                    .WithMany(p=>p.UsuarioRoles)
                    .HasForeignKey(p=>p.UsuarioId),
                j=>j.HasKey(p=>new {p.UsuarioId, p.RolId})
            );
        
        builder.HasMany(p=>p.RefreshTokens)
            .WithOne(p=>p.Usuario)
            .HasForeignKey(p=>p.UsuarioId);


    }
}