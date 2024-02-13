using PasswordManager.Application;
using PasswordManager.IoC;
using PasswordManager.API.Extensions;
using PasswordManager.API.EndPoints;

WebApplicationBuilder builder = WebApplication.CreateBuilder(args);

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