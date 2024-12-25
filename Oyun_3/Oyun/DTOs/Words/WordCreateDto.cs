using FluentValidation;

namespace Oyun.DTOs.Words;

public class WordCreateDto
{
    public string Text { get; set; }
    public string Language { get; set; }
    public IEnumerable<string> BannedWords { get; set; }
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
            .NotNull();

        RuleForEach(x => x.BannedWords)
            .NotNull()
            .MaximumLength(32);
    }
}