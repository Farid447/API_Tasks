using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Oyun.DataAccess;
using Oyun.DTOs.Languages;
using Oyun.Services.Abstracts;

namespace Oyun.Controllers;

[Route("api/[controller]")]
[ApiController]
public class LanguagesController(ILanguageService _service) : ControllerBase
{

    [HttpGet]
    public async Task<IActionResult> Get()
    {
        return Ok(await _service.GetDtosAsync());
    }
    [HttpPost]
    public async Task<IActionResult> Post(LanguageCreateDto dto)
    {
        await _service.CreateAsync(dto);
        return Created();
    }
    [HttpPut]
    public async Task<IActionResult> Update(string code, LanguageUpdateDto dto)
    {
        await _service.UpdateAsync(code, dto);
        return Ok();
    }

    [HttpDelete]
    public async Task<IActionResult> Delete(string code)
    {
        await _service.DeleteAsync(code);
        return Ok();
    }
}
