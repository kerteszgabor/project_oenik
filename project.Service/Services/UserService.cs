﻿using project.Domain.Models;
using project.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using project.Domain.DTO;
using Microsoft.AspNetCore.JsonPatch;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using System.IdentityModel.Tokens.Jwt;
using project.Domain.DTO.Auth;
using project.Service.Interfaces;

namespace project.Service.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository<User> userRepo;
        public UserService(IUserRepository<User> userRepo)
        {
            this.userRepo = userRepo;
        }

        public async Task<bool> Delete(string uid)
        {
            return await userRepo.DeleteAsync(uid);
        }

        public async Task<User> Get(string uid)
        {
            return await userRepo.GetAsync(uid);
        }

        public async IAsyncEnumerable<User> List()
        {
            await foreach (var item in userRepo.GetAllAsync())
                yield return item;
        }


        public async Task<bool> Register(RegisterData model)
        {
            if (model != null)
            {
                return await userRepo.Register(model);
            }
            else
            {
                return false;
            }
        }

        public async Task<bool> Update(string uid, JsonPatchDocument<User> patch)
        {
            if (patch != null)
            {
                var user = await userRepo.GetAsync(uid);
                patch.ApplyTo(user);
                user.ModifiedOn = DateTime.Now;
                await userRepo.UpdateAsync(user);
                return true;
            }
            else
            {
                return false;
            }
        }

        public async Task<User> GetUserByName(string name)
        {
            var allUsers = await userRepo.GetAllAsync().ToListAsync();
            return allUsers.FirstOrDefault(x => x.UserName == name);
        }

        public async Task<JwtSecurityToken> Login(LoginData model)
        {
            if (model != null)
            {
                return await userRepo.Login(model);
            }
            else
            {
                return null;
            }
        }
    }
}
