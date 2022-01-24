using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using project.Domain.DTO.Tests;
using project.Domain.Models;
using project.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace project.WebAPI.Controllers
{
    [EnableCors("cors")]
    [Route("[controller]")]
    [ApiController]
    [Authorize]
    public class LabelsController : ControllerBase
    {
        private ILabelService labelService;
        public LabelsController(ILabelService labelService)
        {
            this.labelService = labelService;
        }
        // GET: api/Labels
        [HttpGet]
        public async Task<IEnumerable<QuestionLabel>> List()
        {
            return await labelService.List().ToListAsync();
        }

        //// GET: api/Tests/5
        //[HttpGet("{id}", Name = "Get")]
        //public async Task<Test> Get(string id)
        //{
        //    return await labelService.(id);
        //}

        // POST: api/Tests
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] LabelDTO model)
        {
            if (await labelService.Insert(model))
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
            if (await labelService.Delete(id))
            {
                return Ok();
            }
            else
            {
                return BadRequest();
            }
        }

        [HttpGet("getLabelledQuestions")]
        public async Task<IEnumerable<Question>> GetLabelledQuestions(string labelText)
        {
            return await labelService.GetQuestionsWithLabel(labelText).ToListAsync();
        }
    }
}
