using PasswordManager.Application;
using PasswordManager.IoC;
using PasswordManager.API.Extensions;
using PasswordManager.API.Extensions.Endpoints;

#region Builder Services

WebApplicationBuilder builder = WebApplication.CreateBuilder(args);

builder.Services.AddEndpointsApiExplorer();

builder.Services.AddMediatR();
builder.Services.AddIoC(builder.Configuration);
builder.Services.AddCustomSwagger();

#endregion
WebApplication app = builder.Build();

#region App Settings

app.UseHttpsRedirection();

app.AddAuthenticationEndpoint();
app.AddCustomErrors();
app.AddCustomSwagger();

#endregion
app.Run();