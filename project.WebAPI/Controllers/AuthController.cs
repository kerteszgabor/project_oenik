using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using project.Domain.Models;
using project.Repository.Interfaces;
using project.WebAPI.Helpers;
using project.WebAPI.ViewModels;

namespace project.WebAPI.Controllers
{
    [Route("users")]
    public class AuthController : Controller
    {
        private readonly UserManager<User> _userManager;
        private readonly IConfiguration _configuration;
        private readonly IUserRepository<User> _userRepo;


        public AuthController(UserManager<User> userManager, IConfiguration configuration, IUserRepository<User> userRepo)
        {
            _userManager = userManager;
            _configuration = configuration;
            this._userRepo = userRepo;
        }

        [Route("register")]
        [Authorize(Roles = "Admin")]
        [HttpPost]
        public async Task<ActionResult> InsertUser([FromBody] RegisterViewModel model)
        {
            var currentUserName = this.User.FindFirst(ClaimTypes.NameIdentifier).Value;
            var registerData = Mappers.MapVMToRegisterData(model, currentUserName);
            var result = await _userRepo.RegisterUser(registerData);
            return Ok();
        }

        [Route("login")]
        [HttpPost]
        public async Task<ActionResult> Login([FromBody] LoginViewModel model)
        {
            var loginIP = this.Request.HttpContext.Connection.RemoteIpAddress.ToString();
            var loginData = Mappers.MapVMToLoginData(model, loginIP);
            var token = await _userRepo.Login(loginData);
            return Ok(
              new
              {
                  token = new JwtSecurityTokenHandler().WriteToken(token),
                  expiration = token.ValidTo
              });
        }

        [HttpGet]
        [Authorize(Roles = "Admin")]
        public async Task<IEnumerable<User>> List()
        {
            return await _userRepo.GetAll();
        }

        [HttpGet("{username}")]
        [Authorize(Roles = "Admin")]
        public async Task<User> GetUserByUsername(string username)
        {
            return await _userRepo.GetByName(username);
        }

        [HttpDelete("{uid}")]
        [Route("delete")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Delete(string uid)
        {
            await _userRepo.Delete(uid);
            return Ok();
        }

        [HttpPatch("{uid}")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Update(string uid, [FromBody] JsonPatchDocument<User> patchDoc)
        {
            if (patchDoc != null)
            {
                var user = await _userRepo.Get(uid);
                patchDoc.ApplyTo(user);
                user.ModifiedOn = DateTime.Now;
                await _userRepo.Update(user);
                return Ok(user);

            }
            else
            {
                return BadRequest();
            }
        }
    }
}