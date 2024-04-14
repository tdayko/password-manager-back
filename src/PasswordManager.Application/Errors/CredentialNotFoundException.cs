using System.Net;
using PasswordManager.Application.Services;

namespace PasswordManager.Application.Errors;

public class CredentialNotFoundException : Exception, IServiceException
{
    public HttpStatusCode StatusCode => HttpStatusCode.NotFound;
    public string ErrorMessage => "The credential with the specified ID was not found.";
}