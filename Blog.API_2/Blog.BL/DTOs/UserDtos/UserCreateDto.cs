using Blog.Core.Repositories;
using FluentValidation;

namespace Blog.BL.DTOs.UserDtos;
public class UserCreateDto
{
    public string Username { get; set; }
    public string Email { get; set; }
    public string Password { get; set; }
    public string Name { get; set; }
    public string Surname { get; set; }
    public string? Image { get; set; }
    public bool IsMale { get; set; }
}

public class UserCreateDtoValidator : AbstractValidator<UserCreateDto>
{
    readonly IUserRepository _repo;
    //public UserCreateDtoValidator(IUserRepository repo)
    //{

    //    _repo = repo;
    //    RuleFor(x => x.Email)
    //        .NotEmpty()
    //        .NotNull()
    //        .EmailAddress();
    //    RuleFor(x => x.Username)
    //        .NotNull()
    //        .NotEmpty()
    //        .Must(x => _repo.GetByUserNameAsync(x).Result == null)
    //            .WithMessage("Username exist");
    //}
}