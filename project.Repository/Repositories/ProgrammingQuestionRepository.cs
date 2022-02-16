using project.Domain.Interfaces;
using project.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using project.Repository.Data;
using Microsoft.EntityFrameworkCore;

namespace project.Repository.Repositories
{
    public class ProgrammingQuestionRepository : IProgrammingQuestionRepository
    {
        public ApplicationDbContext db { get; set; }

        public ProgrammingQuestionRepository(ApplicationDbContext db)
        {
            this.db = db;
        }
        public async Task<bool> CreateAsync(ProgrammingQuestion entity)
        {
            entity.ID = Guid.NewGuid().ToString();
            await db.ProgrammingQuestions.AddAsync(entity);
            var result = await db.SaveChangesAsync();
            if (result > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public async Task<bool> DeleteAsync(string id)
        {
            db.ProgrammingQuestions.Remove(await GetAsync(id));
            var result = await db.SaveChangesAsync();
            if (result > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public async IAsyncEnumerable<ProgrammingQuestion> GetAllAsync()
        {
            await foreach (var item in db.ProgrammingQuestions.AsAsyncEnumerable())
            {
                yield return item;
            }
        }

        public async Task<ProgrammingQuestion> GetAsync(string id)
        {
            return await db.ProgrammingQuestions
                .Include(x => x.TestProgQuestions)
                .FirstOrDefaultAsync(x => x.ID == id);
        }

        public async Task<bool> UpdateAsync(ProgrammingQuestion entity)
        {
            db.Questions.Update(entity);
            var result = await db.SaveChangesAsync();
            if (result > 0)
            {
                return true;
            }

            return false;
        }
    }
}
