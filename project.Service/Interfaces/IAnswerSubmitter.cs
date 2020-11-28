using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using project.Domain.Models;
using project.Repository.Interfaces;

namespace project.Service.Interfaces
{
    interface IAnswerSubmitter
    {
        Task<bool> Submit(Answer answer);
    }
}
