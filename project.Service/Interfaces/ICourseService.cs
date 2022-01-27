using Microsoft.AspNetCore.JsonPatch;
using project.Domain.DTO.Courses;
using project.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace project.Service.Interfaces
{
    public interface ICourseService
    {
        Task<bool> Delete(string uid);
        Task<Course> Get(string uid);
        Task<bool> Insert(CourseDTO newCourse);
        IAsyncEnumerable<Course> List();
        Task<bool> Update(string uid, JsonPatchDocument<Course> patch);
        Task<bool> AddTestToCourse(string testID, string courseID);
        Task<bool> RemoveTestFromCourse(string testID, string courseID);
        Task<bool> EnrollStudentInCourse(string studentID, string courseID);
        Task<bool> RemoveStudentFromCourse(string studentID, string courseID);

    }
}
