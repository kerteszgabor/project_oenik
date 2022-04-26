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
        public async Task<Test> UpdateTestAsync(string id)
        {
            var response = await Client.GetProtectedAsync<Test>($"{BaseURL}/tests/{id}");
            return response.Result;
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

        public async Task<bool> ToogleTestStatus(string testID, string courseID)
        {
            var response = await Client.GetProtectedAsync<Test>($"{BaseURL}/TestManager/ToogleTestStatus?testID={testID}&courseID={courseID}");
            return response.IsSucceded;
        }
    }
}
