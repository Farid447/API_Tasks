using Oyun.DTOs.Languages;
using Oyun.DTOs.Words;
using Oyun.Entities;

namespace Oyun.Services.Abstracts;

public interface IWordService
{
    Task<IEnumerable<WordGetDto>> GetAllAsync();
    Task<int> CreateAsync(WordCreateDto dto);
    Task<int> UpdateAsync(int id, WordUpdateDto dto);
    Task DeleteAsync(int id);

}