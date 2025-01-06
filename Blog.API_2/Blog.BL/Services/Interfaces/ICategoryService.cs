using Blog.BL.DTOs.CategoryDtos;

namespace Blog.BL.Services.Interfaces;
public interface ICategoryService
{
    Task<IEnumerable<CategoryListItem>> GetAllAsync();
    Task<int> CreateAsync(CategoryCreateDto dto);
}
