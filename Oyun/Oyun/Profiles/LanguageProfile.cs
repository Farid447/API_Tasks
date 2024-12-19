using AutoMapper;
using Oyun.DTOs.Languages;
using Oyun.Entities;

namespace Oyun.Profiles;

public class LanguageProfile : Profile
{
    public LanguageProfile()
    {
        CreateMap<LanguageCreateDto, Language>()
            .ForMember(l => l.Icon, d => d.MapFrom(t => t.IconUrl));
        CreateMap<Language,  LanguageGetDto>();
    }
}
