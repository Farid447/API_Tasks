using Blog.BL.DTOs.CategoryDtos;
using Blog.BL.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Blog.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriesController(ICategoryService _service) : ControllerBase
    {

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            return Ok(await _service.GetAllAsync());
        }
        [HttpPost]
        public async Task<IActionResult> Post(CategoryCreateDto dto)
        {
            return Ok(await _service.CreateAsync(dto));
        }
    }
}
