using System.Net;
using PasswordManager.Application.Services;

namespace PasswordManager.Application.Errors;

public class InvalidPasswordException : Exception, IServiceException
{
    public string ErrorMessage => "Invalid password provided. Please provide a valid password.";
    public HttpStatusCode StatusCode => HttpStatusCode.BadRequest;
}