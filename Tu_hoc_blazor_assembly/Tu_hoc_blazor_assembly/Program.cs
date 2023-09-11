using Blazored.Toast;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Tu_hoc_blazor_assembly;
using Tu_hoc_blazor_assembly.Service;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");
builder.Services.AddBlazoredToast();
builder.Services.AddScoped<ITaskAPIClient,TaskAPIClient>();
builder.Services.AddScoped<IUserAPIClient,UserAPIClient>();
builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.Configuration["ConnectURL"]) });

await builder.Build().RunAsync();
