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
    public class TestResultRepository : ITestResultRepository
    {
        public ApplicationDbContext db { get; set; }

        public TestResultRepository(ApplicationDbContext db)
        {
            this.db = db;
        }

        public async Task<bool> CreateAsync(TestResult entity)
        {
            entity.ID = Guid.NewGuid().ToString();
            await db.TestResults.AddAsync(entity);
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
            db.TestResults.Remove(await GetAsync(id));
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

        public async IAsyncEnumerable<TestResult> GetAllAsync()
        {
            await foreach (var item in db.TestResults.Include(x => x.Test).AsAsyncEnumerable())
            {
                yield return item;
            }
        }

        public async Task<TestResult> GetAsync(string id)
        {
            return await db.TestResults
                .Include(x => x.Answers)
                .ThenInclude(x => x.Question)
                .Include(x => x.Course)
                .Include(x => x.User)
                .FirstOrDefaultAsync(x => x.ID == id);
        }

        public async Task<bool> UpdateAsync(TestResult entity)
        {
            db.TestResults.Update(entity);
            var result = await db.SaveChangesAsync();
            if (result > 0)
            {
                return true;
            }

            return false;
        }
    }
}
