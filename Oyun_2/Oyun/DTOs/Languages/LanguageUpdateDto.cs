using FluentValidation;
using Oyun.DTOs.Languages;

namespace Oyun.DTOs.Languages
{
    public class LanguageUpdateDto
    {
        public string Name { get; set; }
        public string IconUrl { get; set; }
    }
}

public class LanguageUpdateDtoValidator :
    AbstractValidator<LanguageUpdateDto>
{
    public LanguageUpdateDtoValidator()
    {

        RuleFor(x => x.Name)
            .NotNull()
            .NotEmpty()
                .WithMessage("Ad daxil edilmeyib")
            .MaximumLength(64)
                .WithMessage("Ad uzunlugu 64 simvoldan cox ola bilmez");

        RuleFor(x => x.IconUrl)
            .NotNull()
            .NotEmpty()
                .WithMessage("Icon daxil edilmeyib")
            .Matches("^http(s)?://([\\w-]+.)+[\\w-]+(/[\\w- ./?%&=])?$")
                .WithMessage("Icon deyeri Link olmalidir")
            .MaximumLength(128)
                .WithMessage("Icon uzunlugu 128-den cox ola bilmez");

    }
}