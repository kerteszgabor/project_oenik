using Microsoft.AspNetCore.JsonPatch;
using project.Domain.DTO;
using project.Domain.Models;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Text;
using System.Threading.Tasks;

namespace project.Service.Interfaces
{
    public interface IUserService
    {
        Task<IEnumerable<User>> List();
        Task<User> Get(string uid);
        Task<bool> Delete(string uid);
        Task<bool> Update(string uid, JsonPatchDocument<User> patch);
        Task<User> GetUserByName(string name);
        Task<bool> Register(RegisterData model);
        Task<JwtSecurityToken> Login(LoginData model);
    }
}
