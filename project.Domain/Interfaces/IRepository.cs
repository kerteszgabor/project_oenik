using project.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace project.Domain.Interfaces
{
    public interface IRepository<T> 
    {
        Task<T> Get(string id);
        IAsyncEnumerable<T> GetAll();
        Task<bool> Create(T entity);
    }
}
