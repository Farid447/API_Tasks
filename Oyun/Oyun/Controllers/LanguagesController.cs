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
    public IActionResult Get()
    {
        _service.GetDtos();
        return Ok();
    }
    [HttpPost]
    public async Task<IActionResult> Post(LanguageCreateDto dto)
    {
        await _service.CreateAsync(dto);
        return Created();
    }
    [HttpPut]
    public async Task<IActionResult> Update(string code, LanguageCreateDto dto)
    {
        await _service.UpdateAsync(code, dto);
        return Ok();
    }

    [HttpDelete]
    public IActionResult Delete(string code)
    {
        _service.Delete(code);
        return Ok();
    }
}
