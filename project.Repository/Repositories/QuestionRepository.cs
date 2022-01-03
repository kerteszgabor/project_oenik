using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using project.Domain.Interfaces;
using project.Domain.Models;
using project.Repository.Data;

namespace project.Repository.Repositories
{
    public class QuestionRepository : IQuestionRepository
    {
        public ApplicationDbContext db { get; set; }

        public QuestionRepository(ApplicationDbContext db)
        {
            this.db = db;
        }
        public async Task<bool> CreateAsync(Question entity)
        {
            entity.ID = Guid.NewGuid().ToString();
            await db.Questions.AddAsync(entity);
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
            db.Questions.Remove(await GetAsync(id));
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

        public async IAsyncEnumerable<Question> GetAllAsync()
        {
            await foreach (var item in db.Questions.AsAsyncEnumerable())
                yield return item;
        }

        public async Task<Question> GetAsync(string id)
        {
            return await db.Questions
                .Include(x => x.TestQuestions)
                .FirstOrDefaultAsync(x => x.ID == id);
        }

        public async Task<bool> UpdateAsync(Question entity)
        {
            db.Questions.Update(entity);
            var result = await db.SaveChangesAsync();
            if (result > 0)
            {
                return true;
            }

            return false;
        }

        public async Task<bool> AddLabelAsync(QuestionLabel label)
        {
            label.ID = Guid.NewGuid().ToString();
            await db.QuestionLabels.AddAsync(label);
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

        public async Task<QuestionLabel> GetLabelAsync(string id)
        {
            return await db.QuestionLabels
                .Include(x => x.Question)
                .FirstOrDefaultAsync(x => x.ID == id);
        }

        public async Task<bool> DeleteLabelAsync(string id)
        {
            db.QuestionLabels.Remove(await GetLabelAsync(id));
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

        public async IAsyncEnumerable<QuestionLabel> GetAllLabelsAsync()
        {
            await foreach (var item in db.QuestionLabels.Include(x => x.Question).AsAsyncEnumerable())
                yield return item;
        }

    }
}
