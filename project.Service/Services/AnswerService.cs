using Microsoft.AspNetCore.JsonPatch;
using project.Domain.Interfaces;
using project.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using project.Service.Interfaces;

namespace project.Service.Services
{
    class AnswerService : IAnswerService
    {
        private IAnswerRepository answerRepository;
        public AnswerService(IAnswerRepository answerRepository)
        {
            this.answerRepository = answerRepository;
        }

        public async Task<bool> Submit(Answer answer)
        {
            return await answerRepository.CreateAsync(answer);
        }

        public async Task<bool> Delete(string uid)
        {
            return await answerRepository.DeleteAsync(uid);
        }

        public async Task<Answer> Get(string uid)
        {
            return await answerRepository.GetAsync(uid);
        }

        public async IAsyncEnumerable<Answer> List()
        {
            await foreach (var item in answerRepository.GetAllAsync())
                yield return item;
        }

        public async Task<bool> Update(string uid, JsonPatchDocument<Answer> patch)
        {
            if (patch != null)
            {
                var test = await answerRepository.GetAsync(uid);
                patch.ApplyTo(test);
                var result = await answerRepository.UpdateAsync(test);
                return result;
            }
            else
            {
                return false;
            }
        }
    }
}
