using Blazored.LocalStorage;
using FiapHackaton.WebApp;
using FiapHackaton.WebApp.Contracts;
using FiapHackaton.WebApp.Contracts.Interface;
using FiapHackaton.WebApp.Services;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });
builder.Services.AddHttpClient();
builder.Services.AddHttpClient("LocalApi", client => client.BaseAddress = new Uri("https://localhost:7289/"));


builder.Services.AddScoped<IAuthRepository, AuthRepository>();
builder.Services.AddScoped<LocalStorageService>();

// Add this line to register Blazored.LocalStorage
builder.Services.AddBlazoredLocalStorage();
await builder.Build().RunAsync();
