using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Json.Patch;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
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

        [HttpPost("update/{uid}")]
        [Authorize]
        public async Task<IActionResult> Update(string uid, [FromBody] JsonPatch patchDoc)
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

        [HttpGet("OwnTests")]
        [Authorize]
        public async Task<IEnumerable<Test>> GetOwnTests()
        {
            var idOfCaller = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            return await testsService.GetTestsOfUser(idOfCaller).ToListAsync();
        }

        [HttpGet("GetTestsOfCourse/{courseID}")]
        [Authorize]
        public async Task<IEnumerable<Test>> GetTestsOfCourse(string courseID)
        {
            return await testsService.GetTestsOfCourse(courseID).ToListAsync();
        }

        [HttpGet("GetQuestionsOfTest")]
        public async Task<IEnumerable<Question>> GetQuestionsOfTest(string testID)
        {
            var questions = await testsService.GetQuestionsOfTest(testID).ToListAsync();
            questions.ForEach(x => x.CorrectAnswer = string.Empty);
            return questions;
        }
    }
}
