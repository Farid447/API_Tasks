using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Simulasiya4.Models;

namespace Simulasiya4.DataAccess;

public class SimulasiyaDbContext : IdentityDbContext<User>
{
    public DbSet<Agent> Agents { get; set; }
    public DbSet<Designation> Designations { get; set; }

    public SimulasiyaDbContext(DbContextOptions option) : base(option) {}

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(SimulasiyaDbContext).Assembly);
        base.OnModelCreating(modelBuilder);
    }
}
