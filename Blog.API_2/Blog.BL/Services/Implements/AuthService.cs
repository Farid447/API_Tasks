using AutoMapper;
using Blog.BL.DTOs.UserDtos;
using Blog.BL.Exceptions.Common;
using Blog.BL.Services.Interfaces;
using Blog.Core.Entities;
using Blog.Core.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blog.BL.Services.Implements
{
    internal class AuthService(IUserRepository _repo, IMapper _mapper) : IAuthService
    {
        public Task LoginAsync(LoginDto dto)
        {
            throw new NotImplementedException();
        }

        public async Task RegisterAsync(UserCreateDto dto)
        {
            var user = await _repo.GetAll().Where(x=>x.Username ==  dto.Username || x.Email == dto.Email).FirstOrDefaultAsync();
            if (user != null)
            {
                if (user.Username == dto.Username)
                    throw new ExistException<User>("This Username already exists");

                else if (user.Email == dto.Email)
                    throw new ExistException<User>("This Email already exists");
            }
            if (dto.Username.Contains("@"))
                throw new InvalidException<User>("Username contains the symbol @");

            user = _mapper.Map<User>(dto);
            await _repo.AddAsync(user);
            await _repo.SaveAsync();
        }
    }
}
