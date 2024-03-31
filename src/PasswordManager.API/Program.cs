using PasswordManager.API.Endpoints;
using PasswordManager.API.Extensions;
using PasswordManager.Application;
using PasswordManager.IoC;
using DotNetEnv;
using DotNetEnv.Configuration;

WebApplicationBuilder builder = WebApplication.CreateBuilder(args);

string rootPath = Directory.GetCurrentDirectory();
builder.Configuration
    .AddDotNetEnv(Path.Combine(Directory.GetParent(rootPath)!.Parent!.FullName, ".env"), LoadOptions.TraversePath())
    .Build();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddMediatR();
builder.Services.AddIoC(builder.Configuration);
builder.Services.AddCustomSwagger();

WebApplication app = builder.Build();

app.UseHttpsRedirection();
app.AddAuthenticationEndpoint();
app.AddCustomErrors();
app.AddCustomSwagger();

app.Run();