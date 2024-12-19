using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Oyun.DataAccess;
using Oyun.DTOs.Languages;
using Oyun.Entities;
using Oyun.Services.Abstracts;

namespace Oyun.Services.Implements;

public class LanguageService(GameDbContext _context, IMapper _mapper) : ILanguageService
{
    public async Task CreateAsync(LanguageCreateDto dto)
    {
        var language = _mapper.Map<Language>(dto);
        await _context.Languages.AddAsync(language);
        await _context.SaveChangesAsync();
    }

    public async Task UpdateAsync(string code, LanguageCreateDto dto)
    {

        var language = _mapper.Map<Language>(dto);
        var data = await _context.Languages.FirstOrDefaultAsync(x => x.Code == code);
        data = language;
        await _context.SaveChangesAsync();
    }

    public void Delete(string code)
    {
        var data = _context.Languages.FirstOrDefault(x => x.Code == code);
        if(data is not null)
        {
            _context.Languages.Remove(data);
            _context.SaveChangesAsync();
        }
    }

    public IEnumerable<LanguageGetDto> GetDtos()
    {
        var datas = _context.Languages.ToList();
        var languages = datas.Select(x =>
                _mapper.Map<LanguageGetDto>(x)
            );
        return languages;
    }
}
