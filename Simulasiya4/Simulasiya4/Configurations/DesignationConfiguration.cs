using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Simulasiya4.Models;

namespace Simulasiya4.Configurations;

public class DesignationConfiguration : IEntityTypeConfiguration<Designation>
{
    public void Configure(EntityTypeBuilder<Designation> builder)
    {
        builder.HasKey(x => x.Id);

        builder.HasIndex(x => x.Name)
            .IsUnique();
        
        builder.Property(x => x.Name)
            .IsRequired()
            .HasMaxLength(32);

        builder.HasMany(x => x.Agents)
            .WithOne(x => x.Designation)
            .HasForeignKey(x=>x.DesignationId);
    }
}
