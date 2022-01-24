using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using project.Domain.DTO.TestResults;
using project.Domain.Models;
using project.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace project.WebAPI.Controllers
{
    [EnableCors("cors")]
    [Route("[controller]")]
    [ApiController]
    [Authorize]
    public class TestManagerController : ControllerBase
    {
        private ITestManagerService testManagerService;
        private IUserService userService;
        public TestManagerController(ITestManagerService testManagerService, IUserService userService)
        {
            this.testManagerService = testManagerService;
            this.userService = userService;
        }
        // GET: api/Tests
        [HttpGet]
        public async Task<IEnumerable<TestResult>> List()
        {
            return await testManagerService.GetAllResults().ToListAsync();
        }

        // POST: api/Tests
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] AnswerDTO model)
        {
            model.User = await userService.GetUserByName(User.FindFirstValue(ClaimTypes.NameIdentifier));
            if (await testManagerService.SubmitAnswerToTestResult(model))
            {
                return Ok();
            }
            else
            {
                return BadRequest();
            }
        }

        [HttpPost]
        public async Task<IActionResult> StartTestCompletion([FromBody] TestStartDTO model)
        {
            model.User = await userService.GetUserByName(User.FindFirstValue(ClaimTypes.NameIdentifier));
            if (await testManagerService.StartTestCompletion(model))
            {
                return Ok();
            }
            else
            {
                return BadRequest();
            }
        }

        // GET: api/Tests/5
        [HttpGet("{id}")]
        public async Task<TestResult> Get(string id)
        {
            return await testManagerService.Get(id);
        }


        //// DELETE: api/ApiWithActions/5
        //[HttpDelete("{id}")]
        //public async Task<IActionResult> Delete(string id)
        //{
        //    if (await testManagerService.Delete(id))
        //    {
        //        return Ok();
        //    }
        //    else
        //    {
        //        return BadRequest();
        //    }
        //}

        //[HttpPatch("{uid}")]
        ////  [Authorize(Roles = "Admin")]
        //public async Task<IActionResult> Update(string uid, [FromBody] JsonPatchDocument<Test> patchDoc)
        //{
        //    if (await testManagerService.Update(uid, patchDoc))
        //    {
        //        return Ok();
        //    }
        //    else
        //    {
        //        return BadRequest();
        //    }
        //}
    }
}
