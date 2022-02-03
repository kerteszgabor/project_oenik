﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
            var tests = testsService.GetTestsOfCourse(courseID).Where(x => x.ID == testID);
            var results = GetAllResults();
            await foreach (var item in tests)
            {
                yield return await results.FirstOrDefaultAsync(x => x.Test == item);
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
    }
}
