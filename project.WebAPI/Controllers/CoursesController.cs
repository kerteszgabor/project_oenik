﻿using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using project.Domain.DTO.Courses;
using project.Domain.Models;
using project.Service.Interfaces;
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
    public class CoursesController : ControllerBase
    {
        private ICourseService courseService;
        public CoursesController(ICourseService courseService)
        {
            this.courseService = courseService;
        }

        [HttpGet]
        public async Task<IEnumerable<Course>> List()
        {
            return await courseService.List().ToListAsync();
        }


        [HttpGet("{id}")]
        public async Task<Course> Get(string id)
        {
            return await courseService.Get(id);
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] CourseDTO model)
        {
            if (await courseService.Insert(model))
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
            if (await courseService.Delete(id))
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
        public async Task<IActionResult> Update(string uid, [FromBody] JsonPatchDocument<Course> patchDoc)
        {
            if (await courseService.Update(uid, patchDoc))
            {
                return Ok();
            }
            else
            {
                return BadRequest();
            }
        }

        [HttpGet("addTestToCourse")]
        public async Task<IActionResult> AddTestToCourse(string testID, string courseID)
        {
            if (await courseService.AddTestToCourse(testID, courseID))
            {
                return Ok();
            }
            else
            {
                return BadRequest();
            }
        }

        [HttpGet("removeTestFromCourse")]
        public async Task<IActionResult> RemoveQuestionFromCourse(string testID, string courseID)
        {
            if (await courseService.RemoveTestFromCourse(testID, courseID))
            {
                return Ok();
            }
            else
            {
                return BadRequest();
            }
        }

        [HttpGet("enrollStudentInCourse")]
        public async Task<IActionResult> EnrollStudentInCourse(string studentID, string courseID)
        {
            if (await courseService.EnrollStudentInCourse(studentID, courseID))
            {
                return Ok();
            }
            else
            {
                return BadRequest();
            }
        }

        [HttpGet("removeStudentFromCourse")]
        public async Task<IActionResult> RemoveStudentFromCourse(string studentID, string courseID)
        {
            if (await courseService.RemoveStudentFromCourse(studentID, courseID))
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