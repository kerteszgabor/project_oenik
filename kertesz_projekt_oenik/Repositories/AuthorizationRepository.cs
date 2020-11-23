using kertesz_projekt_oenik.Data;
using kertesz_projekt_oenik.Exceptions;
using kertesz_projekt_oenik.Models;
using kertesz_projekt_oenik.ViewModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace kertesz_projekt_oenik.Repositories
{
    public class AuthorizationRepository
    {
        private readonly UserManager<User> _userManager;
        private readonly IConfiguration _configuration;


        public AuthorizationRepository(UserManager<User> userManager, IConfiguration configuration)
        {
            _userManager = userManager;
            _configuration = configuration;
        }

        public async Task<bool> InsertUser(RegisterViewModel model, string currentUserName)
        {
            User currentUser = _userManager.FindByNameAsync(currentUserName).Result;

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

            var result = await _userManager.CreateAsync(user, model.Password);

            if (result.Succeeded)
            {
                await _userManager.AddToRoleAsync(user, model.Role);
                return true;
            }
            else
            {
                throw new CannotAddUserException(result.Errors.ToList());
            }
        }

        public async Task<JwtSecurityToken> Login(LoginViewModel model, string ipAddress)
        {
            var user = await _userManager.FindByNameAsync(model.Username);
            var userRoles = await _userManager.GetRolesAsync(user);

            if (user != null && await _userManager.CheckPasswordAsync(user, model.Password))
            {
                var claim = new[] {
                    new Claim(JwtRegisteredClaimNames.Sub, user.UserName),
                    new Claim(ClaimTypes.Role, userRoles.FirstOrDefault())
                };
                var signinKey = new SymmetricSecurityKey(
                  Encoding.UTF8.GetBytes(_configuration["Jwt:SigningKey"]));

                int expiryInMinutes = Convert.ToInt32(_configuration["Jwt:ExpiryInMinutes"]);

                var token = new JwtSecurityToken(
                  issuer: _configuration["Jwt:Site"],
                  audience: _configuration["Jwt:Site"],
                  claims: claim,
                  expires: DateTime.Now.AddMinutes(60),
                  signingCredentials: new SigningCredentials(signinKey, SecurityAlgorithms.HmacSha256)
                );

                user.LastLogin = DateTime.Now;
                user.LastIP = ipAddress;
                await _userManager.UpdateAsync(user);

                return token;
            }
            else
            {
                throw new UserNotFoundException();
            }
        }


        public async Task<IEnumerable<User>> List()
        {
            return await _userManager.Users.ToListAsync();
        }


        public async Task<User> GetUserByUsername(string username)
        {
            var user = await _userManager.FindByNameAsync(username);
            if (user != null)
            {
                return user;
            }
            else
            {
                throw new UserNotFoundException();
            }
        }

        public async Task<User> GetUserByID(string uid)
        {
            var user = await _userManager.FindByIdAsync(uid);
            if (user != null)
            {
                return user;
            }
            else
            {
                throw new UserNotFoundException();
            }
        }


        public async Task<bool> Delete(string uid)
        {
            var user = await _userManager.FindByIdAsync(uid);
            if (user != null)
            {
                var result = await _userManager.DeleteAsync(user);
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
                throw new UserNotFoundException();
            }
        }

        public async Task<bool> Update(User updatedUser)
        {
            if (updatedUser.Id != null)
            {
                var result = await _userManager.UpdateAsync(updatedUser);
                if (result.Succeeded)
                {
                    return true;
                }
            }
            return false;
        }

    }
}
