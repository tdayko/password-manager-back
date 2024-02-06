using System.Text;
using System.Text.Json;

using PasswordManager.Application.Contracts;

namespace PasswordManager.API.Middlewares;

public class ApiResponseMiddleware(RequestDelegate next)
{
    private readonly RequestDelegate _next = next;
    public async Task InvokeAsync(HttpContext context)
    {
        if (context.Request.Path.StartsWithSegments("/password-manager/api"))
        {
            try
            {

                using var memoryStream = new MemoryStream();
                var originalResponseBody = context.Response.Body;
                context.Response.Body = memoryStream;

                await _next(context);
                bool success = context.Response.StatusCode < 400;

                memoryStream.Seek(0, SeekOrigin.Begin);
                var originalResponseData = await JsonSerializer.DeserializeAsync<object>(memoryStream);

                // building response
                var apiResponse = new ApiResponse(success, originalResponseData!);
                var json = JsonSerializer.Serialize(apiResponse);
                context.Response.Body = originalResponseBody;
                await context.Response.WriteAsync(json, Encoding.UTF8);
            }
            catch (Exception ex)
            {
                context.Response.StatusCode = StatusCodes.Status500InternalServerError;
                await context.Response.WriteAsync($"Erro no middleware: {ex.Message}", Encoding.UTF8);
            }
        }
        else
        {
            await _next(context);
        }
    }
}

