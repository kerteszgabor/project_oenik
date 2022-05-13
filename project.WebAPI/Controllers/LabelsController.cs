using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using project.Domain.DTO.Tests;
using project.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using project.Service.Interfaces;

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

        [HttpGet]
        public async Task<IEnumerable<QuestionLabel>> List()
        {
            return await labelService.List().ToListAsync();
        }

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
