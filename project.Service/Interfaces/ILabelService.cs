using project.Domain.DTO.Tests;
using project.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace project.Domain.Interfaces
{
    public interface ILabelService
    {
        Task<bool> Delete(string uid);
        IAsyncEnumerable<Question> GetQuestionsWithLabel(string labelText);
        Task<bool> Insert(LabelDTO newLabel);
        IAsyncEnumerable<QuestionLabel> List();
    }
}
