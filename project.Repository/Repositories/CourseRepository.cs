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
    class CourseRepository : ICourseRepository
    {
        public ApplicationDbContext db { get; set; }

        public CourseRepository(ApplicationDbContext db)
        {
            this.db = db;
        }
        public async Task<bool> CreateAsync(Course entity)
        {
            entity.ID = Guid.NewGuid().ToString();
            await db.Courses.AddAsync(entity);
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
            db.Courses.Remove(await GetAsync(id));
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

        public async IAsyncEnumerable<Course> GetAllAsync()
        {
            await foreach (var item in db.Courses.AsAsyncEnumerable())
            {
                yield return item;
            }
        }

        public async Task<Course> GetAsync(string id)
        {
            return await db.Courses.FirstOrDefaultAsync(x => x.ID == id);
        }

        public async Task<bool> UpdateAsync(Course entity)
        {
            db.Courses.Update(entity);
            var result = await db.SaveChangesAsync();
            if (result > 0)
            {
                return true;
            }

            return false;
        }
    }
}
