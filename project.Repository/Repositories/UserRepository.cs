using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using project.Domain.Models;
using project.Domain.DTO;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using project.Domain.Interfaces;
using project.Domain.DTO.Auth;

namespace project.Repository.Repositories
{
    public class UserRepository : IUserRepository<User>
    {
        public UserManager<User> UserManager { get; set; }
        public IConfiguration Configuration { get; set; }

        public UserRepository(UserManager<User> userManager, IConfiguration configuration)
        {
            this.UserManager = userManager;
            this.Configuration = configuration;
        }

        public async Task<JwtSecurityToken> Login(LoginData loginData)
        {
            var currentUser = await UserManager.FindByNameAsync(loginData.Username);
            var userRoles = await UserManager.GetRolesAsync(currentUser);

            if (currentUser != null && await UserManager.CheckPasswordAsync(currentUser, loginData.Password))
            {
                var claim = new[] {
                    new Claim(JwtRegisteredClaimNames.Sub, currentUser.Id),
                    new Claim(ClaimTypes.Role, userRoles.FirstOrDefault()),
                    new Claim(ClaimTypes.NameIdentifier, currentUser.UserName),
                    new Claim(ClaimTypes.Email, currentUser.Email)
                };
                var signinKey = new SymmetricSecurityKey(
                  Encoding.UTF8.GetBytes(Configuration["Jwt:SigningKey"]));

                int expiryInMinutes = Convert.ToInt32(Configuration["Jwt:ExpiryInMinutes"]);

                var token = new JwtSecurityToken(
                  issuer: Configuration["Jwt:Site"],
                  audience: Configuration["Jwt:Site"],
                  claims: claim,
                  expires: DateTime.Now.AddMinutes(60),
                  signingCredentials: new SigningCredentials(signinKey, SecurityAlgorithms.HmacSha256)
                ) ;

                currentUser.LastLogin = DateTime.Now;
                currentUser.LastIP = loginData.IPAddress;
                await UserManager.UpdateAsync(currentUser);

                return token;
            }
            else
            {
                return null;
                // throw new UserNotFoundException();
            }
        }
        public async Task<bool> Register(RegisterData registerData)
        {
            User currentUser = UserManager.FindByNameAsync(registerData.RegisteringUserName).Result;

            var newUser = new User()    //maybe automapper would be more elegant
            {
                Id = Guid.NewGuid().ToString(),
                Email = registerData.Email,
                UserName = registerData.Username,
                SecurityStamp = Guid.NewGuid().ToString(),
                FirstName = registerData.FirstName,
                LastName = registerData.LastName,
                NormalizedUserName = registerData.Username.ToUpper(),
                NormalizedEmail = registerData.Email.ToUpper(),
                ModifiedOn = DateTime.Now,
                EmailConfirmed = true,
                CreatedOn = DateTime.Now,
                CreatedBy = currentUser
            };

            var result = await UserManager.CreateAsync(newUser, registerData.Password);

            if (result.Succeeded)
            {
                var roleResult = await UserManager.AddToRoleAsync(newUser, registerData.Role);
                return true;
            }
            else
            {
                return false;
            //    throw new CannotAddUserException(result.Errors.ToList());
            }
        }

        public async Task<User> GetAsync(string id)
        {
            var user = await UserManager.FindByIdAsync(id);
            if (user != null)
            {
                user.ConcurrencyStamp = String.Empty;
                user.PasswordHash = String.Empty;
                user.SecurityStamp = String.Empty;
                return user;
            }
            else
            {
                return null;
                //throw new UserNotFoundException();
            }
        }
        //public IQueryable<User> GetAllAsync()
        //{
        //    return UserManager.Users.AsQueryable();
        //}

        public async IAsyncEnumerable<User> GetAllAsync()
        {
            await foreach (var item in UserManager.Users.AsAsyncEnumerable())
            {
                item.ConcurrencyStamp = String.Empty;
                item.PasswordHash = String.Empty;
                item.SecurityStamp = String.Empty;
                yield return item;
            }
        }

        public async Task<bool> DeleteAsync(string uid)
        {
            var user = await UserManager.FindByIdAsync(uid);
            if (user != null)
            {
                var result = await UserManager.DeleteAsync(user);
                if (result.Succeeded)
                {
                    return true;
                }
                else
                {
                    //TODO: check for errors
                    return false;
                }
            }
            else
            {
                return false;
               // throw new UserNotFoundException();
            }
        }

        public async Task<bool> UpdateAsync(User updatedUser)
        {
            if (updatedUser.Id != null)
            {
                var result = await UserManager.UpdateAsync(updatedUser);
                if (result.Succeeded)
                {
                    return true;
                }
            }
            return false;
        }

        public Task<bool> CreateAsync(User entity)
        {
            throw new NotImplementedException();
        }
    }
}
