using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.JsonPatch;
using project.Domain.Interfaces;
using project.Domain.Models;
using project.Service.Interfaces;

namespace project.Service.Services
{
    public class ResultManagerService : IResultManagerService
    {
        private ITestResultRepository testResultRepository;
        private readonly ITestsService testsService;
        private readonly ICourseService courseService;
        private readonly IUserRepository<User> userRepository;
        public ResultManagerService(ITestResultRepository testResultRepository, ITestsService testsService, ICourseService courseService, IUserRepository<User> userRepository)
        {
            this.testResultRepository = testResultRepository;
            this.testsService = testsService;
            this.courseService = courseService;
            this.userRepository = userRepository;
        }

        public async Task<TestResult> Get(string uid)
        {
            return await testResultRepository.GetAsync(uid);
        }

        public async IAsyncEnumerable<TestResult> GetAllResults()
        {
            await foreach (var item in testResultRepository.GetAllAsync())
            {
                yield return item;
            }
        }

        public async IAsyncEnumerable<TestResult> GetTestResultOfUserOfTest(string userID, string testID)
        {
            var test = await testsService.Get(testID);
            var results = GetTestResultsOfUser(userID).Where(x => x.Test == test);
            await foreach (var item in results)
            {
                yield return item;
            }
        }

        public async IAsyncEnumerable<TestResult> GetTestResultsOfTestOfCourse(string courseID, string testID)
        {
            //var tests = testsService.GetTestsOfCourse(courseID).FirstOrDefaultAsync(x => x.ID == testID);
            //var results = GetAllResults().Where(x => x.Test.ID == testID && x.Course.ID == courseID);
            //await foreach (var item in tests)
            //{
            //    yield return await results.FirstOrDefaultAsync(x => x.Test == item);
            //}

            await foreach (var item in GetAllResults().Where(x => x.Test.ID == testID && x.Course.ID == courseID))
            {
                yield return item;
            }
        }

        public async IAsyncEnumerable<TestResult> GetTestResultsOfUser(string userID)
        {
            var user = await userRepository.GetAsync(userID);
            var results = GetAllResults().Where(x => x.User == user);
            await foreach (var item in results)
            {
                yield return item;
            }
        }

        public async Task<bool> Delete(string uid)
        {
            return await testResultRepository.DeleteAsync(uid);
        }

        public async Task<bool> Update(string uid, JsonPatchDocument<TestResult> patch)
        {
            if (patch != null)
            {
                var test = await testResultRepository.GetAsync(uid);
                patch.ApplyTo(test);
                var result = await testResultRepository.UpdateAsync(test);
                return result;
            }
            else
            {
                return false;
            }
        }
    }
}
