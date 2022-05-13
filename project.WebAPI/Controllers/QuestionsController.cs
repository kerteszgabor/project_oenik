using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using AutoMapper;
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
    public class QuestionsController : ControllerBase
    {
        private IQuestionService questionService;
        private IUserService userService;

        public QuestionsController(IQuestionService questionService, IUserService userService)
        {
            this.questionService = questionService;
            this.userService = userService;
        }

        [HttpGet]
        public async Task<IEnumerable<Question>> List()
        {
            return await questionService.List().ToListAsync();
        }

        [HttpGet("{id}", Name = "GetQuestion")]
        public async Task<Question> Get(string id)
        {
            return await questionService.Get(id);
        }

        
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] ProgQuestionDTO model)
        {
            model.CreatedBy = await userService.Get(User.FindFirstValue(ClaimTypes.NameIdentifier));
            if (model?.Methods == null || model?.Methods?.Count == 0)
            {
                var normalQuestion = new MapperConfiguration(cfg =>
                {
                    cfg.CreateMap<ProgQuestionDTO, QuestionDTO>();
                })
                    .CreateMapper()
                    .Map<ProgQuestionDTO, QuestionDTO>(model);

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

        [HttpGet("OwnQuestions")]
        [Authorize]
        public async Task<IEnumerable<Question>> GetOwnQuestions()
        {
            var idOfCaller = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            return await questionService.GetQuestionsOfUser(idOfCaller).ToListAsync();
        }

        [HttpGet("SharedQuestions")]
        [Authorize]
        public async Task<IEnumerable<Question>> GetSharedQuestions()
        {
            return await questionService.List().Where(x => x.IsShared).ToListAsync();
        }
    }
}
