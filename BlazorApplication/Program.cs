using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using BlazorApplication;
using BlazorApplication.Auth;
using BlazorApplication.Services;
using BlazorApplication.Services.Http;
using HttpClients.ClientInterfaces;
using HttpClients.Implementations;
using Microsoft.AspNetCore.Components.Authorization;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Services.AddScoped(
    sp => 
        new HttpClient { 
            BaseAddress = new Uri("https://localhost:7278") 
        }
);

builder.Services.AddScoped<IPostsService, PostHttpClient>();

builder.Services.AddScoped<IUserService, UserHttpClient>();

builder.Services.AddScoped<IAuthService, JwtAuthService>();

builder.Services.AddScoped<AuthenticationStateProvider, CustomAuthProvider>();
builder.Services.AddAuthorizationCore();

await builder.Build().RunAsync();