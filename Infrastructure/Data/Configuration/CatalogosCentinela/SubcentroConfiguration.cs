using Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Data.Configuration;

public class SubcentroConfiguration : IEntityTypeConfiguration<Subcentro>
{
    public void Configure(EntityTypeBuilder<Subcentro> builder)
    {
        builder.ToTable("Subcentro");

        builder.HasKey(x => x.Id);

        builder.Property(x => x.Nombre)
            .HasMaxLength(100)
            .IsRequired();
    }

}