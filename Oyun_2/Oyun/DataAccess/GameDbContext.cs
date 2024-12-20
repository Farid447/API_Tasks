using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Oyun.Entities;

namespace Oyun.DataAccess;

public class GameDbContext : DbContext
{
    public GameDbContext(DbContextOptions opt) : base(opt) {}

    public DbSet<Language> Languages { get; set; }


    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(GameDbContext).Assembly);

        base.OnModelCreating(modelBuilder);
    }
}
