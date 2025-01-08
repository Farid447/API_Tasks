using Blog.BL.DTOs.CategoryDtos;
using Blog.BL.Exceptions.Common;
using Blog.BL.Services.Interfaces;
using Blog.Core.Entities;
using Blog.Core.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Blog.BL.Services.Implements;

public class CategoryService(ICategoryRepository _repo) : ICategoryService
{
    public async Task<int> CreateAsync(CategoryCreateDto dto)
    {
        Category cat = dto;
        await _repo.AddAsync(cat);
        await _repo.SaveAsync();
        return cat.Id;
    }
    public async Task<IEnumerable<CategoryListItem>> GetAllAsync()
    {
        return await _repo.GetAll().Select(x=> new CategoryListItem
        {
            Id = x.Id,
            Name = x.Name,
            Icon = x.Icon
        }).ToListAsync();
    }

    public async Task DeleteAsync(int id)
    {
        var data = await _repo.GetByIdAsync(id);
        if (data != null)
        {
            throw new NotFoundException<Category>();
        }
        await _repo.DeleteAsync(id);
        await _repo.SaveAsync();

    }


    public async Task UpdateAsync(int id, string name)
    {
        var data = await _repo.GetByIdAsync(id);
        if (data != null)
        {
            throw new NotFoundException<Category>();
        }
        data.Name = name;
        await _repo.SaveAsync();
    }
}
