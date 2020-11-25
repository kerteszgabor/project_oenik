using project.Domain.Models;
using project.Service.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using project.Repository.Interfaces;

namespace project.Service.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository<User> userRepo;
        public UserService(IUserRepository<User> userRepo)
        {
            this.userRepo = userRepo;
        }

        public User GetUserById(string id)
        {
            return userRepo.Get(id).Result;
        }

        public User GetUserByName(string name)
        {
            return userRepo.GetByName(name).Result;
        }

        public IEnumerable<User> GetUsers()
        {
            return userRepo.GetAll().Result;
        }
    }
}
