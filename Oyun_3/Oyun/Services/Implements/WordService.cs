using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Oyun.DataAccess;
using Oyun.DTOs.Languages;
using Oyun.DTOs.Words;
using Oyun.Entities;
using Oyun.Exceptions.Language;
using Oyun.Exceptions.Word;
using Oyun.Services.Abstracts;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Oyun.Services.Implements;

public class WordService(GameDbContext _context, IMapper _mapper) : IWordService
{
    public async Task<IEnumerable<Word>> GetAllAsync()
    {
        return await _context.Words.ToListAsync();
    }

    public async Task<int> CreateAsync(WordCreateDto dto)
    {
        if (await _context.Words.AnyAsync(w => w.LanguageCode == dto.Language && w.Text == dto.Text))
        {
            throw new WordExistException();
        }

        if (dto.BannedWords.Count() != 6)
            throw new InvalidBannedWordCountExcpetion();

        Word word = _mapper.Map<Word>(dto);
        foreach (var bannedword in dto.BannedWords)
        {
            await _context.BannedWords.AddAsync(new BannedWord
            {
                WordId = word.Id,
                Text = bannedword
            });
        }

        await _context.Words.AddAsync(word);
        await _context.SaveChangesAsync();
        return word.Id;
    }

    public async Task<int> UpdateAsync(int id, WordUpdateDto dto)
    {
        var data = await _context.Words.FirstOrDefaultAsync(x => x.Id == id);
        
        if (data == null) throw new WordNotFoundException();
        
        _mapper.Map(dto, data);
        await _context.SaveChangesAsync();

        return data.Id;

    }

    public async Task DeleteAsync(int id)
    {
        var word = await _context.Words.FindAsync(id);

        if (word is null)
        {
            throw new WordNotFoundException();
        }

        foreach (var bannedword in word.BannedWords)
        {
            _context.BannedWords.Remove(bannedword);
        }

        //_context.BannedWords.Where(x => word.BannedWords.Contains(x);


        _context.Words.Remove(word);
        await _context.SaveChangesAsync();
        throw new NotImplementedException();
    }
}
