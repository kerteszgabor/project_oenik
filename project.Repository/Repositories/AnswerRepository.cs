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
            await context.SaveChangesAsync();
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

        public async Task<bool> DeleteAsync(string id)
        {
            var answer = await GetAsync(id);
            if (answer != null)
            {
                context.Answers.Remove(answer);
                var result = await context.SaveChangesAsync();
                if (result > 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            else
            {
                return false;
            }
        }

        public async Task<bool> UpdateAsync(Answer entity)
        {
            if (entity.ID != null)
            {
                context.Answers.Remove(entity);
                var result = await context.SaveChangesAsync();
                if (result > 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            return false;
        }
    }
}
