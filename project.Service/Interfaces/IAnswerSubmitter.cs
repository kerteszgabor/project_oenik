using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using project.Domain.Models;

namespace project.Service.Interfaces
{
    interface IAnswerSubmitter
    {
        Task<bool> Submit(Answer answer);
    }
}
