using AutoMapper;
using Blog.BL.DTOs.UserDtos;
using Blog.Core.Entities;

namespace Blog.BL.Profiles;

public class UserProfile : Profile
{
    public UserProfile()
    {
        CreateMap<UserCreateDto, User>();
    }
}
