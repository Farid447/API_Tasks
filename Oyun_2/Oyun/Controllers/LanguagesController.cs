using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Oyun.DataAccess;
using Oyun.DTOs.Languages;
using Oyun.Exceptions;
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
        try
        {
            await _service.CreateAsync(dto);
            return Created();
        }
        catch (Exception ex)
        {
            if (ex is IBaseException ibe)
            {
                return StatusCode(ibe.StatusCode, new
                {
                    StatusCode = ibe.StatusCode,
                    Message = ibe.ErrorMessage
                });
            }
            else
            {
                return BadRequest(new
                {
                    StatusCode = StatusCodes.Status400BadRequest,
                    Message = ex.Message
                });
            }
        }
    }
    [HttpPut]
    public async Task<IActionResult> Update(string code, LanguageUpdateDto dto)
    {
        try
        {
            await _service.UpdateAsync(code, dto);
            return Ok();
        }
        catch (Exception ex)
        {
            if (ex is IBaseException ibe)
            {
                return StatusCode(ibe.StatusCode, new
                {
                    StatusCode = ibe.StatusCode,
                    Message = ibe.ErrorMessage
                });
            }
            else
            {
                return BadRequest(new
                {
                    StatusCode = StatusCodes.Status400BadRequest,
                    Message = ex.Message
                });
            }
        }
    }

    [HttpDelete]
    public async Task<IActionResult> Delete(string code)
    {
        try
        {
            await _service.DeleteAsync(code);
            return Ok();
        }
        catch (Exception ex)
        {
            if (ex is IBaseException ibe)
            {
                return StatusCode(ibe.StatusCode, new
                {
                    StatusCode = ibe.StatusCode,
                    Message = ibe.ErrorMessage
                });
            }
            else
            {
                return BadRequest(new
                {
                    StatusCode = StatusCodes.Status400BadRequest,
                    Message = ex.Message
                });
            }
        }
    }
}
