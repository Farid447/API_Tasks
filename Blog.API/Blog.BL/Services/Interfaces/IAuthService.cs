using Blog.BL.DTOs.UserDtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blog.BL.Services.Interfaces
{
    public interface IAuthService
    {
        Task RegisterAsync(UserCreateDto dto);
        Task LoginAsync(LoginDto dto);
    }
}
