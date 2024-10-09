using BlazorBootstrap;
using drdblaze;
using drdblaze.Data;
using drdblaze.Services;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using VisNetwork.Blazor;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });
builder.Services.AddSingleton<SharedData, SharedData>();

builder.Services.AddVisNetwork();

 // Register the FetchDataService
builder.Services.AddScoped<FetchDataService>();

builder.Services.AddBlazorBootstrap(); 
await builder.Build().RunAsync();
