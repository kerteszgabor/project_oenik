using project.Domain.DTO.TestResults;
using project.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace project.Service.Interfaces
{
    public interface ITestManagerService
    {
        Task<bool> SubmitAnswerToTestResult(AnswerDTO answer);
        Task<bool> StartTestCompletion(TestStartStopDTO startDTO);
        Task EndTestCompletion(TestStartStopDTO stopDTO);
    }
}
