using Microsoft.AspNetCore.Diagnostics;
using Microsoft.OpenApi.Models;

using PasswordManager.API.Middlewares;
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
builder.Services.AddIoC();

WebApplication app = builder.Build();

#region App Settings

app.UseMiddleware<ApiResponseMiddleware>();
app.UseHttpsRedirection();
app.UseExceptionHandler("/password-manager/api/error");
app.Map("/password-manager/api/error", (HttpContext context) =>
{
    var exception = context.Features.Get<IExceptionHandlerFeature>()?.Error;
    var (statusCode, messege) = exception switch
        {
            IServiceException serviceException => ((int)serviceException.StatusCode, serviceException.ErrorMessage),
            _ => (StatusCodes.Status500InternalServerError, "An error occurred while processing your request")
        };

    return new ErrorResponse(messege: messege, statusCode: statusCode);
});

app.MapControllers();
app.UseSwagger();
app.UseSwaggerUI(x => x.SwaggerEndpoint("/swagger/v1/swagger.json", "Password Manager API"));
app.MapGet("/", () => Results.Redirect("/swagger")).ExcludeFromDescription();
app.Run();

#endregion