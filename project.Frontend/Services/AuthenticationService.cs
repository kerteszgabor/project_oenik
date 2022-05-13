using AKSoftware.WebApi.Client;
using project.Domain.DTO.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace project.Client.Services
{
    public class AuthenticationService
    {
        private readonly string baseURL;

        ServiceClient client = new ServiceClient();
        public AuthenticationService(string url)
        {
            baseURL = url;
        }

        public async Task<ClientUserInfo> RegisterUserAsync(RegisterRequest request)
        {
            var response = await client.PostAsync<ClientUserInfo>($"{baseURL}/users/register", request);
            return response.Result;
        }

        public async Task<ClientUserInfo> LoginUserAsync(LoginRequest request)
        {
            var response = await client.PostAsync<ClientUserInfo>($"{baseURL}/users/login", request);
            return response.Result;
        }
    }
}
