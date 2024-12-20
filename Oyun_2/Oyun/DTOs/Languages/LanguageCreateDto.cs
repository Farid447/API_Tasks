using FluentValidation;

namespace Oyun.DTOs.Languages;

public class LanguageCreateDto
{
    public string Code { get; set; }
    public string Name { get; set; }
    public string IconUrl { get; set; }
}


public class LanguageCreateDtoValidator :
    AbstractValidator<LanguageCreateDto>
{
    public LanguageCreateDtoValidator()
    {
        RuleFor(x => x.Code)
            .NotNull()
            .NotEmpty()
                .WithMessage("Code daxil edilmeyib")
            .MaximumLength(2)
                .WithMessage("Code uzunlugu 2-den cox olmamalidir");

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