using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using project.Domain.DTO.Tests;
using project.Domain.Models;
using project.Service.Interfaces;

namespace project.WebAPI.Controllers
{
    [EnableCors("cors")]
    [Route("[controller]")]
    [ApiController]
    [Authorize]
    public class TestsController : ControllerBase
    {
        private ITestsService testsService;
        public TestsController(ITestsService testsService)
        {
            this.testsService = testsService;
        }
        // GET: api/Tests
        [HttpGet]
        public async Task<IEnumerable<Test>> List()
        {
            return await testsService.List().ToListAsync();
        }

        // GET: api/Tests/5
        [HttpGet("{id}", Name = "Get")]
        public async Task<Test> Get(string id)
        {
            return await testsService.Get(id);
        }

        // POST: api/Tests
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] TestDTO model)
        {
            model.CreatedBy = User.FindFirstValue(ClaimTypes.NameIdentifier);
            if (await testsService.Insert(model))
            {
                return Ok();
            }
            else
            {
                return BadRequest();
            }
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(string id)
        {
            if (await testsService.Delete(id))
            {
                return Ok();
            }
            else
            {
                return BadRequest();
            }
        }

        [HttpPatch("{uid}")]
      //  [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Update(string uid, [FromBody] JsonPatchDocument<Test> patchDoc)
        {
            if (await testsService.Update(uid, patchDoc))
            {
                return Ok();
            }
            else
            {
                return BadRequest();
            }
        }

        [HttpGet("addQuestionToTest")]
        public async Task<IActionResult> AddQuestionToTest(string questionID, string testID)
        {
            if (await testsService.AddQuestionToTest(questionID, testID))
            {
                return Ok();
            }
            else
            {
                return BadRequest();
            }
        }

        [HttpGet("removeQuestionFromTest")]
        public async Task<IActionResult> RemoveQuestionFromTest(string questionID, string testID)
        {
            if (await testsService.RemoveQuestionFromTest(questionID, testID))
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
