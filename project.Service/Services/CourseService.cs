using AutoMapper;
using Microsoft.AspNetCore.JsonPatch;
using project.Domain.DTO.Courses;
using project.Domain.Interfaces;
using project.Domain.Models;
using project.Domain.Models.DBConnections;
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
        private readonly ITestRepository<Test> testRepository;
        private readonly IUserRepository<User> userRepository;

        public CourseService(ICourseRepository courseRepository, ITestRepository<Test> testRepository, IUserRepository<User> userRepository)
        {
            this.courseRepository = courseRepository;
            this.testRepository = testRepository;
            this.userRepository = userRepository;
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

                if (await courseRepository.CreateAsync(model))
                {
                    string createdCourseID = (await courseRepository
                        .GetAllAsync()
                        .FirstOrDefaultAsync(x => x.Name == newCourse.CourseName))?
                        .ID;
                    await EnrollStudentInCourse(newCourse.TeacherID, createdCourseID);
                    return true;
                }

                return false;
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

        public async Task<bool> AddTestToCourse(string testID, string courseID)
        {
            var test = await testRepository.GetAsync(testID);
            var course = await Get(courseID);

            course.CourseTests.Add(new CourseTest()
            {
                Course = course,
                Test = test,
                TestID = test.ID,
                CourseID = course.ID,
                ID = Guid.NewGuid().ToString()
            });

            return await courseRepository.UpdateAsync(course);
        }

        public async Task<bool> RemoveTestFromCourse(string testID, string courseID)
        {
            var testToDelete = await testRepository.GetAsync(testID);
            var courseToUpdate = await Get(courseID);
            var linkingEntity = courseToUpdate.CourseTests.FirstOrDefault(x => x.Test == testToDelete);

            courseToUpdate.CourseTests.Remove(linkingEntity);
            testToDelete.CourseTests.Remove(linkingEntity);

            return await courseRepository.UpdateAsync(courseToUpdate);
        }

        public async Task<bool> EnrollStudentInCourse(string studentID, string courseID)
        {
            var student = await userRepository.GetAsync(studentID);
            var course = await Get(courseID);

            course.UserCourses.Add(new UserCourse()
            {
                ID = Guid.NewGuid().ToString(),
                Course = course,
                CourseID = course.ID,
                User = student,
                UserID = student.Id
            });

            return await courseRepository.UpdateAsync(course);
        }

        public async Task<bool> RemoveStudentFromCourse(string studentID, string courseID)
        {
            var studentToDelete = await userRepository.GetAsync(studentID);
            var courseToUpdate = await Get(courseID);
            var linkingEntity = courseToUpdate.UserCourses.FirstOrDefault(x => x.User == studentToDelete);

            courseToUpdate.UserCourses.Remove(linkingEntity);
            studentToDelete.UserCourses.Remove(linkingEntity);

            return await courseRepository.UpdateAsync(courseToUpdate);
        }
    }
}
