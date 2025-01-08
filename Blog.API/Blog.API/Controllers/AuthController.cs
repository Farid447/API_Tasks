using Blog.BL.DTOs.UserDtos;
using Blog.BL.Services.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Blog.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController(IAuthService _service) : ControllerBase
    {
        [HttpPost("action")]
        public async Task<IActionResult> Login()
        {
            return Ok();
        }

        [HttpPost("action")]
        public async Task<IActionResult> Register(UserCreateDto dto)
        {
            //await _service.RegisterAsync(dto);
            return Created();
        }
    }
}
