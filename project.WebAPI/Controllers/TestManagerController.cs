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
using project.Service.Interfaces;

namespace project.WebAPI.Controllers
{
    [EnableCors("cors")]
    [Route("[controller]")]
    [ApiController]
    [Authorize]
    public class TestManagerController : ControllerBase
    {
        private ITestManagerService testManagerService;
        private IResultManagerService resultManagerService;
        private IUserService userService;
        public TestManagerController(ITestManagerService testManagerService, IUserService userService, IResultManagerService resultManagerService)
        {
            this.testManagerService = testManagerService;
            this.userService = userService;
            this.resultManagerService = resultManagerService;
        }

        [HttpGet]
        public async Task<IEnumerable<TestResult>> List()
        {
            return await resultManagerService.GetAllResults().ToListAsync();
        }


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

        [HttpPost("StartCompletion")]
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


        [HttpGet("{id}")]
        public async Task<TestResult> Get(string id)
        {
            return await resultManagerService.Get(id);
        }
    }
}
