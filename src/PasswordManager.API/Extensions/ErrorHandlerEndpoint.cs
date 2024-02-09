using Microsoft.AspNetCore.Diagnostics;
using PasswordManager.Application.Errors;

namespace PasswordManager.API.Extensions;

public static class ErrorHandlerEndpoint
{
    public static WebApplication AddErrorHandlerEndPoint(this WebApplication app)
    {
        var errorHandlerEndPoint = app.MapGroup("/password-manager/api/error");
        app.UseExceptionHandler("/password-manager/api/error");

        errorHandlerEndPoint.Map("/", (HttpContext context) =>
        {
            var exception = context.Features.Get<IExceptionHandlerFeature>()?.Error;
            var (statusCode, messege) = exception switch
            {
                IServiceException serviceException => ((int)serviceException.StatusCode, serviceException.ErrorMessage),
                _ => (StatusCodes.Status500InternalServerError, "An error occurred while processing your request")
            };

            return new ErrorResponse(messege: messege, statusCode: statusCode);
        });
        return app;
    }
}