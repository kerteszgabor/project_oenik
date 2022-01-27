using AutoMapper;
using Microsoft.AspNetCore.JsonPatch;
using project.Domain.DTO.Courses;
using project.Domain.Interfaces;
using project.Domain.Models;
using project.Service.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace project.Service.Services
{
    class CourseService : ICourseService
    {
        private readonly ICourseRepository courseRepository;
        private readonly IQuestionRepository questionRepository;
        private readonly IUserService userService;
        public CourseService(ICourseRepository courseRepository, IUserService userService, IQuestionRepository questionRepository)
        {
            this.courseRepository = courseRepository;
            this.userService = userService;
            this.questionRepository = questionRepository;
        }

        public async Task<bool> Delete(string uid)
        {
            return await courseRepository.DeleteAsync(uid);
        }

        public async Task<Course> Get(string uid)
        {
            return await courseRepository.GetAsync(uid);
        }

        public async IAsyncEnumerable<Course> List()
        {
            await foreach (var item in courseRepository.GetAllAsync())
            {
                yield return item;
            }
        }

        public async Task<bool> Insert(CourseDTO newCourse)
        {
            if (newCourse != null)
            {
                var config = new MapperConfiguration(cfg =>
                {
                    cfg.CreateMap<CourseDTO, Course>();
                });
                IMapper iMapper = config.CreateMapper();

                var model = iMapper.Map<CourseDTO, Course>(newCourse);
                model.CreationTime = DateTime.Now;

                return await courseRepository.CreateAsync(model);
            }
            else
            {
                return false;
            }
        }

        public async Task<bool> Update(string uid, JsonPatchDocument<Course> patch)
        {
            if (patch != null)
            {
                var course = await courseRepository.GetAsync(uid);
                patch.ApplyTo(course);
                var result = await courseRepository.UpdateAsync(course);
                return result;
            }
            else
            {
                return false;
            }
        }

        public Task<bool> AddTestToCourse(string testID, string courseID)
        {
            throw new NotImplementedException();
        }

        public Task<bool> RemoveTestFromCourse(string testID, string courseID)
        {
            throw new NotImplementedException();
        }

        public Task<bool> EnrollStudentInCourse(string studentID, string courseID)
        {
            throw new NotImplementedException();
        }

        public Task<bool> RemoveStudentFromCourse(string studentID, string courseID)
        {
            throw new NotImplementedException();
        }
    }
}
