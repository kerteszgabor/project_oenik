using project.Domain.DTO.TestResults;
using project.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace project.Service.Interfaces
{
    public interface ITestManagerService
    {
        Task<TestResult> Get(string uid);
        IAsyncEnumerable<TestResult> GetAllResults();
        IAsyncEnumerable<TestResult> GetTestsOfUser(User user);
        IAsyncEnumerable<TestResult> GetTestsOfCourse(Course course);
        IAsyncEnumerable<TestResult> GetTestsOfUserInCourse(User user, Course course);
        Task<bool> SubmitAnswerToTestResult(AnswerDTO answer);
    }
}
