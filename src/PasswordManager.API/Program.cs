using PasswordManager.API.Endpoints;
using PasswordManager.API.Extensions;
using PasswordManager.Application;
using PasswordManager.IoC;

WebApplicationBuilder builder = WebApplication.CreateBuilder(args);

builder.Services
    .AddEndpointsApiExplorer()
    .AddIoC(builder.Configuration)
    .AddCustomSwagger();

WebApplication app = builder.Build();

app.UseHttpsRedirection();
app.AddAuthenticationEndpoint();
app.AddCustomErrors();
app.AddCustomSwagger();

app.Run();