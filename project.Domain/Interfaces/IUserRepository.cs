using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using project.Domain.Models;
using project.Domain.DTO;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Text;
using System.Threading.Tasks;
using System.Linq;

namespace project.Domain.Interfaces
{
    public interface IUserRepository<T> : IRepository<T> where T : User
    {
        //UserManager<User> UserManager { get; set; }
        //IConfiguration Configuration { get; set; }
        Task<bool> Register(RegisterData registerData);
        Task<JwtSecurityToken> Login(LoginData loginData);
    }
}
