using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using kertesz_projekt_oenik.Data;
using kertesz_projekt_oenik.Models;
using kertesz_projekt_oenik.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;

namespace kertesz_projekt_oenik.Controllers
{
    [Route("users")]
    public class AuthController : Controller
    {
        private readonly UserManager<User> _userManager;
        private readonly IConfiguration _configuration;
        private readonly ApplicationDbContext applicationDbContext;

        public AuthController(UserManager<User> userManager, IConfiguration configuration, ApplicationDbContext context)
        {
            _userManager = userManager;
            _configuration = configuration;
            applicationDbContext = context;
        }

        [Route("register")]
        [Authorize(Roles = "Admin")]
        [HttpPost]
        public async Task<ActionResult> InsertUser([FromBody] RegisterViewModel model)
        {
            var currentUserName = this.User.FindFirst(ClaimTypes.NameIdentifier).Value;
            User currentUser = _userManager.FindByNameAsync(currentUserName).Result;

            var user = CreateUserFromViewModel(model);
            user.CreatedOn = DateTime.Now;
            user.ModifiedOn = DateTime.Now;
            user.CreatedBy = currentUser;

            var result = await _userManager.CreateAsync(user, model.Password);

            if (result.Succeeded)
            {
                await _userManager.AddToRoleAsync(user, model.Role);
                return Ok(new { Username = user.UserName });
            }
            else
            {
                return BadRequest(result.Errors.ToList());
            }
        }

        [Route("login")]
        [HttpPost]
        public async Task<ActionResult> Login([FromBody] LoginViewModel model)
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
                user.LastIP = this.Request.HttpContext.Connection.RemoteIpAddress.ToString();
                await _userManager.UpdateAsync(user);

                return Ok(
                  new
                  {
                      token = new JwtSecurityTokenHandler().WriteToken(token),
                      expiration = token.ValidTo
                  });
            }
            return Unauthorized();
        }

        [HttpGet]
        [Authorize(Roles = "Admin")]
        public async Task<IEnumerable<User>> List()
        {
            return await _userManager.Users.ToListAsync();
        }

        [HttpGet("{username}")]
        [Authorize(Roles = "Admin")]
        public async Task<User> GetUserByUsername(string username)
        {
            return await _userManager.FindByNameAsync(username);
        }

        [HttpDelete("{uid}")]
        [Route("delete")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Delete(string uid)
        {
            var user = await _userManager.FindByIdAsync(uid);
            if (user != null)
            {
                var result = await _userManager.DeleteAsync(user);
                if (result.Succeeded)
                {
                    return Ok();
                }
                else
                {
                    return BadRequest(result.Errors.ToList());
                }
            }
            else
            {
                return NotFound("User not found");
            }
        }

        [HttpPatch("{uid}")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Update(string uid, [FromBody] JsonPatchDocument<User> patchDoc)
        {
            if (patchDoc != null)
            {
                var user = await _userManager.FindByIdAsync(uid);
                patchDoc.ApplyTo(user);
                user.ModifiedOn = DateTime.Now;
                await _userManager.UpdateAsync(user);
                return Ok(user);
            }
            else
            {
                return BadRequest();
            }
        }

        private User CreateUserFromViewModel(RegisterViewModel model)
        {
            return new User()
            {
                Email = model.Email,
                UserName = model.Username,
                SecurityStamp = Guid.NewGuid().ToString(),
                FirstName = model.FirstName,
                LastName = model.LastName,
                NormalizedUserName = model.Username.ToUpper(),
                NormalizedEmail = model.Email.ToUpper(),
                ModifiedOn = DateTime.Now,
                EmailConfirmed = true
            };
        }
    }
}