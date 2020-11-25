using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using project.Domain.Models;
using project.Domain.DTO;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Text;
using System.Threading.Tasks;

namespace project.Repository.Interfaces
{
    public interface IUserRepository<T> where T : User
    {
        UserManager<User> UserManager { get; set; }
        IConfiguration Configuration { get; set; }
        Task<User> Get(string id);
        Task<User> GetByName(string name);
        Task<IEnumerable<T>> GetAll();

        Task<bool> Delete(string id);

        Task<bool> Update(User updatedUser);

        Task<bool> RegisterUser(RegisterData model);
        Task<JwtSecurityToken> Login(LoginData model);
    }
}
