using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using project.Domain.Models;
using project.Service.Interfaces;
using project.Domain.DTO;

namespace project.WebAPI.Controllers
{
    [Route("users")]
    public class AuthController : Controller
    {
        private readonly IUserService userService;


        public AuthController(IUserService userService)
        {
            this.userService = userService;
        }

        [Route("register")]
        [Authorize(Roles = "Admin")]
        [HttpPost]
        public async Task<ActionResult> InsertUser([FromBody] RegisterData model)
        {
            var currentUserName = this.User.FindFirst(ClaimTypes.NameIdentifier).Value;
            model.RegisteringUserName = currentUserName;
            if (await userService.Register(model))
            {
                return Ok();
            }
            else
            {
                return BadRequest();
            }
        }

        [Route("login")]
        [HttpPost]
        public async Task<ActionResult> Login([FromBody] LoginData model)
        {
            var loginIP = this.Request.HttpContext.Connection.RemoteIpAddress.ToString();
            model.IPAddress = loginIP;
            var token = await userService.Login(model);
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
            return await userService.List();
        }

        [HttpGet("{username}")]
        [Authorize(Roles = "Admin")]
        public async Task<User> GetUserByUsername(string username)
        {
            return await userService.GetUserByName(username);
        }

        [HttpDelete("{uid}")]
        [Route("delete")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Delete(string uid)
        {
            await userService.Delete(uid);
            return Ok();
        }

        [HttpPatch("{uid}")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Update(string uid, [FromBody] JsonPatchDocument<User> patchDoc)
        {
            if (await userService.Update(uid, patchDoc))
            {
                return Ok();
            }
            else
            {
                return BadRequest();
            }
        }
    }
}