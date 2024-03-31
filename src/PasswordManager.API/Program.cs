using PasswordManager.API.Endpoints;
using PasswordManager.API.Extensions;
using PasswordManager.Application;
using PasswordManager.IoC;
using DotNetEnv;
using DotNetEnv.Configuration;

WebApplicationBuilder builder = WebApplication.CreateBuilder(args);

string envFilePath = Path.Combine(Directory.GetParent(Directory.GetCurrentDirectory())!.Parent!.FullName, ".env");
builder.Configuration
    .AddDotNetEnv(envFilePath, LoadOptions.TraversePath())
    .Build();

builder.Services
    .AddEndpointsApiExplorer()
    .AddMediatR()
    .AddIoC(builder.Configuration)
    .AddCustomSwagger();

WebApplication app = builder.Build();

app.UseHttpsRedirection();
app.AddAuthenticationEndpoint();
app.AddCustomErrors();
app.AddCustomSwagger();

app.Run();
