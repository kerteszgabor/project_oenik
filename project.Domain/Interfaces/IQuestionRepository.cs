using project.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace project.Domain.Interfaces
{
    public interface IQuestionRepository : IRepository<Question>
    {
        Task<bool> AddLabelAsync(QuestionLabel label);
        IAsyncEnumerable<QuestionLabel> GetAllLabelsAsync();
        Task<QuestionLabel> GetLabelAsync(string id);
        Task<bool> DeleteLabelAsync(string id);
    }
}
