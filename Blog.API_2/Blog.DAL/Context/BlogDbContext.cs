using Blog.Core.Entities;
using Microsoft.EntityFrameworkCore;

namespace Blog.DAL.Context
{
    public class BlogDbContext : DbContext
    {
        public BlogDbContext(DbContextOptions opt) : base(opt)
        {
            
        }
        public DbSet<Category> Categories { get; set; }
        public DbSet<User> Users { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(BlogDbContext).Assembly);
            base.OnModelCreating(modelBuilder);
        }
    }
}
