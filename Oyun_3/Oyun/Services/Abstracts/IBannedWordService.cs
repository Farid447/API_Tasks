using Oyun.Entities;

namespace Oyun.Services.Abstracts;
public interface IBannedWordService
{
    Task UpdateAsync(int wordid, IEnumerable<string> bannedwords);
}
