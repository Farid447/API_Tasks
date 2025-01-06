namespace Blog.BL.Services.Interfaces;
public interface IUserService
{
    Task<string> CreateAsync();
    Task DeleteAsync(string username);

}
