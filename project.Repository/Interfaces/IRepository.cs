using project.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace project.Repository.Interfaces
{
    public interface IRepository<T> where T : BaseEntity
    {
        T Get(string id);
        IAsyncEnumerable<T> GetAll();
    }
}
