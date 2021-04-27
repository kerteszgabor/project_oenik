using Microsoft.EntityFrameworkCore;
using project.Domain.Interfaces;
using project.Domain.Models;
using project.Repository.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace project.Repository.Repositories
{
    class AnswerRepository : IAnswerRepository
    {
        public ApplicationDbContext context { get; set; }

        public AnswerRepository(ApplicationDbContext context)
        {
            this.context = context;
        }

        public async Task<bool> CreateAsync(Answer entity)
        {
            await context.Answers.AddAsync(entity);
            var result = GetAsync(entity.ID) == null ? false : true;
            return result;
        }

        public async Task<Answer> GetAsync(string id)
        {
            return await context.Answers.FindAsync(id);
        }

        public async IAsyncEnumerable<Answer> GetAllAsync()
        {
            await foreach (var item in context.Answers)
                yield return item;
        }

        public async Task<List<Answer>> GetAllAnswersOfQuestionOfTest(Question question, Test test)
        {
            return await context.TestResults
                .Include(x => x.Answers)
                .AsQueryable()
                .FirstOrDefaultAsync(x => x.Test.ID == test.ID).Result
                .Answers
                .Where(x => x.Question.ID == question.ID)
                .AsQueryable()
                .ToListAsync();
        }

        public Task<bool> DeleteAsync(string id)
        {
            throw new NotImplementedException();
        }

        public Task<bool> UpdateAsync(Answer entity)
        {
            throw new NotImplementedException();
        }
    }
}
