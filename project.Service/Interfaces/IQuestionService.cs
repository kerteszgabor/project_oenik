using Microsoft.AspNetCore.JsonPatch;
using project.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using project.Domain.DTO.Tests;

namespace project.Service.Interfaces
{
    public interface IQuestionService
    {
        Task<bool> Delete(string uid);
        Task<Question> Get(string uid);
        Task<bool> Insert(QuestionDTO newQuestion);
        IAsyncEnumerable<Question> List();
        Task<bool> Update(string uid, JsonPatchDocument<Question> patch);
    }
}
