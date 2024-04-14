using System.Net;
using PasswordManager.Application.Services;

namespace PasswordManager.Application.Errors;

public class NoCredentialsWereFoundException : Exception, IServiceException
{
    public string ErrorMessage => "No credentials were found.";
    public HttpStatusCode StatusCode => HttpStatusCode.NotFound;
}