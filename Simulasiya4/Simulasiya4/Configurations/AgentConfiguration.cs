using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Simulasiya4.Models;

namespace Simulasiya4.Configurations;

public class AgentConfiguration : IEntityTypeConfiguration<Agent>
{
    public void Configure(EntityTypeBuilder<Agent> builder)
    {
        builder.HasKey(x => x.Id);

        builder.Property(x => x.Name)
            .IsRequired()
            .HasMaxLength(32);

        builder.HasOne(x => x.Designation)
            .WithMany(x => x.Agents)
            .HasForeignKey(x => x.DesignationId);
    }
}
