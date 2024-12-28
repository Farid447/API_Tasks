using Blog.Core.Entities;
using Blog.Core.Repositories;
using Blog.DAL.Context;
using Microsoft.AspNetCore.Http;

namespace Blog.DAL.Repositories;

public class UserRepository : GenericRepository<User>, IUserRepository
{
    readonly HttpContext _httpContext;
    public UserRepository(BlogDbContext _context, IHttpContextAccessor httpContext) : base(_context)
    {
        _httpContext = httpContext.HttpContext;
    }

    public User GetCurrentUser()
    {
        throw new NotImplementedException();
    }

    public int GetCurrentUserId()
    {
        throw new NotImplementedException();
    }
}
