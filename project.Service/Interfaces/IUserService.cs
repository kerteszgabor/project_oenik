using project.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace project.Service.Interfaces
{
    public interface IUserService
    {
        IEnumerable<User> GetUsers();
        User GetUserById(string id);
        User GetUserByName(string name);
    }
}
