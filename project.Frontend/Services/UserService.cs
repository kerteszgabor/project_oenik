using AKSoftware.WebApi.Client;
using project.Domain.DTO.Client;
using project.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace project.Client.Services
{
    public class UserService
    {
        private readonly string baseURL;

        ServiceClient client = new ServiceClient();

        public string AccessToken
        {
            get => client.AccessToken;
            set
            {
                client.AccessToken = value;
            }
        }

        public UserService(string url)
        {
            baseURL = url;
        }

        public async Task<IEnumerable<User>> GetAllUsersAsync()
        {
            var response = await client.GetProtectedAsync<IEnumerable<User>>($"{baseURL}/users");
            return response.Result;
        }

        public async Task<User> GetUserAsync(string id)
        {
            var response = await client.GetProtectedAsync<User>($"{baseURL}/users/{id}");
            return response.Result;
        }

        public async Task<bool> DeleteUserAsync(string id)
        {
            var response = await client.DeleteProtectedAsync<User>($"{baseURL}/users/{id}");
            return response.IsSucceded;
        }

        public async Task<bool> RegisterUserAsync(RegisterRequest registerRequest)
        {
            var response = await client.PostProtectedAsync<User>($"{baseURL}/users/register", registerRequest);
            if (response.IsSucceded)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public async Task<User> UpdateUserAsync(string id)
        {
            var response = await client.GetProtectedAsync<User>($"{baseURL}/users/{id}");
            return response.Result;
        }
    }
}
