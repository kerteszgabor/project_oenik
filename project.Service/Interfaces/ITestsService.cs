using Microsoft.AspNetCore.JsonPatch;
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
        Task<bool> Update(string uid, JsonPatchDocument<Test> patch);
        Task<bool> AddQuestionToTest(string questionID, string testID);
        Task<bool> RemoveQuestionFromTest(string questionID, string testID);
    }
}