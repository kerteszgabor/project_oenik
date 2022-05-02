using Json.Patch;
using project.Domain.DTO.TestResults;
using project.Domain.DTO.Tests;
using project.Domain.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace project.Client.Services
{
    public class TestsService : ServiceBase
    {
        public TestsService(string url)
        {
            BaseURL = url;
        }

        public async Task<IEnumerable<Test>> GetAllTestsAsync()
        {
            var response = await Client.GetProtectedAsync<IEnumerable<Test>>($"{BaseURL}/tests");
            return response.Result;
        }

        public async Task<IEnumerable<Test>> GetOwnTestsAsync()
        {
            var response = await Client.GetProtectedAsync<IEnumerable<Test>>($"{BaseURL}/tests/OwnTests");
            return response.Result;
        }

        public async Task<Test> GetTestAsync(string id)
        {
            var response = await Client.GetProtectedAsync<Test>($"{BaseURL}/tests/{id}");
            return response.Result;
        }

        public async Task<bool> DeleteTestAsync(string id)
        {
            var response = await Client.DeleteProtectedAsync<Test>($"{BaseURL}/tests/{id}");
            return response.IsSucceded;
        }

        public async Task<bool> AddTestAsync(TestDTO testDTO)
        {
            var response = await Client.PostProtectedAsync<Test>($"{BaseURL}/tests/", testDTO);
            if (response.IsSucceded)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public async Task<bool> UpdateTestAsync(string id, JsonPatch patch)
        {
            var response = await Client.PostProtectedAsync<Test>($"{BaseURL}/tests/update/{id}", patch);
            var responsestr = response.ToString();
            var responsestr2 = response.HttpResponse.ToString();
            return response.IsSucceded;
        }

        public async Task<IEnumerable<Test>> GetTestsOfCourse(string courseID)
        {
            var response = await Client.GetProtectedAsync<IEnumerable<Test>>($"{BaseURL}/tests/GetTestsOfCourse/{courseID}");
            return response.Result;
        }

        public async Task<IEnumerable<Test>> GetOwnTests()
        {
            var response = await Client.GetProtectedAsync<IEnumerable<Test>>($"{BaseURL}/tests/OwnTests");
            return response.Result;
        }

        public async Task<IEnumerable<Question>> GetQuestionsOfTest(string testID)
        {
            var response = await Client.GetProtectedAsync<IEnumerable<Question>>($"{BaseURL}/tests/GetQuestionsOfTest?testID={testID}");
            return response.Result;
        }

        public async Task<bool> ToogleTestStatus(string testID, string courseID)
        {
            var response = await Client.GetProtectedAsync<Test>($"{BaseURL}/TestManager/ToogleTestStatus?testID={testID}&courseID={courseID}");
            return response.IsSucceded;
        }

        public async Task<bool> RemoveTestFromCourse(string testID, string courseID)
        {
            var response = await Client.GetProtectedAsync<Test>($"{BaseURL}/courses/removeTestFromCourse?testID={testID}&courseID={courseID}");
            return response.IsSucceded;
        }

        public async Task<bool> StartTestCompletion(string testID, string courseID)
        {
            TestStartStopDTO start = new TestStartStopDTO()
            {
                CourseID = courseID,
                TestID = testID
            };
            var response = await Client.PostProtectedAsync<Test>($"{BaseURL}/TestManager/StartCompletion", start);
            return response.IsSucceded;
        }

        public async Task<bool> SubmitAnswer(AnswerDTO answerDTO)
        {
            var response = await Client.PostProtectedAsync<Test>($"{BaseURL}/TestManager/", answerDTO);
            return response.IsSucceded;
        }
    }
}
