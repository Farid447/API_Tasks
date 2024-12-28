using Blog.Core.Entities;

namespace Blog.BL.DTOs.CategoryDtos;
public class CategoryCreateDto
{
    public string Name { get; set; }
    public string Icon { get; set; }
    public static implicit operator Category(CategoryCreateDto dto)
    {
        Category category = new Category
        {
            Icon = dto.Icon,
            Name = dto.Name
        };
        return category;
    }
}
