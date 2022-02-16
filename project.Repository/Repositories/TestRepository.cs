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
    public class TestRepository : ITestRepository<Test>
    {
        public ApplicationDbContext db { get; set; }

        public TestRepository(ApplicationDbContext db)
        {
            this.db = db;
        }
        public async Task<bool> CreateAsync(Test entity)
        {
            entity.ID = Guid.NewGuid().ToString();
            await db.Tests.AddAsync(entity);
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
            db.Tests.Remove(await GetAsync(id));
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

        public async IAsyncEnumerable<Test> GetAllAsync()
        {
            await foreach (var item in db.Tests.AsAsyncEnumerable())
            {
                yield return item;
            }
        }

        public async Task<Test> GetAsync(string id)
        {
            return await db.Tests
                .Include(x => x.TestQuestions)
                .ThenInclude(x => x.Question)
                .Include(x => x.TestProgQuestions)
                .FirstOrDefaultAsync(x => x.ID == id);
        }

        public async Task<bool> UpdateAsync(Test entity)
        {
            db.Tests.Update(entity);
            var result = await db.SaveChangesAsync();
            if (result > 0)
            {
                return true;
            }

            return false;
        }
    }
}
