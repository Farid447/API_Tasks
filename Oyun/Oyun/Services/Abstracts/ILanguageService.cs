using Oyun.DTOs.Languages;

namespace Oyun.Services.Abstracts;

public interface ILanguageService
{
    IEnumerable<LanguageGetDto> GetDtos();
    Task CreateAsync(LanguageCreateDto dto);
    Task UpdateAsync(string code, LanguageCreateDto dto);
    void Delete(string code);

}
