using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Oyun.Entities;
using System.Reflection.Emit;
using System.Xml.Linq;

namespace Oyun.Configurations;

public class LanguageConfiguration : IEntityTypeConfiguration<Language>
{
    public void Configure(EntityTypeBuilder<Language> builder)
    {
        builder.HasKey(x => x.Code);

        builder.Property(x => x.Code)
            .IsRequired()
            .HasMaxLength(2);

        builder.HasIndex(x => x.Name)
            .IsUnique();
        builder.Property(x => x.Name)
            .IsRequired()
            .HasMaxLength(64);

        builder.Property(x => x.Icon)
            .IsRequired()
            .HasMaxLength(128);

        builder.HasData(new Language
        {
            Code = "az",
            Name = "Azerbaycan",
            Icon = "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcTzOIeLrfRjNSl291z5B9weULOtPVX6GeY6-w&s"
        },
        new Language
        {
            Code = "en",
            Name = "England",
            Icon = "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcSAhgD5R3n8P5wVerL-V1NvWklPxG3COIW6YQ&s"

        });
    }
}
