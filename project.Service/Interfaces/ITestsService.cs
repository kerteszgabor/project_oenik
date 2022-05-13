using Json.Patch;
using project.Domain.DTO.Tests;
using project.Domain.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace project.Service.Interfaces
{
    public interface ITestsService
    {
        Task<bool> Delete(string uid);
        Task<Test> Get(string uid);
        Task<bool> Insert(TestDTO newTest);
        IAsyncEnumerable<Test> List();
        Task<bool> Update(string uid, JsonPatch patch);
        Task<bool> AddQuestionToTest(string questionID, string testID);
        Task<bool> RemoveQuestionFromTest(string questionID, string testID);
        IAsyncEnumerable<Test> GetTestsOfUser(string userID);
        IAsyncEnumerable<Test> GetTestsOfCourse(string courseID);
        IAsyncEnumerable<Question> GetQuestionsOfTest(string testID);
    }
}