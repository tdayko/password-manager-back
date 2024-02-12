using System;

using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Microsoft.OpenApi.Models;

using PasswordManager.Application;
using PasswordManager.Application.Errors;
using PasswordManager.IoC;

WebApplicationBuilder builder = WebApplication.CreateBuilder(args);
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddControllers();
builder.Services.AddSwaggerGen(x =>
    x.SwaggerDoc("v1",
        new OpenApiInfo
        {
            Title = "Password Manager v2",
            Description = "Easily protect sensitive passwords with this API",
            Version = "v2"
        }
    ));

builder.Services.AddMediatR();
builder.Services.AddIoC(builder.Configuration);

WebApplication app = builder.Build();

#region App Settings
app.UseExceptionHandler("/error");
app.Map("/error", (HttpContext context) =>
{
    var exception = context.Features.Get<IExceptionHandlerFeature>()?.Error;
    var (statusCode, title) = exception switch
    {
        IServiceException serviceException => ((int)serviceException.StatusCode, serviceException.ErrorMessage),
        _ => (StatusCodes.Status500InternalServerError, "An error occurred while processing your request")
    };
    
    return Results.Problem(new ProblemDetails() {Title = title, Status = statusCode, Detail = exception?.InnerException?.Message});
});

app.UseHttpsRedirection();
app.MapControllers();
app.UseSwagger();
app.UseSwaggerUI(x => x.SwaggerEndpoint("/swagger/v1/swagger.json", "Password Manager API"));
app.MapGet("/", () => Results.Redirect("/swagger")).ExcludeFromDescription();
app.Run();

#endregion