using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Oyun.DataAccess;
using Oyun.DTOs.Languages;
using Oyun.Entities;
using Oyun.Exceptions.Language;
using Oyun.Services.Abstracts;

namespace Oyun.Services.Implements;

public class LanguageService(GameDbContext _context, IMapper _mapper) : ILanguageService
{
    public async Task <IEnumerable<LanguageGetDto>> GetDtosAsync()
    {
        var datas = await _context.Languages.ToListAsync();
        //var languages = datas.Select(x =>
        //        _mapper.Map<LanguageGetDto>(x)
        //    );
        var languages = _mapper.Map< IEnumerable<LanguageGetDto>>(datas);
        return languages;
    }
    public async Task CreateAsync(LanguageCreateDto dto)
    {
        if (await _context.Languages.AnyAsync(x => x.Code == dto.Code)) {
            throw new LanguageExistException();
        }

        var language = _mapper.Map<Language>(dto);
        await _context.Languages.AddAsync(language);
        await _context.SaveChangesAsync();
    }

    public async Task UpdateAsync(string code, LanguageUpdateDto dto)
    {

        var data = await _context.Languages.FirstOrDefaultAsync(x => x.Code == code);
        if(data == null) throw new LanguageNotFoundException();
        _mapper.Map(dto, data);
        await _context.SaveChangesAsync();
    }

    public async Task DeleteAsync(string code)
    {
        var data = await _context.Languages.FirstOrDefaultAsync(x => x.Code == code);
        
        if(data is not null)
        {
            _context.Languages.Remove(data);
            await _context.SaveChangesAsync();
        }

        throw new LanguageNotFoundException();
    }

}
