using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using kertesz_projekt_oenik.Data;
using kertesz_projekt_oenik.Exceptions;
using kertesz_projekt_oenik.Models;
using kertesz_projekt_oenik.Repositories;
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
        private readonly AuthorizationRepository _authRepo;


        public AuthController(UserManager<User> userManager, IConfiguration configuration)
        {
            _userManager = userManager;
            _configuration = configuration;
            this._authRepo = new AuthorizationRepository(_userManager, _configuration);
        }

        [Route("register")]
        [Authorize(Roles = "Admin")]
        [HttpPost]
        public async Task<ActionResult> InsertUser([FromBody] RegisterViewModel model)
        {
            try
            {
                var currentUserName = this.User.FindFirst(ClaimTypes.NameIdentifier).Value;
                var result = await _authRepo.InsertUser(model, currentUserName);
                return Ok();
            }
            catch (CannotAddUserException)
            {
                return BadRequest();
            }
        }

        [Route("login")]
        [HttpPost]
        public async Task<ActionResult> Login([FromBody] LoginViewModel model)
        {
            try
            {
                var loginIP = this.Request.HttpContext.Connection.RemoteIpAddress.ToString();
                var token = await _authRepo.Login(model, loginIP);
                return Ok(
                  new
                  {
                      token = new JwtSecurityTokenHandler().WriteToken(token),
                      expiration = token.ValidTo
                  });
            }
            catch (UserNotFoundException)
            {
                return Unauthorized();
            }
        }

        [HttpGet]
        [Authorize(Roles = "Admin")]
        public async Task<IEnumerable<User>> List()
        {
            return await _authRepo.List();
        }

        [HttpGet("{username}")]
        [Authorize(Roles = "Admin")]
        public async Task<User> GetUserByUsername(string username)
        {
            return await _authRepo.GetUserByUsername(username);
        }

        [HttpDelete("{uid}")]
        [Route("delete")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Delete(string uid)
        {
            try
            {
                await _authRepo.Delete(uid);
                return Ok();
            }
            catch (UserNotFoundException)
            {
                return BadRequest("User was not found");
            }
        }

        [HttpPatch("{uid}")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Update(string uid, [FromBody] JsonPatchDocument<User> patchDoc)
        {
            if (patchDoc != null)
            {
                try
                {
                    var user = await _authRepo.GetUserByID(uid);
                    patchDoc.ApplyTo(user);
                    user.ModifiedOn = DateTime.Now;
                    await _authRepo.Update(user);
                    return Ok(user);
                }
                catch (UserNotFoundException)
                {
                    return BadRequest("User was not found");
                }

            }
            else
            {
                return BadRequest();
            }
        }
    }
}