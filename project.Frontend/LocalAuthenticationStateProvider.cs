﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Blazored.LocalStorage;
using Microsoft.AspNetCore.Components.Authorization;
using project.Domain.DTO.Client;

namespace project.Client
{
    public class LocalAuthenticationStateProvider : AuthenticationStateProvider
    {
        private readonly ILocalStorageService _storageService;

        public LocalAuthenticationStateProvider(ILocalStorageService storageService)
        {
            this._storageService = storageService;
        }
        public async override Task<AuthenticationState> GetAuthenticationStateAsync()
        {
            if (await _storageService.ContainKeyAsync("User") && !(await TokenExpired()))
            {
                var userInfo = await _storageService.GetItemAsync<ClientUserInfo>("User");

                var claims = new[]
                {
                    new Claim("AccessToken", userInfo.Token), 
                    new Claim("Expiration", userInfo.Expiration.AddHours(2).ToString()),
                    new Claim(ClaimTypes.Role, userInfo.Role),
                    new Claim(ClaimTypes.Name, userInfo.Username)
                };

                var identity = new ClaimsIdentity(claims, "BearerToken");
                var user = new ClaimsPrincipal(identity);
                var state = new AuthenticationState(user);

                NotifyAuthenticationStateChanged(Task.FromResult(state));
                return state;
            }

            return new AuthenticationState(new ClaimsPrincipal());
        }

        public async Task LogoutAsync()
        {
            await _storageService.RemoveItemAsync("User");
            NotifyAuthenticationStateChanged(Task.FromResult(new AuthenticationState(new ClaimsPrincipal())));
        }

        private async Task<bool> TokenExpired() => (await _storageService.GetItemAsync<ClientUserInfo>("User"))?.Expiration < DateTime.Now;
    }
}
