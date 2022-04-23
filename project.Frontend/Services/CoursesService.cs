using AKSoftware.WebApi.Client;
using project.Domain.DTO.Client;
using project.Domain.DTO.Courses;
using project.Domain.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace project.Client.Services
{
    public class CoursesService : ServiceBase
    {
        public CoursesService(string url)
        {
            BaseURL = url;
        }

        public async Task<IEnumerable<Course>> GetAllCoursesAsync()
        {
            var response = await Client.GetProtectedAsync<IEnumerable<Course>>($"{BaseURL}/courses");
            return response.Result;
        }

        public async Task<IEnumerable<Course>> GetOwnCoursesAsync()
        {
            var response = await Client.GetProtectedAsync<IEnumerable<Course>>($"{BaseURL}/courses/OwnCourses");
            return response.Result;
        }

        public async Task<Course> GetCourseAsync(string id)
        {
            var response = await Client.GetProtectedAsync<Course>($"{BaseURL}/courses/{id}");
            return response.Result;
        }

        public async Task<bool> DeleteCourseAsync(string id)
        {
            var response = await Client.DeleteProtectedAsync<Course>($"{BaseURL}/courses/{id}");
            return response.IsSucceded;
        }

        public async Task<bool> AddCourseAsync(CourseDTO courseDTO)
        {
            var response = await Client.PostProtectedAsync<Course>($"{BaseURL}/courses/", courseDTO);
            if (response.IsSucceded)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public async Task<Course> UpdateCourseAsync(string id)
        {
            var response = await Client.GetProtectedAsync<Course>($"{BaseURL}/courses/{id}");
            return response.Result;
        }

        public async Task<bool> EnrollUserInCourse(string userId, string courseID)
        {
            var response = await Client.GetProtectedAsync<Course>($"{BaseURL}/courses/enrollStudentInCourse/?studentID={userId}&courseID={courseID}");
            return response.IsSucceded;
        }

        //public async Task<bool> AddTestToCourse(string testID, string courseID)
        //{
        //    var response = await Client.GetProtectedAsync<Course>($"{BaseURL}/Courses/addTestToCourse/?testID={testID}&courseID={courseID}");
        //    return response.IsSucceded;
        //}

        public async Task<bool> AddTestToCourse(TestInCourseDTO model)
        {
            var response = await Client.PostProtectedAsync<Course>($"{BaseURL}/Courses/addTestToCourse/", model);
            return response.IsSucceded;
        }
    }
}
