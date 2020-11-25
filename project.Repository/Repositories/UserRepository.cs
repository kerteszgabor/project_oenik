using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using project.Domain.Models;
using project.Domain.DTO;
using project.Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

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

        public async Task<JwtSecurityToken> Login(LoginData model)
        {
            var user = await UserManager.FindByNameAsync(model.Username);
            var userRoles = await UserManager.GetRolesAsync(user);

            if (user != null && await UserManager.CheckPasswordAsync(user, model.Password))
            {
                var claim = new[] {
                    new Claim(JwtRegisteredClaimNames.Sub, user.UserName),
                    new Claim(ClaimTypes.Role, userRoles.FirstOrDefault())
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

                user.LastLogin = DateTime.Now;
                user.LastIP = model.IPAddress;
                await UserManager.UpdateAsync(user);

                return token;
            }
            else
            {
                return null;
                // throw new UserNotFoundException();
            }
        }

        public async Task<bool> RegisterUser(RegisterData model)
        {
            User currentUser = UserManager.FindByNameAsync(model.RegisteringUserName).Result;

            var user = new User()
            {
                Email = model.Email,
                UserName = model.Username,
                SecurityStamp = Guid.NewGuid().ToString(),
                FirstName = model.FirstName,
                LastName = model.LastName,
                NormalizedUserName = model.Username.ToUpper(),
                NormalizedEmail = model.Email.ToUpper(),
                ModifiedOn = DateTime.Now,
                EmailConfirmed = true,
                CreatedOn = DateTime.Now,
                CreatedBy = currentUser
            };

            var result = await UserManager.CreateAsync(user, model.Password);

            if (result.Succeeded)
            {
                await UserManager.AddToRoleAsync(user, model.Role);
                return true;
            }
            else
            {
                return false;
            //    throw new CannotAddUserException(result.Errors.ToList());
            }
        }

        public async Task<User> GetByName(string name)
        {
            var user = await UserManager.FindByNameAsync(name);
            if (user != null)
            {
                return user;
            }
            else
            {
                return null;
              //  throw new UserNotFoundException();
            }
        }

        public async Task<User> Get(string id)
        {
            var user = await UserManager.FindByIdAsync(id);
            if (user != null)
            {
                return user;
            }
            else
            {
                return null;
                //throw new UserNotFoundException();
            }
        }
        public async Task<IEnumerable<User>> GetAll()
        {
            return await UserManager.Users.ToListAsync();
        }

        public async Task<bool> Delete(string uid)
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

        public async Task<bool> Update(User updatedUser)
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
    }
}
