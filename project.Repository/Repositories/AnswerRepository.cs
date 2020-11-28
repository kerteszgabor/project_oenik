using project.Domain.Models;
using project.Repository.Data;
using project.Repository.Interfaces;
using System;
using System.Collections.Generic;
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

        public async Task<bool> Create(Answer entity)
        {
            await context.Answers.AddAsync(entity);
            var result = Get(entity.ID) == null ? false : true;
            return result;
        }

        public async Task<Answer> Get(string id)
        {
            return await context.Answers.FindAsync(id);
        }

        public async IAsyncEnumerable<Answer> GetAll()
        {
            await foreach (var item in context.Answers)
                yield return item;
        }
    }
}
