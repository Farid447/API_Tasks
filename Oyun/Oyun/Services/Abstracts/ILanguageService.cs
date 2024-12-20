using Oyun.DTOs.Languages;

namespace Oyun.Services.Abstracts;

public interface ILanguageService
{
    Task <IEnumerable<LanguageGetDto>> GetDtosAsync();
    Task CreateAsync(LanguageCreateDto dto);
    Task UpdateAsync(string code, LanguageUpdateDto dto);
    Task DeleteAsync(string code);

}
