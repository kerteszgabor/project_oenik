using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using project.Domain.Models;
using project.Service.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace project.WebAPI.Controllers
{
    [ApiController]
    [EnableCors("cors")]
    [Route("[controller]")]
    [Authorize]
    public class ResultsController : ControllerBase
    {
        private IResultManagerService resultManagerService;
        public ResultsController(IResultManagerService resultManagerService)
        {
            this.resultManagerService = resultManagerService;
        }

        [HttpGet]
        public async Task<IEnumerable<TestResult>> List()
        {
            return await resultManagerService.GetAllResults().ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<TestResult> Get(string id)
        {
            return await resultManagerService.Get(id);
        }


        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(string id)
        {
            if (await resultManagerService.Delete(id))
            {
                return Ok();
            }
            else
            {
                return BadRequest();
            }

        }

        [HttpPatch("{uid}")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Update(string uid, [FromBody] JsonPatchDocument<TestResult> patchDoc)
        {
            if (await resultManagerService.Update(uid, patchDoc))
            {
                return Ok();
            }
            else
            {
                return BadRequest();
            }
        }

        [HttpGet("userResults")]
        public async Task<IEnumerable<TestResult>> GetTestResultsOfUser(string userID)
        {
            return await resultManagerService.GetTestResultsOfUser(userID).ToListAsync();
        }

        [HttpGet("userResultsOfTest")]
        public async Task<IEnumerable<TestResult>> GetTestResultOfUserOfTest(string userID, string testID)
        {
            return await resultManagerService.GetTestResultOfUserOfTest(userID, testID).ToListAsync();
        }

        [HttpGet("testResultsOfCourse")]
        public async Task<IEnumerable<TestResult>> GetTestResultsOfTestOfCourse(string courseID, string testID)
        {
            return await resultManagerService.GetTestResultsOfTestOfCourse(courseID, testID).ToListAsync();
        }
    }
}
