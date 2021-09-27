using project.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace project.Domain.Interfaces
{
    public interface IRepository<T> 
    {
        Task<T> GetAsync(string id);
        IAsyncEnumerable<T> GetAllAsync();
        Task<bool> CreateAsync(T entity);
        Task<bool> DeleteAsync(string id);
        Task<bool> UpdateAsync(T entity);
    }
}
