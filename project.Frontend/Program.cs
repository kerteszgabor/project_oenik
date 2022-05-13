using Blazored.LocalStorage;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using MudBlazor;
using MudBlazor.Services;
using project.Client;
using project.Client.Services;
using project.Client.Shared.Navigation;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace project.Client
{
    public class Program
    {
        private const string URL = "https://localhost:44337";
        public static async Task Main(string[] args)
        {
            var builder = WebAssemblyHostBuilder.CreateDefault(args);
            builder.RootComponents.Add<project.Client.App>("#app");

            builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });

            builder.Services.AddScoped<AuthenticationService>(s =>
            {
                return new AuthenticationService(URL);
            });

            builder.Services.AddScoped<UserService>(s =>
            {
                return new UserService(URL);
            });

            builder.Services.AddScoped<CoursesService>(s =>
            {
                return new CoursesService(URL);
            });
            
            builder.Services.AddScoped<TestsService>(s =>
            {
                return new TestsService(URL);
            });
            
            builder.Services.AddScoped<QuestionsService>(s =>
            {
                return new QuestionsService(URL);
            });

            builder.Services.AddSingleton<PageHistoryState>();

            builder.Services.AddScoped<AuthenticationStateProvider, LocalAuthenticationStateProvider>();

            builder.Services.AddMudServices();
            builder.Services.AddBlazoredLocalStorage();
            builder.Services.AddOptions();
            builder.Services.AddAuthorizationCore();
            builder.Services.AddMudBlazorDialog();
            builder.Services.AddMudServices(config =>
            {
                config.SnackbarConfiguration.PositionClass = Defaults.Classes.Position.BottomLeft;

                config.SnackbarConfiguration.PreventDuplicates = false;
                config.SnackbarConfiguration.NewestOnTop = false;
                config.SnackbarConfiguration.ShowCloseIcon = true;
                config.SnackbarConfiguration.VisibleStateDuration = 10000;
                config.SnackbarConfiguration.HideTransitionDuration = 500;
                config.SnackbarConfiguration.ShowTransitionDuration = 500;
                config.SnackbarConfiguration.SnackbarVariant = Variant.Filled;
            });

            await builder.Build().RunAsync();
        }
    }
}
