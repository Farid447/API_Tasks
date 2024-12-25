using AutoMapper;
using Oyun.DTOs.Languages;
using Oyun.DTOs.Words;
using Oyun.Entities;

namespace Oyun.Profiles;

public class WordProfile : Profile
{
    public WordProfile()
    {
        CreateMap<WordCreateDto, Word>()
            .ForMember(l => l.BannedWords, d => d.MapFrom(t => t.BannedWords.Select(x => new BannedWord
            {
                Text = x,
            })));

        CreateMap<WordUpdateDto, Word>()
            .ForMember(l => l.BannedWords, d => d.MapFrom(t => t.BannedWords.Select(x => new BannedWord
            {
                Text = x,
            })));
    }
}
