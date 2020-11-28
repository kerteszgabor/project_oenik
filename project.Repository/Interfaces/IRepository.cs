using project.Domain.Models;
using project.Repository.Data;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace project.Repository.Interfaces
{
    public interface IRepository<T> where T : BaseEntity
    {
        ApplicationDbContext context { get; set; }
        Task<T> Get(string id);
        IAsyncEnumerable<T> GetAll();
        Task<bool> Create(T entity);
    }
}
