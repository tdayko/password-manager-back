using System.Net;
using PasswordManager.Application.Services;

namespace PasswordManager.Application.Errors;

public class  UnauthenticatedUserException : Exception, IServiceException
{
    public HttpStatusCode StatusCode => HttpStatusCode.Unauthorized;
    public string ErrorMessage => "Access Denied. Authentication required for access.";
}