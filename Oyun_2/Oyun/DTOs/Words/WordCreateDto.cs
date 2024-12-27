using FluentValidation;
using Oyun.Enums;

namespace Oyun.DTOs.Words;

public class WordCreateDto
{
    public string Text { get; set; }
    public string LanguageCode { get; set; }
    public HashSet<string> BannedWords { get; set; }
}

public class WordCreateDtoValidator : AbstractValidator<WordCreateDto>
{
    public WordCreateDtoValidator()
    {
        RuleFor(x => x.Text)
            .NotEmpty()
            .NotNull()
            .MaximumLength(32);

        RuleFor(x => x.BannedWords)
            .NotNull()
            .Must(x => x.Count() == (int)GameLevel.Hard)
                .WithMessage($"{(int)GameLevel.Hard} ədəd təkrar olunmayan söz daxil edin.");

        RuleForEach(x => x.BannedWords)
            .NotNull()
            .MaximumLength(32);
    }
}