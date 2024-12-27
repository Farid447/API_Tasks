using Microsoft.EntityFrameworkCore;
using Oyun.DataAccess;
using Oyun.Entities;
using Oyun.Services.Abstracts;

namespace Oyun.Services.Implements
{
    public class BannedWordService(GameDbContext _context) : IBannedWordService
    {
        public async Task UpdateAsync(int wordid, IEnumerable<string> bannedwords)
        {
            await _context.BannedWords.Where(x=> x.WordId == wordid).ExecuteDeleteAsync();

            //await _context.BannedWords.AddRangeAsync(bannedwords.Select(x => new BannedWord
            //{
            //    WordId = wordid,
            //    Text = x,
            //}));
        }
    }
}
