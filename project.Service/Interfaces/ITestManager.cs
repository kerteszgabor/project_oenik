using project.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace project.Service.Interfaces
{
    interface ITestManager
    {
        IAsyncEnumerable<TestResult> GetAllTests();
        IAsyncEnumerable<TestResult> GetTestsOfUser(User user);
        IAsyncEnumerable<TestResult> GetTestsOfCourse(Course course);
        IAsyncEnumerable<TestResult> GetTestsOfUserInCourse(User user, Course course);
    }
}
