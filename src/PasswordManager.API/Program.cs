using PasswordManager.API.Endpoints;
using PasswordManager.API.Extensions;
using PasswordManager.Application;
using PasswordManager.IoC;
using DotNetEnv;
using DotNetEnv.Configuration;
using PasswordManager.API.Helpers;

WebApplicationBuilder builder = WebApplication.CreateBuilder(args);

builder.Services
    .AddEndpointsApiExplorer()
    .AddMediatR()
    .AddIoC(builder.Configuration)
    .AddCustomSwagger();

string currentDir = Directory.GetCurrentDirectory();
builder.Configuration
    .AddDotNetEnv(EnvFileManager.GetEnvFilePath(currentDir), LoadOptions.TraversePath())
    .Build();

WebApplication app = builder.Build();

app.UseHttpsRedirection();
app.AddAuthenticationEndpoint();
app.AddCustomErrors();
app.AddCustomSwagger();

app.Run();