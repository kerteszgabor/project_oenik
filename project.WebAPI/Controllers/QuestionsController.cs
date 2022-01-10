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
using project.Service.Services;

namespace project.WebAPI.Controllers
{
    [EnableCors("cors")]
    [Route("[controller]")]
    [ApiController]
    [Authorize]
    public class QuestionsController : ControllerBase
    {
        private IQuestionService questionService;
        public QuestionsController(IQuestionService questionService)
        {
            this.questionService = questionService;
        }
        // GET: api/Tests
        [HttpGet]
        public async Task<IEnumerable<Question>> List()
        {
            return await questionService.List().ToListAsync();
        }

        // GET: api/Tests/5
        [HttpGet("{id}", Name = "GetQuestion")]
        public async Task<Question> Get(string id)
        {
            return await questionService.Get(id);
        }

        
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] ProgQuestionDTO model)
        {
            model.CreatedBy = User.FindFirstValue(ClaimTypes.NameIdentifier);
            if (model?.ExpectedOutput == String.Empty)
            {
                var normalQuestion = model as QuestionDTO;
                if (await questionService.Insert(normalQuestion))
                {
                    return Ok();
                }
                else
                {
                    return BadRequest();
                }
            }
            if (await questionService.Insert(model))
            {
                return Ok();
            }
            else
            {
                return BadRequest();
            }
        }

        
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(string id)
        {
            if (await questionService.Delete(id))
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
        public async Task<IActionResult> Update(string uid, [FromBody] JsonPatchDocument<Question> patchDoc)
        {
            if (await questionService.Update(uid, patchDoc))
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
