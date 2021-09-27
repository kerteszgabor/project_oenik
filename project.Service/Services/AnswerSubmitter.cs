using project.Domain.Interfaces;
using project.Domain.Models;
using project.Service.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace project.Service.Services
{
    class AnswerSubmitter : IAnswerSubmitter
    {
        private IAnswerRepository answerRepository;
        public AnswerSubmitter(IAnswerRepository answerRepository)
        {
            this.answerRepository = answerRepository;
        }

        public async Task<bool> Submit(Answer answer)
        {
            return true;
        }
    }
}
