using PasswordManager.Application;
using PasswordManager.IoC;
using PasswordManager.API.Extensions;

WebApplicationBuilder builder = WebApplication.CreateBuilder(args);
builder.Services.AddEndpointsApiExplorer();

builder.Services.AddMediatR();
builder.Services.AddIoC(builder.Configuration);
builder.Services.AddCustomSwagger();

WebApplication app = builder.Build();

#region App Settings

app.AddCustomErrors();
app.AddCustomSwagger();

app.UseHttpsRedirection();
app.Run();

#endregion