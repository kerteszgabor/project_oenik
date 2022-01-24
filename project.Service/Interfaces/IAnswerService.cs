using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using project.Domain.Models;

namespace project.Domain.Interfaces
{
    interface IAnswerService
    {
        Task<bool> Submit(Answer answer);
    }
}
