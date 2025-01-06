using Blog.Core.Entities;
using Blog.Core.Repositories;
using Blog.DAL.Context;

namespace Blog.DAL.Repositories;

public class CategoryRepository : GenericRepository<Category>, ICategoryRepository
{
    public CategoryRepository(BlogDbContext context) : base(context)
    {
    }
}
