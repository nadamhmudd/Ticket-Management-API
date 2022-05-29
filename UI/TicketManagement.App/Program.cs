using AutoMapper;
using Blazored.LocalStorage;
using TicketManagement.App.Auth;
using TicketManagement.App.Contracts;
using TicketManagement.App.Services;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Net.Http;
using System.Reflection;
using System.Threading.Tasks;

namespace TicketManagement.App
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            var builder = WebAssemblyHostBuilder.CreateDefault(args);
            builder.RootComponents.Add<App>("app");

            builder.Services.AddAutoMapper(Assembly.GetExecutingAssembly());
            builder.Services.AddBlazoredLocalStorage();

            builder.Services.AddAuthorizationCore();
            builder.Services.AddScoped<AuthenticationStateProvider, CustomAuthenticationStateProvider>();


            builder.Services.AddSingleton(new HttpClient
            {
                BaseAddress = new Uri("https://localhost:5001")
            });

            builder.Services.AddHttpClient<IClient, Client>(client => client.BaseAddress = new Uri("https://localhost:5001"));

            builder.Services.AddScoped<IEventDataService, EventDataService>();
            builder.Services.AddScoped<ICategoryDataService, CategoryDataService>();
            builder.Services.AddScoped<IOrderDataService, OrderDataService>();
            builder.Services.AddScoped<IAuthenticationService, AuthenticationService>();

            await builder.Build().RunAsync();
        }
    }
}
