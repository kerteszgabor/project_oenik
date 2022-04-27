using AutoMapper;
using project.Domain.DTO.Tests;
using project.Domain.Interfaces;
using project.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using project.Domain.Models.DBConnections;
using project.Service.Interfaces;
using Json.Patch;

namespace project.Service.Services
{
    public class TestsService : ITestsService
    {
        private readonly ITestRepository<Test> testRepository;
        private readonly IQuestionRepository questionRepository;
        private readonly IUserService userService;
        private readonly ICourseService courseService;
        public TestsService(ITestRepository<Test> testRepository, IUserService userService, IQuestionRepository questionRepository, ICourseService courseService)
        {
            this.testRepository = testRepository;
            this.userService = userService;
            this.questionRepository = questionRepository;
            this.courseService = courseService;
        }

        public async Task<bool> Delete(string uid)
        {
            return await testRepository.DeleteAsync(uid);
        }

        public async Task<Test> Get(string uid)
        {
            return await testRepository.GetAsync(uid);
        }

        public async IAsyncEnumerable<Test> List()
        {
            await foreach (var item in testRepository.GetAllAsync())
            {
                yield return item;
            }
        }

        public async IAsyncEnumerable<Test> GetTestsOfUser(string userID)
        {
            var userTests = new List<Test>();

            await foreach (var course in courseService.GetCoursesOfUser(userID))
            {
                if (course.CourseTests is not null)
                {
                    userTests.AddRange(course.CourseTests
                        .SelectMany(x => x.Course?.CourseTests)?
                        .Select(x => x?.Test));
                }
            }

            await foreach (var item in userTests.ToAsyncEnumerable())
            {
                yield return item;
            }
        }

        public async IAsyncEnumerable<Test> GetTestsOfCourse(string courseID)
        {
            var courseTests = (await courseService.Get(courseID))?
                .CourseTests
                .Select(x => x.Test)
                .ToAsyncEnumerable();

            await foreach (var item in courseTests)
            {
                yield return item;
            }
        }

        public async Task<bool> Insert(TestDTO newTest)
        {
            if (newTest != null)
            {
                var config = new MapperConfiguration(cfg =>
                {
                    cfg.CreateMap<TestDTO, Test>();
                    cfg.AddGlobalIgnore("CreatedBy");
                });
                IMapper iMapper = config.CreateMapper();

                var model = iMapper.Map<TestDTO, Test>(newTest);
                model.CreatedBy = await userService.Get(newTest.CreatedBy);
                model.CreationTime = DateTime.Now;

                return await testRepository.CreateAsync(model);
            }
            else
            {
                return false;
            }
        }

        public async Task<bool> Update(string uid, JsonPatch patch)
        {
            if (patch != null)
            {
                var test = await testRepository.GetAsync(uid);
                patch.Apply(test);
                var result = await testRepository.UpdateAsync(test);
                return result;
            }
            else
            {
                return false;
            }
        }

        public async Task<bool> AddQuestionToTest(string questionID, string testID)
        {
            var questionToAdd = await questionRepository.GetAsync(questionID);
            var testToUpdate = await Get(testID);

            if (!testToUpdate.TestQuestions.Any(x => x.QuestionID == questionID && x.TestID == testID))
            {
                testToUpdate.MaxPoints += questionToAdd.MaxPoints;

                testToUpdate.TestQuestions.Add(new TestQuestion
                {
                    Question = questionToAdd,
                    Test = testToUpdate,
                    ID = Guid.NewGuid().ToString(),
                    QuestionID = questionToAdd.ID,
                    TestID = testToUpdate.ID
                });

                return await testRepository.UpdateAsync(testToUpdate);
            }

            return false;
        }

        public async Task<bool> RemoveQuestionFromTest(string questionID, string testID)
        {
            var questionToDelete = await questionRepository.GetAsync(questionID);
            var testToUpdate = await Get(testID);
            var linkingEntity = testToUpdate.TestQuestions.FirstOrDefault(x => x.Question == questionToDelete);

            testToUpdate.MaxPoints -= questionToDelete.MaxPoints;

            testToUpdate.TestQuestions.Remove(linkingEntity);
            questionToDelete.TestQuestions.Remove(linkingEntity);

            return await testRepository.UpdateAsync(testToUpdate);
        }
    }
}
